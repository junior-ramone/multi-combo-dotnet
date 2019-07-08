Partial Class MultiCombo
    Inherits ComboBox

    'Component overrides dispose to clean up the component list.
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

    'Required by the Component Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Component Designer
    'It can be modified using the Component Designer.
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.LstItems = New System.Windows.Forms.ListView()
        Me.ChkAllItems = New System.Windows.Forms.CheckBox()
        Me.CmdRefresh = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'LstItems
        '
        Me.LstItems.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.LstItems.FullRowSelect = True
        Me.LstItems.Location = New System.Drawing.Point(0, 0)
        Me.LstItems.MultiSelect = False
        Me.LstItems.Name = "LstItems"
        Me.LstItems.OwnerDraw = True
        Me.LstItems.ShowItemToolTips = True
        Me.LstItems.Size = New System.Drawing.Size(400, 400)
        Me.LstItems.TabIndex = 0
        Me.LstItems.UseCompatibleStateImageBehavior = False
        Me.LstItems.View = System.Windows.Forms.View.Details
        '
        'ChkAllItems
        '
        Me.ChkAllItems.AutoSize = True
        Me.ChkAllItems.BackColor = System.Drawing.Color.Transparent
        Me.ChkAllItems.Location = New System.Drawing.Point(4, 5)
        Me.ChkAllItems.Name = "ChkAllItems"
        Me.ChkAllItems.Size = New System.Drawing.Size(20, 20)
        Me.ChkAllItems.TabIndex = 0
        Me.ChkAllItems.UseVisualStyleBackColor = False
        '
        'CmdRefresh
        '
        Me.CmdRefresh.BackColor = System.Drawing.Color.Transparent
        Me.CmdRefresh.BackgroundImage = Global.MultiComboBox.My.Resources.Resources.sincronizar
        Me.CmdRefresh.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.CmdRefresh.FlatAppearance.BorderSize = 0
        Me.CmdRefresh.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.CmdRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.CmdRefresh.Font = New System.Drawing.Font("Arial", 8.0!)
        Me.CmdRefresh.ForeColor = System.Drawing.Color.Black
        Me.CmdRefresh.Location = New System.Drawing.Point(0, 0)
        Me.CmdRefresh.Name = "CmdRefresh"
        Me.CmdRefresh.Size = New System.Drawing.Size(22, 22)
        Me.CmdRefresh.TabIndex = 0
        Me.CmdRefresh.TabStop = False
        Me.CmdRefresh.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.CmdRefresh.UseVisualStyleBackColor = False
        '
        'MultiCombo
        '
        Me.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ItemHeight = 15
        Me.MaxDropDownItems = 15
        Me.MaxLength = 50
        Me.Size = New System.Drawing.Size(121, 21)
        Me.ResumeLayout(False)

    End Sub

    Private WithEvents PopUp As ToolStripDropDown
    Private WithEvents ChkAllItems As System.Windows.Forms.CheckBox
    Private WithEvents CmdRefresh As Button
    Private WithEvents LstItems As System.Windows.Forms.ListView
End Class
