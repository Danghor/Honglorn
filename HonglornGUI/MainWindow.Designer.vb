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
    CType(Me.EditDataGridView, System.ComponentModel.ISupportInitialize).BeginInit()
    Me.SuspendLayout()
    '
    'EditDataGridView
    '
    Me.EditDataGridView.AllowUserToAddRows = False
    Me.EditDataGridView.AllowUserToDeleteRows = False
    Me.EditDataGridView.AllowUserToResizeRows = False
    Me.EditDataGridView.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
    Me.EditDataGridView.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised
    Me.EditDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
    Me.EditDataGridView.Location = New System.Drawing.Point(180, 79)
    Me.EditDataGridView.Name = "EditDataGridView"
    Me.EditDataGridView.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders
    Me.EditDataGridView.Size = New System.Drawing.Size(1200, 700)
    Me.EditDataGridView.TabIndex = 0
    Me.EditDataGridView.Visible = False
    '
    'SelectEditCourseComboBox
    '
    Me.SelectEditCourseComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
    Me.SelectEditCourseComboBox.FormattingEnabled = True
    Me.SelectEditCourseComboBox.Location = New System.Drawing.Point(180, 45)
    Me.SelectEditCourseComboBox.Name = "SelectEditCourseComboBox"
    Me.SelectEditCourseComboBox.Size = New System.Drawing.Size(121, 28)
    Me.SelectEditCourseComboBox.TabIndex = 1
    '
    'SelectEditYearComboBox
    '
    Me.SelectEditYearComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
    Me.SelectEditYearComboBox.FormattingEnabled = True
    Me.SelectEditYearComboBox.Location = New System.Drawing.Point(180, 11)
    Me.SelectEditYearComboBox.Name = "SelectEditYearComboBox"
    Me.SelectEditYearComboBox.Size = New System.Drawing.Size(121, 28)
    Me.SelectEditYearComboBox.TabIndex = 2
    '
    'MainWindow
    '
    Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 20.0!)
    Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
    Me.ClientSize = New System.Drawing.Size(1553, 785)
    Me.Controls.Add(Me.SelectEditYearComboBox)
    Me.Controls.Add(Me.SelectEditCourseComboBox)
    Me.Controls.Add(Me.EditDataGridView)
    Me.Name = "MainWindow"
    Me.Text = "Form1"
    CType(Me.EditDataGridView, System.ComponentModel.ISupportInitialize).EndInit()
    Me.ResumeLayout(False)

  End Sub
  Friend WithEvents EditDataGridView As System.Windows.Forms.DataGridView
  Friend WithEvents SelectEditCourseComboBox As System.Windows.Forms.ComboBox
  Friend WithEvents SelectEditYearComboBox As System.Windows.Forms.ComboBox

End Class
