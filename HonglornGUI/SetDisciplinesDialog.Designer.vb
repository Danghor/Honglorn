﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
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
    Me.DisciplineSetTypeGroupBox = New System.Windows.Forms.GroupBox()
    Me.CompetitionDisciplineSetRadioButton = New System.Windows.Forms.RadioButton()
    Me.TraditionalDisciplineSetRadioButton = New System.Windows.Forms.RadioButton()
    Me.MaleLabel = New System.Windows.Forms.Label()
    Me.MySplitContainer = New System.Windows.Forms.SplitContainer()
    Me.SprintLabel = New System.Windows.Forms.Label()
    Me.SprintMaleComboBox = New System.Windows.Forms.ComboBox()
    Me.TextBox1 = New System.Windows.Forms.TextBox()
    Me.SprintUnitMaleLabel = New System.Windows.Forms.Label()
    Me.SprintNameMaleLabel = New System.Windows.Forms.Label()
    Me.SprintLowIsBetterMaleCheckBox = New System.Windows.Forms.CheckBox()
    Me.DisciplineSetTypeGroupBox.SuspendLayout()
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
    'DisciplineSetTypeGroupBox
    '
    Me.DisciplineSetTypeGroupBox.Controls.Add(Me.CompetitionDisciplineSetRadioButton)
    Me.DisciplineSetTypeGroupBox.Controls.Add(Me.TraditionalDisciplineSetRadioButton)
    Me.DisciplineSetTypeGroupBox.Enabled = False
    Me.DisciplineSetTypeGroupBox.Location = New System.Drawing.Point(484, 12)
    Me.DisciplineSetTypeGroupBox.Name = "DisciplineSetTypeGroupBox"
    Me.DisciplineSetTypeGroupBox.Size = New System.Drawing.Size(486, 57)
    Me.DisciplineSetTypeGroupBox.TabIndex = 4
    Me.DisciplineSetTypeGroupBox.TabStop = False
    Me.DisciplineSetTypeGroupBox.Text = "Art der Bewertung"
    '
    'CompetitionDisciplineSetRadioButton
    '
    Me.CompetitionDisciplineSetRadioButton.AutoSize = True
    Me.CompetitionDisciplineSetRadioButton.Location = New System.Drawing.Point(241, 25)
    Me.CompetitionDisciplineSetRadioButton.Name = "CompetitionDisciplineSetRadioButton"
    Me.CompetitionDisciplineSetRadioButton.Size = New System.Drawing.Size(235, 24)
    Me.CompetitionDisciplineSetRadioButton.TabIndex = 1
    Me.CompetitionDisciplineSetRadioButton.TabStop = True
    Me.CompetitionDisciplineSetRadioButton.Text = "Wettbewerb (neues System)"
    Me.CompetitionDisciplineSetRadioButton.UseVisualStyleBackColor = True
    '
    'TraditionalDisciplineSetRadioButton
    '
    Me.TraditionalDisciplineSetRadioButton.AutoSize = True
    Me.TraditionalDisciplineSetRadioButton.Location = New System.Drawing.Point(18, 25)
    Me.TraditionalDisciplineSetRadioButton.Name = "TraditionalDisciplineSetRadioButton"
    Me.TraditionalDisciplineSetRadioButton.Size = New System.Drawing.Size(217, 24)
    Me.TraditionalDisciplineSetRadioButton.TabIndex = 0
    Me.TraditionalDisciplineSetRadioButton.TabStop = True
    Me.TraditionalDisciplineSetRadioButton.Text = "Wettkampf (altes System)"
    Me.TraditionalDisciplineSetRadioButton.UseVisualStyleBackColor = True
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
    'SprintLabel
    '
    Me.SprintLabel.AutoSize = True
    Me.SprintLabel.Location = New System.Drawing.Point(12, 52)
    Me.SprintLabel.Name = "SprintLabel"
    Me.SprintLabel.Size = New System.Drawing.Size(51, 20)
    Me.SprintLabel.TabIndex = 1
    Me.SprintLabel.Text = "Sprint"
    '
    'SprintMaleComboBox
    '
    Me.SprintMaleComboBox.FormattingEnabled = True
    Me.SprintMaleComboBox.Location = New System.Drawing.Point(159, 86)
    Me.SprintMaleComboBox.Name = "SprintMaleComboBox"
    Me.SprintMaleComboBox.Size = New System.Drawing.Size(121, 28)
    Me.SprintMaleComboBox.TabIndex = 2
    '
    'TextBox1
    '
    Me.TextBox1.Location = New System.Drawing.Point(159, 120)
    Me.TextBox1.Name = "TextBox1"
    Me.TextBox1.Size = New System.Drawing.Size(121, 26)
    Me.TextBox1.TabIndex = 3
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
    'SprintNameMaleLabel
    '
    Me.SprintNameMaleLabel.AutoSize = True
    Me.SprintNameMaleLabel.Location = New System.Drawing.Point(12, 89)
    Me.SprintNameMaleLabel.Name = "SprintNameMaleLabel"
    Me.SprintNameMaleLabel.Size = New System.Drawing.Size(140, 20)
    Me.SprintNameMaleLabel.TabIndex = 5
    Me.SprintNameMaleLabel.Text = "Name der Disziplin"
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
    'SetDisciplinesDialog
    '
    Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 20.0!)
    Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
    Me.ClientSize = New System.Drawing.Size(1178, 744)
    Me.Controls.Add(Me.MySplitContainer)
    Me.Controls.Add(Me.DisciplineSetTypeGroupBox)
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
    Me.DisciplineSetTypeGroupBox.ResumeLayout(False)
    Me.DisciplineSetTypeGroupBox.PerformLayout()
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
  Friend WithEvents DisciplineSetTypeGroupBox As System.Windows.Forms.GroupBox
  Friend WithEvents CompetitionDisciplineSetRadioButton As System.Windows.Forms.RadioButton
  Friend WithEvents TraditionalDisciplineSetRadioButton As System.Windows.Forms.RadioButton
  Friend WithEvents MaleLabel As System.Windows.Forms.Label
  Friend WithEvents MySplitContainer As System.Windows.Forms.SplitContainer
  Friend WithEvents SprintLabel As System.Windows.Forms.Label
  Friend WithEvents SprintNameMaleLabel As System.Windows.Forms.Label
  Friend WithEvents SprintUnitMaleLabel As System.Windows.Forms.Label
  Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
  Friend WithEvents SprintMaleComboBox As System.Windows.Forms.ComboBox
  Friend WithEvents SprintLowIsBetterMaleCheckBox As System.Windows.Forms.CheckBox
End Class