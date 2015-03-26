Imports System.ComponentModel
Imports Microsoft.VisualBasic.CompilerServices

<DesignerGenerated()> _
Partial Class SetDisciplinesDialog
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
    Me.ClassLabel = New Label()
    Me.ClassComboBox = New ComboBox()
    Me.YearComboBox = New ComboBox()
    Me.YearLabel = New Label()
    Me.GameTypeGroupBox = New GroupBox()
    Me.CompetitionGameTypeRadioButton = New RadioButton()
    Me.TraditionalGameTypeRadioButton = New RadioButton()
    Me.MaleLabel = New Label()
    Me.MySplitContainer = New SplitContainer()
    Me.SprintLowIsBetterMaleCheckBox = New CheckBox()
    Me.SprintNameMaleLabel = New Label()
    Me.SprintUnitMaleLabel = New Label()
    Me.SprintUnitSymbolMaleComboBox = New TextBox()
    Me.SprintMaleComboBox = New ComboBox()
    Me.SprintLabel = New Label()
    Me.Panel1 = New Panel()
    Me.GameTypeGroupBox.SuspendLayout()
    CType(Me.MySplitContainer, ISupportInitialize).BeginInit()
    Me.MySplitContainer.Panel1.SuspendLayout()
    Me.MySplitContainer.SuspendLayout()
    Me.Panel1.SuspendLayout()
    Me.SuspendLayout()
    '
    'ClassLabel
    '
    Me.ClassLabel.AutoSize = True
    Me.ClassLabel.Location = New Point(211, 33)
    Me.ClassLabel.Name = "ClassLabel"
    Me.ClassLabel.Size = New Size(101, 20)
    Me.ClassLabel.TabIndex = 0
    Me.ClassLabel.Text = "Klassenstufe"
    '
    'ClassComboBox
    '
    Me.ClassComboBox.DropDownStyle = ComboBoxStyle.DropDownList
    Me.ClassComboBox.FormattingEnabled = True
    Me.ClassComboBox.Location = New Point(318, 30)
    Me.ClassComboBox.Name = "ClassComboBox"
    Me.ClassComboBox.Size = New Size(121, 28)
    Me.ClassComboBox.TabIndex = 1
    '
    'YearComboBox
    '
    Me.YearComboBox.DropDownStyle = ComboBoxStyle.DropDownList
    Me.YearComboBox.FormattingEnabled = True
    Me.YearComboBox.Location = New Point(58, 30)
    Me.YearComboBox.Name = "YearComboBox"
    Me.YearComboBox.Size = New Size(121, 28)
    Me.YearComboBox.TabIndex = 3
    '
    'YearLabel
    '
    Me.YearLabel.AutoSize = True
    Me.YearLabel.Location = New Point(12, 33)
    Me.YearLabel.Name = "YearLabel"
    Me.YearLabel.Size = New Size(40, 20)
    Me.YearLabel.TabIndex = 2
    Me.YearLabel.Text = "Jahr"
    '
    'GameTypeGroupBox
    '
    Me.GameTypeGroupBox.Controls.Add(Me.CompetitionGameTypeRadioButton)
    Me.GameTypeGroupBox.Controls.Add(Me.TraditionalGameTypeRadioButton)
    Me.GameTypeGroupBox.Enabled = False
    Me.GameTypeGroupBox.Location = New Point(484, 12)
    Me.GameTypeGroupBox.Name = "GameTypeGroupBox"
    Me.GameTypeGroupBox.Size = New Size(486, 57)
    Me.GameTypeGroupBox.TabIndex = 4
    Me.GameTypeGroupBox.TabStop = False
    Me.GameTypeGroupBox.Text = "Art der Bewertung"
    '
    'CompetitionGameTypeRadioButton
    '
    Me.CompetitionGameTypeRadioButton.AutoSize = True
    Me.CompetitionGameTypeRadioButton.Location = New Point(241, 25)
    Me.CompetitionGameTypeRadioButton.Name = "CompetitionGameTypeRadioButton"
    Me.CompetitionGameTypeRadioButton.Size = New Size(235, 24)
    Me.CompetitionGameTypeRadioButton.TabIndex = 1
    Me.CompetitionGameTypeRadioButton.TabStop = True
    Me.CompetitionGameTypeRadioButton.Text = "Wettbewerb (neues System)"
    Me.CompetitionGameTypeRadioButton.UseVisualStyleBackColor = True
    '
    'TraditionalGameTypeRadioButton
    '
    Me.TraditionalGameTypeRadioButton.AutoSize = True
    Me.TraditionalGameTypeRadioButton.Location = New Point(18, 25)
    Me.TraditionalGameTypeRadioButton.Name = "TraditionalGameTypeRadioButton"
    Me.TraditionalGameTypeRadioButton.Size = New Size(217, 24)
    Me.TraditionalGameTypeRadioButton.TabIndex = 0
    Me.TraditionalGameTypeRadioButton.TabStop = True
    Me.TraditionalGameTypeRadioButton.Text = "Wettkampf (altes System)"
    Me.TraditionalGameTypeRadioButton.UseVisualStyleBackColor = True
    '
    'MaleLabel
    '
    Me.MaleLabel.AutoSize = True
    Me.MaleLabel.Location = New Point(12, 12)
    Me.MaleLabel.Name = "MaleLabel"
    Me.MaleLabel.Size = New Size(72, 20)
    Me.MaleLabel.TabIndex = 0
    Me.MaleLabel.Text = "Männlich"
    '
    'MySplitContainer
    '
    Me.MySplitContainer.Anchor = CType((((AnchorStyles.Top Or AnchorStyles.Bottom) _
            Or AnchorStyles.Left) _
            Or AnchorStyles.Right), AnchorStyles)
    Me.MySplitContainer.IsSplitterFixed = True
    Me.MySplitContainer.Location = New Point(12, 76)
    Me.MySplitContainer.Name = "MySplitContainer"
    Me.MySplitContainer.Orientation = Orientation.Horizontal
    '
    'MySplitContainer.Panel1
    '
    Me.MySplitContainer.Panel1.Controls.Add(Me.Panel1)
    Me.MySplitContainer.Panel1.Controls.Add(Me.SprintNameMaleLabel)
    Me.MySplitContainer.Panel1.Controls.Add(Me.SprintMaleComboBox)
    Me.MySplitContainer.Panel1.Controls.Add(Me.SprintLabel)
    Me.MySplitContainer.Panel1.Controls.Add(Me.MaleLabel)
    Me.MySplitContainer.Size = New Size(1154, 656)
    Me.MySplitContainer.SplitterDistance = 328
    Me.MySplitContainer.TabIndex = 1
    '
    'SprintLowIsBetterMaleCheckBox
    '
    Me.SprintLowIsBetterMaleCheckBox.AutoSize = True
    Me.SprintLowIsBetterMaleCheckBox.Location = New Point(0, 35)
    Me.SprintLowIsBetterMaleCheckBox.Name = "SprintLowIsBetterMaleCheckBox"
    Me.SprintLowIsBetterMaleCheckBox.RightToLeft = RightToLeft.Yes
    Me.SprintLowIsBetterMaleCheckBox.Size = New Size(166, 24)
    Me.SprintLowIsBetterMaleCheckBox.TabIndex = 7
    Me.SprintLowIsBetterMaleCheckBox.Text = "Weniger ist besser"
    Me.SprintLowIsBetterMaleCheckBox.UseVisualStyleBackColor = True
    '
    'SprintNameMaleLabel
    '
    Me.SprintNameMaleLabel.AutoSize = True
    Me.SprintNameMaleLabel.Location = New Point(12, 89)
    Me.SprintNameMaleLabel.Name = "SprintNameMaleLabel"
    Me.SprintNameMaleLabel.Size = New Size(140, 20)
    Me.SprintNameMaleLabel.TabIndex = 5
    Me.SprintNameMaleLabel.Text = "Name der Disziplin"
    '
    'SprintUnitMaleLabel
    '
    Me.SprintUnitMaleLabel.AutoSize = True
    Me.SprintUnitMaleLabel.Location = New Point(10, 9)
    Me.SprintUnitMaleLabel.Name = "SprintUnitMaleLabel"
    Me.SprintUnitMaleLabel.Size = New Size(58, 20)
    Me.SprintUnitMaleLabel.TabIndex = 4
    Me.SprintUnitMaleLabel.Text = "Einheit"
    '
    'SprintUnitSymbolMaleComboBox
    '
    Me.SprintUnitSymbolMaleComboBox.Location = New Point(140, 3)
    Me.SprintUnitSymbolMaleComboBox.Name = "SprintUnitSymbolMaleComboBox"
    Me.SprintUnitSymbolMaleComboBox.Size = New Size(121, 26)
    Me.SprintUnitSymbolMaleComboBox.TabIndex = 3
    '
    'SprintMaleComboBox
    '
    Me.SprintMaleComboBox.FormattingEnabled = True
    Me.SprintMaleComboBox.Location = New Point(159, 86)
    Me.SprintMaleComboBox.Name = "SprintMaleComboBox"
    Me.SprintMaleComboBox.Size = New Size(121, 28)
    Me.SprintMaleComboBox.TabIndex = 2
    '
    'SprintLabel
    '
    Me.SprintLabel.AutoSize = True
    Me.SprintLabel.Location = New Point(12, 52)
    Me.SprintLabel.Name = "SprintLabel"
    Me.SprintLabel.Size = New Size(51, 20)
    Me.SprintLabel.TabIndex = 1
    Me.SprintLabel.Text = "Sprint"
    '
    'Panel1
    '
    Me.Panel1.Controls.Add(Me.SprintUnitMaleLabel)
    Me.Panel1.Controls.Add(Me.SprintLowIsBetterMaleCheckBox)
    Me.Panel1.Controls.Add(Me.SprintUnitSymbolMaleComboBox)
    Me.Panel1.Location = New Point(16, 120)
    Me.Panel1.Name = "Panel1"
    Me.Panel1.Size = New Size(264, 100)
    Me.Panel1.TabIndex = 8
    '
    'SetDisciplinesDialog
    '
    Me.AutoScaleDimensions = New SizeF(9.0!, 20.0!)
    Me.AutoScaleMode = AutoScaleMode.Font
    Me.ClientSize = New Size(1178, 744)
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
    CType(Me.MySplitContainer, ISupportInitialize).EndInit()
    Me.MySplitContainer.ResumeLayout(False)
    Me.Panel1.ResumeLayout(False)
    Me.Panel1.PerformLayout()
    Me.ResumeLayout(False)
    Me.PerformLayout()

  End Sub
  Friend WithEvents ClassLabel As Label
  Friend WithEvents ClassComboBox As ComboBox
  Friend WithEvents YearComboBox As ComboBox
  Friend WithEvents YearLabel As Label
  Friend WithEvents GameTypeGroupBox As GroupBox
  Friend WithEvents CompetitionGameTypeRadioButton As RadioButton
  Friend WithEvents TraditionalGameTypeRadioButton As RadioButton
  Friend WithEvents MaleLabel As Label
  Friend WithEvents MySplitContainer As SplitContainer
  Friend WithEvents SprintLabel As Label
  Friend WithEvents SprintNameMaleLabel As Label
  Friend WithEvents SprintUnitMaleLabel As Label
  Friend WithEvents SprintUnitSymbolMaleComboBox As TextBox
  Friend WithEvents SprintMaleComboBox As ComboBox
  Friend WithEvents SprintLowIsBetterMaleCheckBox As CheckBox
  Friend WithEvents Panel1 As Panel
End Class
