<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class MainWindow
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
    Me.EditDataGridView = New System.Windows.Forms.DataGridView()
    Me.SelectEditCourseComboBox = New System.Windows.Forms.ComboBox()
    Me.SelectEditYearComboBox = New System.Windows.Forms.ComboBox()
    Me.MenuStrip = New System.Windows.Forms.MenuStrip()
    Me.ImportStudentsMenuItem = New System.Windows.Forms.ToolStripMenuItem()
    Me.SetDisciplinesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
    CType(Me.EditDataGridView, System.ComponentModel.ISupportInitialize).BeginInit()
    Me.MenuStrip.SuspendLayout()
    Me.SuspendLayout()
    '
    'EditDataGridView
    '
    Me.EditDataGridView.AllowUserToAddRows = False
    Me.EditDataGridView.AllowUserToDeleteRows = False
    Me.EditDataGridView.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
    Me.EditDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
    Me.EditDataGridView.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
    Me.EditDataGridView.BackgroundColor = System.Drawing.SystemColors.Window
    Me.EditDataGridView.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
    Me.EditDataGridView.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised
    Me.EditDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
    Me.EditDataGridView.Location = New System.Drawing.Point(12, 108)
    Me.EditDataGridView.Name = "EditDataGridView"
    Me.EditDataGridView.RowHeadersVisible = False
    Me.EditDataGridView.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders
    Me.EditDataGridView.Size = New System.Drawing.Size(754, 424)
    Me.EditDataGridView.TabIndex = 0
    Me.EditDataGridView.Visible = False
    '
    'SelectEditCourseComboBox
    '
    Me.SelectEditCourseComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
    Me.SelectEditCourseComboBox.FormattingEnabled = True
    Me.SelectEditCourseComboBox.Location = New System.Drawing.Point(12, 74)
    Me.SelectEditCourseComboBox.Name = "SelectEditCourseComboBox"
    Me.SelectEditCourseComboBox.Size = New System.Drawing.Size(121, 28)
    Me.SelectEditCourseComboBox.TabIndex = 1
    '
    'SelectEditYearComboBox
    '
    Me.SelectEditYearComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
    Me.SelectEditYearComboBox.FormattingEnabled = True
    Me.SelectEditYearComboBox.Location = New System.Drawing.Point(12, 40)
    Me.SelectEditYearComboBox.Name = "SelectEditYearComboBox"
    Me.SelectEditYearComboBox.Size = New System.Drawing.Size(121, 28)
    Me.SelectEditYearComboBox.TabIndex = 2
    '
    'MenuStrip
    '
    Me.MenuStrip.BackColor = System.Drawing.SystemColors.Control
    Me.MenuStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ImportStudentsMenuItem, Me.SetDisciplinesToolStripMenuItem})
    Me.MenuStrip.Location = New System.Drawing.Point(0, 0)
    Me.MenuStrip.Name = "MenuStrip"
    Me.MenuStrip.Size = New System.Drawing.Size(778, 33)
    Me.MenuStrip.TabIndex = 3
    Me.MenuStrip.Text = "MenuStrip1"
    '
    'ImportStudentsMenuItem
    '
    Me.ImportStudentsMenuItem.Name = "ImportStudentsMenuItem"
    Me.ImportStudentsMenuItem.Size = New System.Drawing.Size(178, 29)
    Me.ImportStudentsMenuItem.Text = "Schüler importieren"
    '
    'SetDisciplinesToolStripMenuItem
    '
    Me.SetDisciplinesToolStripMenuItem.Name = "SetDisciplinesToolStripMenuItem"
    Me.SetDisciplinesToolStripMenuItem.Size = New System.Drawing.Size(187, 29)
    Me.SetDisciplinesToolStripMenuItem.Text = "Disziplinen einstellen"
    '
    'MainWindow
    '
    Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 20.0!)
    Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
    Me.ClientSize = New System.Drawing.Size(778, 544)
    Me.Controls.Add(Me.SelectEditYearComboBox)
    Me.Controls.Add(Me.SelectEditCourseComboBox)
    Me.Controls.Add(Me.EditDataGridView)
    Me.Controls.Add(Me.MenuStrip)
    Me.Name = "MainWindow"
    Me.Text = "Honglorn"
    CType(Me.EditDataGridView, System.ComponentModel.ISupportInitialize).EndInit()
    Me.MenuStrip.ResumeLayout(False)
    Me.MenuStrip.PerformLayout()
    Me.ResumeLayout(False)
    Me.PerformLayout()

  End Sub
  Friend WithEvents EditDataGridView As System.Windows.Forms.DataGridView
  Friend WithEvents SelectEditCourseComboBox As System.Windows.Forms.ComboBox
  Friend WithEvents SelectEditYearComboBox As System.Windows.Forms.ComboBox
  Friend WithEvents MenuStrip As System.Windows.Forms.MenuStrip
  Friend WithEvents ImportStudentsMenuItem As System.Windows.Forms.ToolStripMenuItem
  Friend WithEvents SetDisciplinesToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem

End Class
