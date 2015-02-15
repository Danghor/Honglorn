<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class SetDisciplinesDialog
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
    Me.ClassLabel = New System.Windows.Forms.Label()
    Me.ClassComboBox = New System.Windows.Forms.ComboBox()
    Me.YearComboBox = New System.Windows.Forms.ComboBox()
    Me.YearLabel = New System.Windows.Forms.Label()
    Me.GameTypeGroupBox = New System.Windows.Forms.GroupBox()
    Me.CompetitionGameTypeRadioButton = New System.Windows.Forms.RadioButton()
    Me.TraditionalGameTypeRadioButton = New System.Windows.Forms.RadioButton()
    Me.MaleLabel = New System.Windows.Forms.Label()
    Me.MySplitContainer = New System.Windows.Forms.SplitContainer()
    Me.SprintLowIsBetterMaleCheckBox = New System.Windows.Forms.CheckBox()
    Me.SprintNameMaleLabel = New System.Windows.Forms.Label()
    Me.SprintUnitMaleLabel = New System.Windows.Forms.Label()
    Me.TextBox1 = New System.Windows.Forms.TextBox()
    Me.SprintMaleComboBox = New System.Windows.Forms.ComboBox()
    Me.SprintLabel = New System.Windows.Forms.Label()
    Me.GameTypeGroupBox.SuspendLayout()
    CType(Me.MySplitContainer, System.ComponentModel.ISupportInitialize).BeginInit()
    Me.MySplitContainer.Panel1.SuspendLayout()
    Me.MySplitContainer.SuspendLayout()
    Me.SuspendLayout()
    '
    'ClassLabel
    '
    Me.ClassLabel.AutoSize = True
    Me.ClassLabel.Location = New System.Drawing.Point(211, 33)
    Me.ClassLabel.Name = "ClassLabel"
    Me.ClassLabel.Size = New System.Drawing.Size(101, 20)
    Me.ClassLabel.TabIndex = 0
    Me.ClassLabel.Text = "Klassenstufe"
    '
    'ClassComboBox
    '
    Me.ClassComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
    Me.ClassComboBox.FormattingEnabled = True
    Me.ClassComboBox.Location = New System.Drawing.Point(318, 30)
    Me.ClassComboBox.Name = "ClassComboBox"
    Me.ClassComboBox.Size = New System.Drawing.Size(121, 28)
    Me.ClassComboBox.TabIndex = 1
    '
    'YearComboBox
    '
    Me.YearComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
    Me.YearComboBox.FormattingEnabled = True
    Me.YearComboBox.Location = New System.Drawing.Point(58, 30)
    Me.YearComboBox.Name = "YearComboBox"
    Me.YearComboBox.Size = New System.Drawing.Size(121, 28)
    Me.YearComboBox.TabIndex = 3
    '
    'YearLabel
    '
    Me.YearLabel.AutoSize = True
    Me.YearLabel.Location = New System.Drawing.Point(12, 33)
    Me.YearLabel.Name = "YearLabel"
    Me.YearLabel.Size = New System.Drawing.Size(40, 20)
    Me.YearLabel.TabIndex = 2
    Me.YearLabel.Text = "Jahr"
    '
    'GameTypeGroupBox
    '
    Me.GameTypeGroupBox.Controls.Add(Me.CompetitionGameTypeRadioButton)
    Me.GameTypeGroupBox.Controls.Add(Me.TraditionalGameTypeRadioButton)
    Me.GameTypeGroupBox.Enabled = False
    Me.GameTypeGroupBox.Location = New System.Drawing.Point(484, 12)
    Me.GameTypeGroupBox.Name = "GameTypeGroupBox"
    Me.GameTypeGroupBox.Size = New System.Drawing.Size(486, 57)
    Me.GameTypeGroupBox.TabIndex = 4
    Me.GameTypeGroupBox.TabStop = False
    Me.GameTypeGroupBox.Text = "Art der Bewertung"
    '
    'CompetitionGameTypeRadioButton
    '
    Me.CompetitionGameTypeRadioButton.AutoSize = True
    Me.CompetitionGameTypeRadioButton.Location = New System.Drawing.Point(241, 25)
    Me.CompetitionGameTypeRadioButton.Name = "CompetitionGameTypeRadioButton"
    Me.CompetitionGameTypeRadioButton.Size = New System.Drawing.Size(235, 24)
    Me.CompetitionGameTypeRadioButton.TabIndex = 1
    Me.CompetitionGameTypeRadioButton.TabStop = True
    Me.CompetitionGameTypeRadioButton.Text = "Wettbewerb (neues System)"
    Me.CompetitionGameTypeRadioButton.UseVisualStyleBackColor = True
    '
    'TraditionalGameTypeRadioButton
    '
    Me.TraditionalGameTypeRadioButton.AutoSize = True
    Me.TraditionalGameTypeRadioButton.Location = New System.Drawing.Point(18, 25)
    Me.TraditionalGameTypeRadioButton.Name = "TraditionalGameTypeRadioButton"
    Me.TraditionalGameTypeRadioButton.Size = New System.Drawing.Size(217, 24)
    Me.TraditionalGameTypeRadioButton.TabIndex = 0
    Me.TraditionalGameTypeRadioButton.TabStop = True
    Me.TraditionalGameTypeRadioButton.Text = "Wettkampf (altes System)"
    Me.TraditionalGameTypeRadioButton.UseVisualStyleBackColor = True
    '
    'MaleLabel
    '
    Me.MaleLabel.AutoSize = True
    Me.MaleLabel.Location = New System.Drawing.Point(12, 12)
    Me.MaleLabel.Name = "MaleLabel"
    Me.MaleLabel.Size = New System.Drawing.Size(72, 20)
    Me.MaleLabel.TabIndex = 0
    Me.MaleLabel.Text = "Männlich"
    '
    'MySplitContainer
    '
    Me.MySplitContainer.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
    Me.MySplitContainer.IsSplitterFixed = True
    Me.MySplitContainer.Location = New System.Drawing.Point(12, 76)
    Me.MySplitContainer.Name = "MySplitContainer"
    Me.MySplitContainer.Orientation = System.Windows.Forms.Orientation.Horizontal
    '
    'MySplitContainer.Panel1
    '
    Me.MySplitContainer.Panel1.Controls.Add(Me.SprintLowIsBetterMaleCheckBox)
    Me.MySplitContainer.Panel1.Controls.Add(Me.SprintNameMaleLabel)
    Me.MySplitContainer.Panel1.Controls.Add(Me.SprintUnitMaleLabel)
    Me.MySplitContainer.Panel1.Controls.Add(Me.TextBox1)
    Me.MySplitContainer.Panel1.Controls.Add(Me.SprintMaleComboBox)
    Me.MySplitContainer.Panel1.Controls.Add(Me.SprintLabel)
    Me.MySplitContainer.Panel1.Controls.Add(Me.MaleLabel)
    Me.MySplitContainer.Size = New System.Drawing.Size(1154, 656)
    Me.MySplitContainer.SplitterDistance = 328
    Me.MySplitContainer.TabIndex = 1
    '
    'SprintLowIsBetterMaleCheckBox
    '
    Me.SprintLowIsBetterMaleCheckBox.AutoSize = True
    Me.SprintLowIsBetterMaleCheckBox.Location = New System.Drawing.Point(16, 152)
    Me.SprintLowIsBetterMaleCheckBox.Name = "SprintLowIsBetterMaleCheckBox"
    Me.SprintLowIsBetterMaleCheckBox.RightToLeft = System.Windows.Forms.RightToLeft.Yes
    Me.SprintLowIsBetterMaleCheckBox.Size = New System.Drawing.Size(166, 24)
    Me.SprintLowIsBetterMaleCheckBox.TabIndex = 7
    Me.SprintLowIsBetterMaleCheckBox.Text = "Weniger ist besser"
    Me.SprintLowIsBetterMaleCheckBox.UseVisualStyleBackColor = True
    '
    'SprintNameMaleLabel
    '
    Me.SprintNameMaleLabel.AutoSize = True
    Me.SprintNameMaleLabel.Location = New System.Drawing.Point(12, 89)
    Me.SprintNameMaleLabel.Name = "SprintNameMaleLabel"
    Me.SprintNameMaleLabel.Size = New System.Drawing.Size(140, 20)
    Me.SprintNameMaleLabel.TabIndex = 5
    Me.SprintNameMaleLabel.Text = "Name der Disziplin"
    '
    'SprintUnitMaleLabel
    '
    Me.SprintUnitMaleLabel.AutoSize = True
    Me.SprintUnitMaleLabel.Location = New System.Drawing.Point(95, 123)
    Me.SprintUnitMaleLabel.Name = "SprintUnitMaleLabel"
    Me.SprintUnitMaleLabel.Size = New System.Drawing.Size(58, 20)
    Me.SprintUnitMaleLabel.TabIndex = 4
    Me.SprintUnitMaleLabel.Text = "Einheit"
    '
    'TextBox1
    '
    Me.TextBox1.Location = New System.Drawing.Point(159, 120)
    Me.TextBox1.Name = "TextBox1"
    Me.TextBox1.Size = New System.Drawing.Size(121, 26)
    Me.TextBox1.TabIndex = 3
    '
    'SprintMaleComboBox
    '
    Me.SprintMaleComboBox.FormattingEnabled = True
    Me.SprintMaleComboBox.Location = New System.Drawing.Point(159, 86)
    Me.SprintMaleComboBox.Name = "SprintMaleComboBox"
    Me.SprintMaleComboBox.Size = New System.Drawing.Size(121, 28)
    Me.SprintMaleComboBox.TabIndex = 2
    '
    'SprintLabel
    '
    Me.SprintLabel.AutoSize = True
    Me.SprintLabel.Location = New System.Drawing.Point(12, 52)
    Me.SprintLabel.Name = "SprintLabel"
    Me.SprintLabel.Size = New System.Drawing.Size(51, 20)
    Me.SprintLabel.TabIndex = 1
    Me.SprintLabel.Text = "Sprint"
    '
    'SetDisciplinesDialog
    '
    Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 20.0!)
    Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
    Me.ClientSize = New System.Drawing.Size(1178, 744)
    Me.Controls.Add(Me.MySplitContainer)
    Me.Controls.Add(Me.GameTypeGroupBox)
    Me.Controls.Add(Me.YearComboBox)
    Me.Controls.Add(Me.YearLabel)
    Me.Controls.Add(Me.ClassComboBox)
    Me.Controls.Add(Me.ClassLabel)
    Me.MaximizeBox = False
    Me.MinimizeBox = False
    Me.Name = "SetDisciplinesDialog"
    Me.ShowIcon = False
    Me.ShowInTaskbar = False
    Me.Text = "SetDisciplinesDialog"
    Me.GameTypeGroupBox.ResumeLayout(False)
    Me.GameTypeGroupBox.PerformLayout()
    Me.MySplitContainer.Panel1.ResumeLayout(False)
    Me.MySplitContainer.Panel1.PerformLayout()
    CType(Me.MySplitContainer, System.ComponentModel.ISupportInitialize).EndInit()
    Me.MySplitContainer.ResumeLayout(False)
    Me.ResumeLayout(False)
    Me.PerformLayout()

  End Sub
  Friend WithEvents ClassLabel As System.Windows.Forms.Label
  Friend WithEvents ClassComboBox As System.Windows.Forms.ComboBox
  Friend WithEvents YearComboBox As System.Windows.Forms.ComboBox
  Friend WithEvents YearLabel As System.Windows.Forms.Label
  Friend WithEvents GameTypeGroupBox As System.Windows.Forms.GroupBox
  Friend WithEvents CompetitionGameTypeRadioButton As System.Windows.Forms.RadioButton
  Friend WithEvents TraditionalGameTypeRadioButton As System.Windows.Forms.RadioButton
  Friend WithEvents MaleLabel As System.Windows.Forms.Label
  Friend WithEvents MySplitContainer As System.Windows.Forms.SplitContainer
  Friend WithEvents SprintLabel As System.Windows.Forms.Label
  Friend WithEvents SprintNameMaleLabel As System.Windows.Forms.Label
  Friend WithEvents SprintUnitMaleLabel As System.Windows.Forms.Label
  Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
  Friend WithEvents SprintMaleComboBox As System.Windows.Forms.ComboBox
  Friend WithEvents SprintLowIsBetterMaleCheckBox As System.Windows.Forms.CheckBox
End Class
