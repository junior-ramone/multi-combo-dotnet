Imports System.ComponentModel
Imports System.Drawing
Imports System.Data
Imports System.Linq

''' <summary>
''' ComboBox control with interval ListView for multiple columns and multiple selection
''' </summary>
Public Class MultiCombo
    Dim controlHost As ToolStripControlHost
    Dim lastColumnClicked As Integer = -1
    Dim lastSortOrder As SortOrder = SortOrder.None
    Dim lastSelection As String = ""
    Dim isLoadingPopUp As Boolean = False

    <System.Diagnostics.DebuggerNonUserCode()> _
    Public Sub New(ByVal container As System.ComponentModel.IContainer)
        MyClass.New()

        'Required for Windows.Forms Class Composition Designer support
        If (container IsNot Nothing) Then
            container.Add(Me)
        End If
    End Sub

    <System.Diagnostics.DebuggerNonUserCode()> _
    Public Sub New()
        MyBase.New()

        'This call is required by the Component Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call.        
        Me.FocusedBackColor = Color.AliceBlue
        Me.FocusedFontColor = Color.Black
        Me.DrawMode = Windows.Forms.DrawMode.OwnerDrawFixed
        MyBase.DropDownHeight = 1
        MyBase.DropDownStyle = ComboBoxStyle.DropDown

        controlHost = New ToolStripControlHost(LstItems)
        controlHost.Margin = Padding.Empty
        controlHost.Padding = Padding.Empty

        PopUp = New ToolStripDropDown()
        PopUp.Items.Add(controlHost)

        'Call the CreateControl in order to get access to it even before it show up the first time
        LstItems.CreateControl()
    End Sub

    'Public Shadows Event SelectedIndexChanged(sender As Object, e As System.EventArgs)
    Public Shadows Event SelectedItemChanged(sender As System.Object, e As System.Windows.Forms.ListViewItemSelectionChangedEventArgs)
    Public Shadows Event SelectionChangeCommitted(sender As System.Object, e As System.EventArgs)

    <Category("Custom")> _
    Public Event ItemChecked(sender As Object, e As System.Windows.Forms.ItemCheckedEventArgs)

    <Category("Custom")> _
    Public Event RefreshClick(sender As Object, e As System.EventArgs)

#Region "-- Properties --"

    <Browsable(False)> <DefaultValue(1)> _
    Public Shadows ReadOnly Property DropDownHeight As Integer
        Get
            Return 1
        End Get
    End Property

    <Browsable(False)> <DefaultValue(GetType(ComboBoxStyle), "DropDown")>
    Public Shadows ReadOnly Property DropDownStyle As ComboBoxStyle
        Get
            Return ComboBoxStyle.DropDown
        End Get
    End Property

    Dim _dataSource As Object

    Public Shadows Property DataSource As Object
        Get
            Return _dataSource
        End Get
        Set(value As Object)
            _dataSource = value

            Call LoadDataSource()

            Me.OnDataSourceChanged(New EventArgs)
        End Set
    End Property

    <Browsable(False)> _
    Public ReadOnly Property InternalList As ListView
        Get
            Return LstItems
        End Get
    End Property

    <Category("Custom")>
    Public Property CheckBoxes As Boolean
        Get
            Return LstItems.CheckBoxes
        End Get
        Set(value As Boolean)
            LstItems.CheckBoxes = value
            Me.Text = ""
        End Set
    End Property

    <Category("Custom")>
    Public Property HeaderStyle As ColumnHeaderStyle
        Get
            Return LstItems.HeaderStyle
        End Get
        Set(value As ColumnHeaderStyle)
            LstItems.HeaderStyle = value
        End Set
    End Property

    <Browsable(False)> _
    Public Shadows Property SelectedIndex As Integer
        Get
            If LstItems.SelectedItems.Count > 0 Then
                Return LstItems.SelectedItems(0).Index
            Else
                Return -1
            End If
        End Get
        Set(value As Integer)
            If value >= 0 Then
                LstItems.Items(value).Selected = True
            Else
                LstItems.SelectedItems.Clear()
                Me.Text = ""
            End If
        End Set
    End Property

    ''' <summary>
    ''' When adding items manually, i.e., without DataSource, the Value will be gotten from the Tag property of each item
    ''' </summary>
    <Browsable(False)> _
    Public Shadows Property SelectedValue As String
        Get
            If LstItems.CheckBoxes = False And LstItems.SelectedItems.Count > 0 Then
                If LstItems.SelectedItems(0).Tag IsNot Nothing Then
                    Return LstItems.SelectedItems(0).Tag.ToString
                Else
                    Return LstItems.SelectedItems(0).SubItems(LstItems.SelectedItems(0).SubItems.Count - 1).Text
                End If
            Else
                Return ""
            End If
        End Get
        Set(value As String)
            If LstItems.CheckBoxes = False Then
                LstItems.SelectedItems.Clear()
                Me.Text = ""

                For Each it As ListViewItem In LstItems.Items
                    If it.Tag IsNot Nothing Then
                        If it.Tag.ToString.Trim.ToUpper = value.Trim.ToUpper Then
                            it.Selected = True
                            Exit For
                        End If
                    Else
                        If it.SubItems(it.SubItems.Count - 1).Text.Trim.ToUpper = value.Trim.ToUpper Then
                            it.Selected = True
                            Exit For
                        End If
                    End If
                Next
            End If
        End Set
    End Property

    <Browsable(False)> _
    Public Shadows ReadOnly Property SelectedItem As ListViewItem
        Get
            If LstItems.SelectedItems.Count > 0 Then
                Return LstItems.SelectedItems(0)
            Else
                Return Nothing
            End If
        End Get
    End Property

    <Browsable(False)> _
    Public ReadOnly Property CheckedItems As ListView.CheckedListViewItemCollection
        Get
            Return LstItems.CheckedItems
        End Get
    End Property

    <Browsable(False)> _
    Public Shadows ReadOnly Property Items As ListView.ListViewItemCollection
        Get
            Return LstItems.Items
        End Get
    End Property

    <Category("Custom")>
    <DesignerSerializationVisibility(DesignerSerializationVisibility.Content)>
    Public ReadOnly Property Columns As ListView.ColumnHeaderCollection
        Get
            Return LstItems.Columns
        End Get
    End Property

    <Category("Custom")>
    <DesignerSerializationVisibility(DesignerSerializationVisibility.Content)>
    Public ReadOnly Property Groups As ListViewGroupCollection
        Get
            Return LstItems.Groups
        End Get
    End Property

    <DefaultValue(True)> _
    <Category("Custom")> _
    Public Property CheckAllButton As Boolean = True

    Dim _refreshButton As Boolean

    <Category("Custom")> _
    Public Property RefreshButton As Boolean
        Get
            Return _refreshButton
        End Get
        Set(value As Boolean)
            _refreshButton = value

            Call CheckRefreshButton()
        End Set
    End Property

    ''' <summary>
    ''' Custom text to be displayed when all items are checked
    ''' </summary>    
    <Description("Custom text to be displayed when all items are checked")> _
    <Category("Custom")> _
    Public Property AllCheckedText() As String

    <DefaultValue(GetType(Color), "AliceBlue")> _
    <Category("Custom")> _
    Public Property FocusedBackColor() As Color = Color.AliceBlue

    <DefaultValue(GetType(Color), "Black")> _
    <Category("Custom")> _
    Public Property FocusedFontColor() As Color = Color.Black

#End Region

    'Using OnDropDown, it's necessary to click on the list, now I'm using OnClick and F4 (KeyDown) instead
    'Protected Overrides Sub OnDropDown(e As System.EventArgs)
    '    MyBase.OnDropDown(e)

    '    Call ShowDropDown()
    'End Sub

    Protected Overrides Sub OnClick(e As System.EventArgs)
        MyBase.OnClick(e)

        Call ShowDropDown()
    End Sub

    Private Sub ShowDropDown()
        isLoadingPopUp = True
        lastSelection = Me.Text

        LstItems.MultiSelect = False
        LstItems.ForeColor = Me.ForeColor
        LstItems.Font = Me.Font

        Call ResizeListHeight()
        Call ResizeListWidth()
        Call ResizeListColumns()

        Dim itemsTemp As New List(Of ListViewItem)
        Dim groupsTemp As New List(Of ListViewGroup)

        If LstItems.Columns.Count > 0 And LstItems.Items.Count > 0 Then
            Call UpdateCheckAllButton()

            If LstItems.SelectedItems.Count > 0 Then
                LstItems.SelectedItems(0).EnsureVisible()
                LstItems.SelectedItems(0).Focused = True
            Else
                LstItems.Items(0).Focused = True
            End If

            'With many items (5000+), in the first opening, the PopUp was loading very slowly and weirdly
            'I couldn't find any solution, even posting here: 
            'http://stackoverflow.com/questions/23569031/long-delay-when-displaying-control-within-toolstripdropdown
            'This is a workaround I came up, copy all items, show the PopUp, and restore items

            If Not PopUp.IsHandleCreated And LstItems.Items.Count > 5000 Then
                itemsTemp.AddRange((From it As ListViewItem In LstItems.Items Select it.Clone).Cast(Of ListViewItem))
                groupsTemp.AddRange(LstItems.Groups.Cast(Of ListViewGroup)())

                LstItems.Items.Clear()
                LstItems.Groups.Clear()
            End If
        End If

        PopUp.Show(Me, 0, Me.Height)

        If itemsTemp.Count > 0 Then
            LstItems.BeginUpdate()
            LstItems.Groups.AddRange(groupsTemp.ToArray)
            LstItems.Items.AddRange(itemsTemp.ToArray)
            LstItems.EndUpdate()
        End If

        If LstItems.CanFocus Then LstItems.Focus()
        isLoadingPopUp = False
    End Sub

    Private Sub ResizeListHeight()
        Dim height As Integer = 0

        If LstItems.Items.Count > 0 Then
            If Me.MaxDropDownItems < LstItems.Items.Count Then
                height += Me.MaxDropDownItems * LstItems.GetItemRect(0).Height - 2
            Else
                height += LstItems.Items.Count * LstItems.GetItemRect(0).Height - 2
                height += LstItems.Groups.Count * 40
            End If
        End If

        If height <= 0 Then
            height = 200
        Else
            If LstItems.HeaderStyle <> ColumnHeaderStyle.None Then height += 30
        End If

        LstItems.Height = height
    End Sub

    Private Sub ResizeListWidth()
        If Me.DropDownWidth < Me.Width Then
            If LstItems.Width <> Me.Width Then
                LstItems.Width = Me.Width
            End If
        Else
            If LstItems.Width <> Me.DropDownWidth Then
                LstItems.Width = Me.DropDownWidth
            End If
        End If
    End Sub

    Private Sub ResizeListColumns()
        If LstItems.Columns.Count = 0 Then Exit Sub

        Dim columnProportion As Integer = 0
        Dim sumProportion As Integer = 0
        Dim sumWidth As Integer = LstItems.Columns.Cast(Of ColumnHeader)().Sum(Function(col) col.Width)

        For Each col As ColumnHeader In LstItems.Columns
            If col.Index < (LstItems.Columns.Count - 1) Then
                columnProportion = Math.Round(col.Width / sumWidth * 100, 2)
                sumProportion += columnProportion
            Else
                columnProportion = 100 - sumProportion
            End If

            If Me.MaxDropDownItems < LstItems.Items.Count Then
                col.Width = Math.Floor(columnProportion / 100 * (LstItems.Width - SystemInformation.VerticalScrollBarWidth - 1))
            Else
                col.Width = Math.Floor(columnProportion / 100 * LstItems.Width)
            End If
        Next
    End Sub

    Private Sub UpdateCheckAllButton()
        If LstItems.CheckBoxes = True And CheckAllButton = True Then
            If Not LstItems.Controls.Contains(ChkAllItems) Then
                LstItems.Controls.Add(ChkAllItems)
                LstItems.Columns(0).Text = Space(6) & LstItems.Columns(0).Text.Trim
            End If
        Else
            If LstItems.Controls.Contains(ChkAllItems) Then
                LstItems.Controls.Remove(ChkAllItems)
                LstItems.Columns(0).Text = LstItems.Columns(0).Text.Trim
            End If
        End If
    End Sub

    Private Sub HideDropDown()
        PopUp.Close()
        Me.DroppedDown = False
    End Sub

    Private Sub LoadDataSource()
        Me.SelectedIndex = -1
        LstItems.Items.Clear()

        If Not IsNothing(Me.DataSource) Then
            Dim newItem As ListViewItem
            Dim items As New List(Of ListViewItem)

            If TypeOf Me.DataSource Is DataTable Or TypeOf Me.DataSource Is DataSet Then
                Dim dt As DataTable

                'If DataSet is passed, the first table is used

                If TypeOf Me.DataSource Is DataTable Then
                    dt = CType(Me.DataSource, DataTable)
                Else
                    dt = CType(Me.DataSource, DataSet).Tables(0)
                End If

                If dt.Rows.Count = 0 Then Exit Sub

                For Each dr As DataRow In dt.Rows
                    newItem = New ListViewItem

                    If Me.DisplayMember <> "" Then
                        'If DisplayMember is set, get the apropriate column

                        If Me.FormattingEnabled And Me.FormatString <> "" Then
                            newItem.Text = Strings.Format(dr.Item(Me.DisplayMember).ToString, Me.FormatString)
                        Else
                            newItem.Text = dr.Item(Me.DisplayMember).ToString
                        End If

                        If Me.ValueMember <> "" Then
                            'If there are more than 1 column configured on the list, show the Value

                            If LstItems.Columns.Count > 1 Then
                                newItem.SubItems.Add(dr.Item(Me.ValueMember).ToString)
                            End If

                            newItem.Tag = dr.Item(Me.ValueMember).ToString
                        Else
                            newItem.Tag = newItem.Text
                        End If
                    Else
                        'If DisplayMember is NOT set, fill the columns according to order in the DataSource
                        'The last column of the DataSource will be the Value

                        newItem.Text = dr.Item(0).ToString

                        For i As Integer = 1 To LstItems.Columns.Count - 1
                            If i <= dt.Columns.Count - 1 Then
                                newItem.SubItems.Add(dr.Item(i).ToString)
                            Else
                                newItem.SubItems.Add("")
                            End If
                        Next

                        newItem.Tag = newItem.SubItems(newItem.SubItems.Count - 1).Text
                    End If

                    items.Add(newItem)
                Next

            Else

                'Using BindingSource or Dictionary / Generic List directly (anything implementing IList)

                Dim data As IList

                If TypeOf Me.DataSource Is BindingSource Then
                    data = CType(Me.DataSource, BindingSource).List
                Else
                    data = CType(Me.DataSource, IList)
                End If

                If data.Count = 0 Then Exit Sub

                Dim valueProperty As Reflection.PropertyInfo = data.GetType().GetGenericArguments(0).GetProperty(Me.ValueMember)
                Dim displayProperty As Reflection.PropertyInfo = data.GetType().GetGenericArguments(0).GetProperty(Me.DisplayMember)

                For Each item In data
                    Dim value As String = valueProperty.GetValue(item, Nothing).ToString()
                    Dim display As String = displayProperty.GetValue(item, Nothing).ToString()

                    newItem = New ListViewItem(display)
                    newItem.Tag = value

                    If LstItems.Columns.Count > 1 Then
                        newItem.SubItems.Add(value)

                        For x As Integer = 3 To LstItems.Columns.Count
                            newItem.SubItems.Add("")
                        Next
                    End If

                    items.Add(newItem)
                Next

            End If

            'Using AddRange to improve loading performance
            If items.Count > 0 Then
                LstItems.BeginUpdate()
                LstItems.Items.AddRange(items.ToArray)
                LstItems.EndUpdate()
                Me.SelectedIndex = 0
            End If
        End If
    End Sub

    ''' <summary>
    ''' Check which items are checked/selected and sets the Text property
    ''' </summary>
    Private Sub CheckSelection()
        If LstItems.CheckBoxes Then

            If LstItems.CheckedItems.Count = LstItems.Items.Count And AllCheckedText <> "" Then

                Me.Text = AllCheckedText

            ElseIf LstItems.CheckedItems.Count > 0 Then

                Dim str As New System.Text.StringBuilder

                For Each it As ListViewItem In LstItems.CheckedItems
                    If it.Tag IsNot Nothing Then
                        str.Append(it.Tag.ToString).Append(", ")
                    Else
                        str.Append(it.SubItems(it.SubItems.Count - 1).Text).Append(", ")
                    End If
                Next

                Me.Text = str.ToString.Remove(str.Length - 2)

            Else

                Me.Text = ""

            End If

        Else

            If LstItems.CheckedItems.Count = LstItems.Items.Count And AllCheckedText <> "" Then

                Me.Text = AllCheckedText

            ElseIf LstItems.SelectedItems.Count > 0 Then

                If LstItems.SelectedItems(0).Text <> "" AndAlso Me.SelectedValue <> "" Then
                    Me.Text = LstItems.SelectedItems(0).Text & " > " & Me.SelectedValue
                Else
                    Me.Text = ""
                End If

            Else

                Me.Text = ""

            End If

        End If
    End Sub

    Private Sub PopUp_Closed(sender As Object, e As System.Windows.Forms.ToolStripDropDownClosedEventArgs) Handles PopUp.Closed
        Call CheckSelection()

        If Me.Text.Trim.ToUpper <> lastSelection.Trim.ToUpper Then
            RaiseEvent SelectionChangeCommitted(Me, New EventArgs)
        End If
    End Sub

    Protected Overrides Sub OnKeyPress(e As System.Windows.Forms.KeyPressEventArgs)
        MyBase.OnKeyPress(e)
        e.Handled = True

        'Show the DropDown when a key is pressed at the first time, allowing the search in the list
        Call ShowDropDown()

        SendKeys.SendWait(e.KeyChar.ToString)
    End Sub

    Protected Overrides Sub OnKeyDown(e As System.Windows.Forms.KeyEventArgs)
        MyBase.OnKeyDown(e)

        Select Case e.KeyCode
            Case Keys.Delete
                e.Handled = True
            Case Keys.F4
                If e.Alt = False Then
                    Call ShowDropDown()

                    e.Handled = True
                End If
        End Select

        If LstItems.CheckBoxes = False Then
            'Navigate between items with keyboard when DropDown is closed
            Dim prevIndex As Integer = Me.SelectedIndex

            Select Case e.KeyCode
                Case Keys.Up

                    If Me.SelectedIndex > 0 Then
                        Me.SelectedIndex -= 1
                    End If

                Case Keys.Down

                    If Me.SelectedIndex < Me.Items.Count - 1 Then
                        Me.SelectedIndex += 1
                    End If

                Case Keys.PageUp

                    If (Me.SelectedIndex - Me.MaxDropDownItems - 1) > 0 Then
                        Me.SelectedIndex -= Me.MaxDropDownItems - 1
                    Else
                        Me.SelectedIndex = 0
                    End If

                Case Keys.PageDown

                    If (Me.SelectedIndex + Me.MaxDropDownItems - 1) < (Me.Items.Count - 1) Then
                        Me.SelectedIndex += Me.MaxDropDownItems - 1
                    Else
                        Me.SelectedIndex = Me.Items.Count - 1
                    End If

                Case Keys.Home

                    If Me.Items.Count > 0 Then
                        Me.SelectedIndex = 0
                    End If

                Case Keys.End

                    Me.SelectedIndex = Me.Items.Count - 1

            End Select

            If Me.SelectedIndex <> prevIndex Then
                'Automatically raise ChangeCommitted when the user changes the selected item
                RaiseEvent SelectionChangeCommitted(Me, New EventArgs)
            End If
        End If
    End Sub

    Protected Overrides Sub OnEnabledChanged(e As System.EventArgs)
        MyBase.OnEnabledChanged(e)

        If Me.Enabled = True Then
            Me.BackColor = Color.White
        Else
            Me.BackColor = Color.Gainsboro
        End If
    End Sub

    Protected Overrides Sub OnVisibleChanged(e As System.EventArgs)
        MyBase.OnVisibleChanged(e)

        Call CheckRefreshButton()
    End Sub

    Private Sub CheckRefreshButton()
        If Me.Parent IsNot Nothing Then

            If Me.Visible And _refreshButton = True Then
                If Not Me.Parent.Controls.Contains(CmdRefresh) Then
                    Me.Parent.Controls.Add(CmdRefresh)
                End If

                Call UpdateRefreshButtonLocation()
            Else
                If Me.Parent.Controls.Contains(CmdRefresh) Then
                    Me.Parent.Controls.Remove(CmdRefresh)
                End If
            End If

        End If
    End Sub

    Private Sub UpdateRefreshButtonLocation() Handles Me.SizeChanged, Me.LocationChanged
        If _refreshButton = True Then
            CmdRefresh.Height = Me.Height + 2
            CmdRefresh.Location = New Point(Me.Right + 1, Me.Top - 1)
        End If
    End Sub

    Protected Overrides Sub OnGotFocus(e As System.EventArgs)
        MyBase.OnGotFocus(e)

        Me.BackColor = FocusedBackColor
        Me.ForeColor = FocusedFontColor
    End Sub

    Protected Overrides Sub OnLostFocus(e As System.EventArgs)
        MyBase.OnLostFocus(e)

        If Not PopUp Is Nothing Then
            Me.BackColor = Color.White
            Me.ForeColor = Color.Black

            Call CheckSelection()
        End If
    End Sub

    Private Sub ToggleCheckAll(check As Boolean)
        For Each it As ListViewItem In LstItems.Items
            it.Checked = check
        Next
    End Sub

    Private Sub ChkAllItems_CheckedChanged(sender As Object, e As System.EventArgs) Handles ChkAllItems.CheckedChanged
        ToggleCheckAll(ChkAllItems.Checked)
    End Sub

    Public Sub UncheckAll()
        ChkAllItems.Checked = False
        ToggleCheckAll(ChkAllItems.Checked)
        CheckSelection()
    End Sub

    Public Sub CheckAll()
        ChkAllItems.Checked = True
        ToggleCheckAll(ChkAllItems.Checked)
        CheckSelection()
    End Sub

    Private Sub CmdRefresh_Click(sender As Object, e As System.EventArgs) Handles CmdRefresh.Click
        RaiseEvent RefreshClick(Me, e)
    End Sub

