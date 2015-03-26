Imports System.ComponentModel
Imports Microsoft.VisualBasic.CompilerServices

<DesignerGenerated()> _
Partial Class MainWindow
  Inherits Form

  'Form overrides dispose to clean up the component list.
  <DebuggerNonUserCode()> _
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
  Private components As IContainer

  'NOTE: The following procedure is required by the Windows Form Designer
  'It can be modified using the Windows Form Designer.  
  'Do not modify it using the code editor.
  <DebuggerStepThrough()> _
  Private Sub InitializeComponent()
    Me.EditDataGridView = New DataGridView()
    Me.SelectEditCourseComboBox = New ComboBox()
    Me.SelectEditYearComboBox = New ComboBox()
    Me.MenuStrip = New MenuStrip()
    Me.ImportStudentsMenuItem = New ToolStripMenuItem()
    Me.SetDisciplinesToolStripMenuItem = New ToolStripMenuItem()
    CType(Me.EditDataGridView, ISupportInitialize).BeginInit()
    Me.MenuStrip.SuspendLayout()
    Me.SuspendLayout()
    '
    'EditDataGridView
    '
    Me.EditDataGridView.AllowUserToAddRows = False
    Me.EditDataGridView.AllowUserToDeleteRows = False
    Me.EditDataGridView.Anchor = CType((((AnchorStyles.Top Or AnchorStyles.Bottom) _
            Or AnchorStyles.Left) _
            Or AnchorStyles.Right), AnchorStyles)
    Me.EditDataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
    Me.EditDataGridView.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells
    Me.EditDataGridView.BackgroundColor = SystemColors.Window
    Me.EditDataGridView.BorderStyle = BorderStyle.Fixed3D
    Me.EditDataGridView.CellBorderStyle = DataGridViewCellBorderStyle.Raised
    Me.EditDataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
    Me.EditDataGridView.Location = New Point(12, 108)
    Me.EditDataGridView.Name = "EditDataGridView"
    Me.EditDataGridView.RowHeadersVisible = False
    Me.EditDataGridView.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders
    Me.EditDataGridView.Size = New Size(754, 424)
    Me.EditDataGridView.TabIndex = 0
    Me.EditDataGridView.Visible = False
    '
    'SelectEditCourseComboBox
    '
    Me.SelectEditCourseComboBox.DropDownStyle = ComboBoxStyle.DropDownList
    Me.SelectEditCourseComboBox.FormattingEnabled = True
    Me.SelectEditCourseComboBox.Location = New Point(12, 74)
    Me.SelectEditCourseComboBox.Name = "SelectEditCourseComboBox"
    Me.SelectEditCourseComboBox.Size = New Size(121, 28)
    Me.SelectEditCourseComboBox.TabIndex = 1
    '
    'SelectEditYearComboBox
    '
    Me.SelectEditYearComboBox.DropDownStyle = ComboBoxStyle.DropDownList
    Me.SelectEditYearComboBox.FormattingEnabled = True
    Me.SelectEditYearComboBox.Location = New Point(12, 40)
    Me.SelectEditYearComboBox.Name = "SelectEditYearComboBox"
    Me.SelectEditYearComboBox.Size = New Size(121, 28)
    Me.SelectEditYearComboBox.TabIndex = 2
    '
    'MenuStrip
    '
    Me.MenuStrip.BackColor = SystemColors.Control
    Me.MenuStrip.Items.AddRange(New ToolStripItem() {Me.ImportStudentsMenuItem, Me.SetDisciplinesToolStripMenuItem})
    Me.MenuStrip.Location = New Point(0, 0)
    Me.MenuStrip.Name = "MenuStrip"
    Me.MenuStrip.Size = New Size(778, 33)
    Me.MenuStrip.TabIndex = 3
    Me.MenuStrip.Text = "MenuStrip1"
    '
    'ImportStudentsMenuItem
    '
    Me.ImportStudentsMenuItem.Name = "ImportStudentsMenuItem"
    Me.ImportStudentsMenuItem.Size = New Size(178, 29)
    Me.ImportStudentsMenuItem.Text = "Schüler importieren"
    '
    'SetDisciplinesToolStripMenuItem
    '
    Me.SetDisciplinesToolStripMenuItem.Name = "SetDisciplinesToolStripMenuItem"
    Me.SetDisciplinesToolStripMenuItem.Size = New Size(187, 29)
    Me.SetDisciplinesToolStripMenuItem.Text = "Disziplinen einstellen"
    '
    'MainWindow
    '
    Me.AutoScaleDimensions = New SizeF(9.0!, 20.0!)
    Me.AutoScaleMode = AutoScaleMode.Font
    Me.ClientSize = New Size(778, 544)
    Me.Controls.Add(Me.SelectEditYearComboBox)
    Me.Controls.Add(Me.SelectEditCourseComboBox)
    Me.Controls.Add(Me.EditDataGridView)
    Me.Controls.Add(Me.MenuStrip)
    Me.Name = "MainWindow"
    Me.Text = "Honglorn"
    CType(Me.EditDataGridView, ISupportInitialize).EndInit()
    Me.MenuStrip.ResumeLayout(False)
    Me.MenuStrip.PerformLayout()
    Me.ResumeLayout(False)
    Me.PerformLayout()

  End Sub
  Friend WithEvents EditDataGridView As DataGridView
  Friend WithEvents SelectEditCourseComboBox As ComboBox
  Friend WithEvents SelectEditYearComboBox As ComboBox
  Friend WithEvents MenuStrip As MenuStrip
  Friend WithEvents ImportStudentsMenuItem As ToolStripMenuItem
  Friend WithEvents SetDisciplinesToolStripMenuItem As ToolStripMenuItem

End Class
