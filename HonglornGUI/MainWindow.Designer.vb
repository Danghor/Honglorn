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
    Me.DataGridView1 = New System.Windows.Forms.DataGridView()
    Me.SelectEditCourseComboBox = New System.Windows.Forms.ComboBox()
    Me.SelectEditYearComboBox = New System.Windows.Forms.ComboBox()
    CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
    Me.SuspendLayout()
    '
    'DataGridView1
    '
    Me.DataGridView1.AllowUserToAddRows = False
    Me.DataGridView1.AllowUserToDeleteRows = False
    Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
    Me.DataGridView1.Location = New System.Drawing.Point(180, 138)
    Me.DataGridView1.Name = "DataGridView1"
    Me.DataGridView1.RowTemplate.Height = 28
    Me.DataGridView1.Size = New System.Drawing.Size(728, 479)
    Me.DataGridView1.TabIndex = 0
    '
    'SelectEditCourseComboBox
    '
    Me.SelectEditCourseComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
    Me.SelectEditCourseComboBox.FormattingEnabled = True
    Me.SelectEditCourseComboBox.Location = New System.Drawing.Point(180, 12)
    Me.SelectEditCourseComboBox.Name = "SelectEditCourseComboBox"
    Me.SelectEditCourseComboBox.Size = New System.Drawing.Size(121, 28)
    Me.SelectEditCourseComboBox.TabIndex = 1
    '
    'SelectEditYearComboBox
    '
    Me.SelectEditYearComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
    Me.SelectEditYearComboBox.FormattingEnabled = True
    Me.SelectEditYearComboBox.Location = New System.Drawing.Point(787, 12)
    Me.SelectEditYearComboBox.Name = "SelectEditYearComboBox"
    Me.SelectEditYearComboBox.Size = New System.Drawing.Size(121, 28)
    Me.SelectEditYearComboBox.TabIndex = 2
    '
    'MainWindow
    '
    Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 20.0!)
    Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
    Me.ClientSize = New System.Drawing.Size(920, 629)
    Me.Controls.Add(Me.SelectEditYearComboBox)
    Me.Controls.Add(Me.SelectEditCourseComboBox)
    Me.Controls.Add(Me.DataGridView1)
    Me.Name = "MainWindow"
    Me.Text = "Form1"
    CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
    Me.ResumeLayout(False)

  End Sub
  Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
  Friend WithEvents SelectEditCourseComboBox As System.Windows.Forms.ComboBox
  Friend WithEvents SelectEditYearComboBox As System.Windows.Forms.ComboBox

End Class
