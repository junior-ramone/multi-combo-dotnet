<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.GroupBox5 = New System.Windows.Forms.GroupBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.TxtEvents = New System.Windows.Forms.TextBox()
        Me.CmbComboGroups = New MultiComboBox.MultiCombo(Me.components)
        Me.CmbComboListViewItems = New MultiComboBox.MultiCombo(Me.components)
        Me.CmbComboBindingDataTable = New MultiComboBox.MultiCombo(Me.components)
        Me.CmbComboBindingDictionary = New MultiComboBox.MultiCombo(Me.components)
        Me.CmbComboBindingList = New MultiComboBox.MultiCombo(Me.components)
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.GroupBox5.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.CmbComboBindingList)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 12)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Padding = New System.Windows.Forms.Padding(10)
        Me.GroupBox1.Size = New System.Drawing.Size(860, 71)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(10, 19)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(166, 15)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "DataSource with Generic List"
        '
        'GroupBox2
        '
        Me.GroupBox2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox2.Controls.Add(Me.Label2)
        Me.GroupBox2.Controls.Add(Me.CmbComboBindingDictionary)
        Me.GroupBox2.Location = New System.Drawing.Point(12, 89)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Padding = New System.Windows.Forms.Padding(10)
        Me.GroupBox2.Size = New System.Drawing.Size(860, 71)
        Me.GroupBox2.TabIndex = 2
        Me.GroupBox2.TabStop = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(10, 19)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(157, 15)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "DataSource with Dicitionary"
        '
        'GroupBox3
        '
        Me.GroupBox3.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox3.Controls.Add(Me.Label3)
        Me.GroupBox3.Controls.Add(Me.CmbComboBindingDataTable)
        Me.GroupBox3.Location = New System.Drawing.Point(12, 166)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Padding = New System.Windows.Forms.Padding(10)
        Me.GroupBox3.Size = New System.Drawing.Size(860, 71)
        Me.GroupBox3.TabIndex = 2
        Me.GroupBox3.TabStop = False
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(10, 19)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(156, 15)
        Me.Label3.TabIndex = 1
        Me.Label3.Text = "DataSource with DataTable"
        '
        'GroupBox4
        '
        Me.GroupBox4.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox4.Controls.Add(Me.Label4)
        Me.GroupBox4.Controls.Add(Me.CmbComboListViewItems)
        Me.GroupBox4.Location = New System.Drawing.Point(12, 243)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Padding = New System.Windows.Forms.Padding(10)
        Me.GroupBox4.Size = New System.Drawing.Size(860, 71)
        Me.GroupBox4.TabIndex = 2
        Me.GroupBox4.TabStop = False
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(10, 19)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(175, 15)
        Me.Label4.TabIndex = 1
        Me.Label4.Text = "ListViewItems added manually"
        '
        'GroupBox5
        '
        Me.GroupBox5.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox5.Controls.Add(Me.Label5)
        Me.GroupBox5.Controls.Add(Me.CmbComboGroups)
        Me.GroupBox5.Location = New System.Drawing.Point(12, 320)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Padding = New System.Windows.Forms.Padding(10)
        Me.GroupBox5.Size = New System.Drawing.Size(860, 71)
        Me.GroupBox5.TabIndex = 2
        Me.GroupBox5.TabStop = False
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(10, 19)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(275, 15)
        Me.Label5.TabIndex = 1
        Me.Label5.Text = "ListViewItems added manually + ListViewGroups"
        '
        'TxtEvents
        '
        Me.TxtEvents.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TxtEvents.Font = New System.Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtEvents.Location = New System.Drawing.Point(12, 404)
        Me.TxtEvents.Multiline = True
        Me.TxtEvents.Name = "TxtEvents"
        Me.TxtEvents.Size = New System.Drawing.Size(860, 180)
        Me.TxtEvents.TabIndex = 3
        '
        'CmbComboGroups
        '
        Me.CmbComboGroups.AllCheckedText = Nothing
        Me.CmbComboGroups.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.CmbComboGroups.CheckBoxes = False
        Me.CmbComboGroups.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.CmbComboGroups.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CmbComboGroups.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Clickable
        Me.CmbComboGroups.IntegralHeight = False
        Me.CmbComboGroups.ItemHeight = 15
        Me.CmbComboGroups.Location = New System.Drawing.Point(13, 37)
        Me.CmbComboGroups.MaxDropDownItems = 15
        Me.CmbComboGroups.MaxLength = 50
        Me.CmbComboGroups.Name = "CmbComboGroups"
        Me.CmbComboGroups.RefreshButton = True
        Me.CmbComboGroups.SelectedValue = ""
        Me.CmbComboGroups.Size = New System.Drawing.Size(816, 21)
        Me.CmbComboGroups.TabIndex = 0
        '
        'CmbComboListViewItems
        '
        Me.CmbComboListViewItems.AllCheckedText = Nothing
        Me.CmbComboListViewItems.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.CmbComboListViewItems.CheckBoxes = False
        Me.CmbComboListViewItems.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.CmbComboListViewItems.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CmbComboListViewItems.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Clickable
        Me.CmbComboListViewItems.IntegralHeight = False
        Me.CmbComboListViewItems.ItemHeight = 15
        Me.CmbComboListViewItems.Location = New System.Drawing.Point(13, 37)
        Me.CmbComboListViewItems.MaxDropDownItems = 15
        Me.CmbComboListViewItems.MaxLength = 50
        Me.CmbComboListViewItems.Name = "CmbComboListViewItems"
        Me.CmbComboListViewItems.RefreshButton = True
        Me.CmbComboListViewItems.SelectedValue = ""
        Me.CmbComboListViewItems.Size = New System.Drawing.Size(816, 21)
        Me.CmbComboListViewItems.TabIndex = 0
        '
        'CmbComboBindingDataTable
        '
        Me.CmbComboBindingDataTable.AllCheckedText = Nothing
        Me.CmbComboBindingDataTable.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.CmbComboBindingDataTable.CheckBoxes = True
        Me.CmbComboBindingDataTable.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.CmbComboBindingDataTable.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CmbComboBindingDataTable.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Clickable
        Me.CmbComboBindingDataTable.IntegralHeight = False
        Me.CmbComboBindingDataTable.ItemHeight = 15
        Me.CmbComboBindingDataTable.Location = New System.Drawing.Point(13, 37)
        Me.CmbComboBindingDataTable.MaxDropDownItems = 15
        Me.CmbComboBindingDataTable.MaxLength = 50
        Me.CmbComboBindingDataTable.Name = "CmbComboBindingDataTable"
        Me.CmbComboBindingDataTable.RefreshButton = True
        Me.CmbComboBindingDataTable.SelectedValue = ""
        Me.CmbComboBindingDataTable.Size = New System.Drawing.Size(816, 21)
        Me.CmbComboBindingDataTable.TabIndex = 0
        '
        'CmbComboBindingDictionary
        '
        Me.CmbComboBindingDictionary.AllCheckedText = Nothing
        Me.CmbComboBindingDictionary.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.CmbComboBindingDictionary.CheckBoxes = True
        Me.CmbComboBindingDictionary.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.CmbComboBindingDictionary.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CmbComboBindingDictionary.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Clickable
        Me.CmbComboBindingDictionary.IntegralHeight = False
        Me.CmbComboBindingDictionary.ItemHeight = 15
        Me.CmbComboBindingDictionary.Location = New System.Drawing.Point(13, 37)
        Me.CmbComboBindingDictionary.MaxDropDownItems = 15
        Me.CmbComboBindingDictionary.MaxLength = 50
        Me.CmbComboBindingDictionary.Name = "CmbComboBindingDictionary"
        Me.CmbComboBindingDictionary.RefreshButton = True
        Me.CmbComboBindingDictionary.SelectedValue = ""
        Me.CmbComboBindingDictionary.Size = New System.Drawing.Size(816, 21)
        Me.CmbComboBindingDictionary.TabIndex = 0
        '
        'CmbComboBindingList
        '
        Me.CmbComboBindingList.AllCheckedText = ""
        Me.CmbComboBindingList.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.CmbComboBindingList.CheckBoxes = True
        Me.CmbComboBindingList.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.CmbComboBindingList.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CmbComboBindingList.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Clickable
        Me.CmbComboBindingList.IntegralHeight = False
        Me.CmbComboBindingList.ItemHeight = 15
        Me.CmbComboBindingList.Location = New System.Drawing.Point(13, 37)
        Me.CmbComboBindingList.MaxDropDownItems = 15
        Me.CmbComboBindingList.MaxLength = 50
        Me.CmbComboBindingList.Name = "CmbComboBindingList"
        Me.CmbComboBindingList.RefreshButton = True
        Me.CmbComboBindingList.SelectedValue = ""
        Me.CmbComboBindingList.Size = New System.Drawing.Size(816, 21)
        Me.CmbComboBindingList.TabIndex = 0
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 14.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.WhiteSmoke
        Me.ClientSize = New System.Drawing.Size(888, 596)
        Me.Controls.Add(Me.TxtEvents)
        Me.Controls.Add(Me.GroupBox5)
        Me.Controls.Add(Me.GroupBox4)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Name = "Form1"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "MultiCombo Samples"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        Me.GroupBox5.ResumeLayout(False)
        Me.GroupBox5.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents CmbComboBindingList As MultiComboBox.MultiCombo
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents CmbComboBindingDictionary As MultiComboBox.MultiCombo
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents CmbComboBindingDataTable As MultiComboBox.MultiCombo
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents CmbComboListViewItems As MultiComboBox.MultiCombo
    Friend WithEvents GroupBox5 As System.Windows.Forms.GroupBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents CmbComboGroups As MultiComboBox.MultiCombo
    Friend WithEvents TxtEvents As System.Windows.Forms.TextBox

End Class