#Region " -- ListView Events -- "
    Private Sub LstItens_Click(sender As Object, e As System.EventArgs) Handles LstItems.Click
        If LstItems.CheckBoxes = False Then
            Call HideDropDown()
        End If
    End Sub

    Private Sub LstItens_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles LstItems.KeyDown
        Select Case e.KeyCode
            Case Keys.F4, Keys.Escape, Keys.Enter
                Call HideDropDown()
            Case Else

        End Select
    End Sub

    Private Sub LstItens_ColumnClick(sender As Object, e As System.Windows.Forms.ColumnClickEventArgs) Handles LstItems.ColumnClick
        If e.Column <> lastColumnClicked Then
            lastColumnClicked = e.Column
            lastSortOrder = SortOrder.Ascending
        Else
            If lastSortOrder = SortOrder.Ascending Then
                lastSortOrder = SortOrder.Descending
            Else
                lastSortOrder = SortOrder.Ascending
            End If
        End If

        LstItems.Sorting = SortOrder.None
        LstItems.ListViewItemSorter = New ListViewItemComparer(lastColumnClicked, lastSortOrder)
        LstItems.Sort()

        'Add the original sorting icon using windows API
        ShowSortIcon(LstItems, lastSortOrder, lastColumnClicked)
    End Sub

    Private Sub LstItens_ItemSelectionChanged(sender As Object, e As System.Windows.Forms.ListViewItemSelectionChangedEventArgs) Handles LstItems.ItemSelectionChanged
        If isLoadingPopUp = True Then Exit Sub

        If LstItems.CheckBoxes = False Then
            If e.IsSelected Then
                If e.Item.Text <> "" AndAlso Me.SelectedValue <> "" Then
                    Me.Text = e.Item.Text & " > " & Me.SelectedValue
                Else
                    Me.Text = ""
                End If
            Else
                Me.Text = ""
            End If

            RaiseEvent SelectedItemChanged(Me, e)
        End If
    End Sub

    Private Sub LstItens_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles LstItems.SelectedIndexChanged
        If isLoadingPopUp = True Then Exit Sub

        If LstItems.Items.Count = 0 Then
            'Clear the Text when all items are removed from the list
            Me.Text = ""
        End If

        'RaiseEvent SelectedIndexChanged(Me, e)
    End Sub

    Private Sub LstItens_ItemChecked(sender As Object, e As System.Windows.Forms.ItemCheckedEventArgs) Handles LstItems.ItemChecked
        RaiseEvent ItemChecked(Me, e)
    End Sub

    Private Sub LstItens_DrawColumnHeader(sender As Object, e As System.Windows.Forms.DrawListViewColumnHeaderEventArgs) Handles LstItems.DrawColumnHeader
        e.DrawDefault = True

        If e.ColumnIndex = 0 Then
            If LstItems.Controls.Contains(ChkAllItems) Then
                ChkAllItems.Invalidate()
            End If
        End If
    End Sub

    Private Sub LstItens_DrawItem(sender As Object, e As System.Windows.Forms.DrawListViewItemEventArgs) Handles LstItems.DrawItem
        e.DrawDefault = True
    End Sub

    Private Sub LstItens_DrawSubItem(sender As Object, e As System.Windows.Forms.DrawListViewSubItemEventArgs) Handles LstItems.DrawSubItem
        e.DrawDefault = True
    End Sub
#End Region
End Class