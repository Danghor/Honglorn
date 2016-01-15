namespace HonglornWinForm {
  partial class DisciplineConfiguration {
    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    /// Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing) {
      if (disposing && (components != null)) {
        components.Dispose();
      }
      base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent() {
      this.yearLabel = new System.Windows.Forms.Label();
      this.yearComboBox = new System.Windows.Forms.ComboBox();
      this.classLabel = new System.Windows.Forms.Label();
      this.classComboBox = new System.Windows.Forms.ComboBox();
      this.gameTypeGroupBox = new System.Windows.Forms.GroupBox();
      this.competitionRadioButton = new System.Windows.Forms.RadioButton();
      this.tradtitionalRadioButton = new System.Windows.Forms.RadioButton();
      this.maleSprintNameLabel = new System.Windows.Forms.Label();
      this.maleGroupBox = new System.Windows.Forms.GroupBox();
      this.maleMiddleDistanceGroupBox = new System.Windows.Forms.GroupBox();
      this.maleMiddleDistanceLowIsBetterCheckBox = new System.Windows.Forms.CheckBox();
      this.maleMiddleDistanceLowIsBetterLabel = new System.Windows.Forms.Label();
      this.maleMiddleDistanceUnitComboBox = new System.Windows.Forms.ComboBox();
      this.maleMiddleDistanceNameComboBox = new System.Windows.Forms.ComboBox();
      this.maleMiddleDistanceNameLabel = new System.Windows.Forms.Label();
      this.maleMiddleDistanceUnitLabel = new System.Windows.Forms.Label();
      this.maleThrowGroupBox = new System.Windows.Forms.GroupBox();
      this.maleThrowLowIsBetterCheckBox = new System.Windows.Forms.CheckBox();
      this.maleThrowLowIsBetterLabel = new System.Windows.Forms.Label();
      this.maleThrowUnitComboBox = new System.Windows.Forms.ComboBox();
      this.maleThrowNameComboBox = new System.Windows.Forms.ComboBox();
      this.maleThrowNameLabel = new System.Windows.Forms.Label();
      this.maleThrowUnitLabel = new System.Windows.Forms.Label();
      this.maleJumpGroupBox = new System.Windows.Forms.GroupBox();
      this.maleJumpLowIsBetterCheckBox = new System.Windows.Forms.CheckBox();
      this.maleJumpLowIsBetterLabel = new System.Windows.Forms.Label();
      this.maleJumpUnitComboBox = new System.Windows.Forms.ComboBox();
      this.maleJumpNameComboBox = new System.Windows.Forms.ComboBox();
      this.maleJumpNameLabel = new System.Windows.Forms.Label();
      this.maleJumpUnitLabel = new System.Windows.Forms.Label();
      this.maleSprintGroupBox = new System.Windows.Forms.GroupBox();
      this.maleSprintElectronicMeasurementRadioButton = new System.Windows.Forms.RadioButton();
      this.maleSprintManualMeasurementRadioButton = new System.Windows.Forms.RadioButton();
      this.maleSprintLowIsBetterCheckBox = new System.Windows.Forms.CheckBox();
      this.maleSprintLowIsBetterLabel = new System.Windows.Forms.Label();
      this.maleSprintMeasurementLabel = new System.Windows.Forms.Label();
      this.maleSprintNameComboBox = new System.Windows.Forms.ComboBox();
      this.maleSprintUnitLabel = new System.Windows.Forms.Label();
      this.maleSprintUnitComboBox = new System.Windows.Forms.ComboBox();
      this.gameTypeGroupBox.SuspendLayout();
      this.maleGroupBox.SuspendLayout();
      this.maleMiddleDistanceGroupBox.SuspendLayout();
      this.maleThrowGroupBox.SuspendLayout();
      this.maleJumpGroupBox.SuspendLayout();
      this.maleSprintGroupBox.SuspendLayout();
      this.SuspendLayout();
      // 
      // yearLabel
      // 
      this.yearLabel.AutoSize = true;
      this.yearLabel.Location = new System.Drawing.Point(13, 13);
      this.yearLabel.Name = "yearLabel";
      this.yearLabel.Size = new System.Drawing.Size(40, 20);
      this.yearLabel.TabIndex = 0;
      this.yearLabel.Text = "Jahr";
      // 
      // yearComboBox
      // 
      this.yearComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
      this.yearComboBox.FormattingEnabled = true;
      this.yearComboBox.Location = new System.Drawing.Point(59, 10);
      this.yearComboBox.Name = "yearComboBox";
      this.yearComboBox.Size = new System.Drawing.Size(121, 28);
      this.yearComboBox.TabIndex = 1;
      // 
      // classLabel
      // 
      this.classLabel.AutoSize = true;
      this.classLabel.Location = new System.Drawing.Point(208, 13);
      this.classLabel.Name = "classLabel";
      this.classLabel.Size = new System.Drawing.Size(101, 20);
      this.classLabel.TabIndex = 2;
      this.classLabel.Text = "Klassenstufe";
      // 
      // classComboBox
      // 
      this.classComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
      this.classComboBox.FormattingEnabled = true;
      this.classComboBox.Location = new System.Drawing.Point(315, 10);
      this.classComboBox.Name = "classComboBox";
      this.classComboBox.Size = new System.Drawing.Size(121, 28);
      this.classComboBox.TabIndex = 3;
      // 
      // gameTypeGroupBox
      // 
      this.gameTypeGroupBox.AutoSize = true;
      this.gameTypeGroupBox.Controls.Add(this.competitionRadioButton);
      this.gameTypeGroupBox.Controls.Add(this.tradtitionalRadioButton);
      this.gameTypeGroupBox.Location = new System.Drawing.Point(17, 52);
      this.gameTypeGroupBox.Name = "gameTypeGroupBox";
      this.gameTypeGroupBox.Size = new System.Drawing.Size(250, 74);
      this.gameTypeGroupBox.TabIndex = 4;
      this.gameTypeGroupBox.TabStop = false;
      this.gameTypeGroupBox.Text = "Art der Bewertung";
      // 
      // competitionRadioButton
      // 
      this.competitionRadioButton.AutoSize = true;
      this.competitionRadioButton.Location = new System.Drawing.Point(124, 25);
      this.competitionRadioButton.Name = "competitionRadioButton";
      this.competitionRadioButton.RightToLeft = System.Windows.Forms.RightToLeft.No;
      this.competitionRadioButton.Size = new System.Drawing.Size(120, 24);
      this.competitionRadioButton.TabIndex = 1;
      this.competitionRadioButton.TabStop = true;
      this.competitionRadioButton.Text = "Wettbewerb";
      this.competitionRadioButton.UseVisualStyleBackColor = true;
      // 
      // tradtitionalRadioButton
      // 
      this.tradtitionalRadioButton.AutoSize = true;
      this.tradtitionalRadioButton.Location = new System.Drawing.Point(6, 25);
      this.tradtitionalRadioButton.Name = "tradtitionalRadioButton";
      this.tradtitionalRadioButton.Size = new System.Drawing.Size(112, 24);
      this.tradtitionalRadioButton.TabIndex = 0;
      this.tradtitionalRadioButton.TabStop = true;
      this.tradtitionalRadioButton.Text = "Wettkampf";
      this.tradtitionalRadioButton.UseVisualStyleBackColor = true;
      // 
      // maleSprintNameLabel
      // 
      this.maleSprintNameLabel.AutoSize = true;
      this.maleSprintNameLabel.Location = new System.Drawing.Point(6, 22);
      this.maleSprintNameLabel.Name = "maleSprintNameLabel";
      this.maleSprintNameLabel.Size = new System.Drawing.Size(140, 20);
      this.maleSprintNameLabel.TabIndex = 7;
      this.maleSprintNameLabel.Text = "Name der Disziplin";
      // 
      // maleGroupBox
      // 
      this.maleGroupBox.AutoSize = true;
      this.maleGroupBox.Controls.Add(this.maleMiddleDistanceGroupBox);
      this.maleGroupBox.Controls.Add(this.maleThrowGroupBox);
      this.maleGroupBox.Controls.Add(this.maleJumpGroupBox);
      this.maleGroupBox.Controls.Add(this.maleSprintGroupBox);
      this.maleGroupBox.Location = new System.Drawing.Point(17, 132);
      this.maleGroupBox.Name = "maleGroupBox";
      this.maleGroupBox.Size = new System.Drawing.Size(1843, 213);
      this.maleGroupBox.TabIndex = 9;
      this.maleGroupBox.TabStop = false;
      this.maleGroupBox.Text = "Männlich";
      // 
      // maleMiddleDistanceGroupBox
      // 
      this.maleMiddleDistanceGroupBox.AutoSize = true;
      this.maleMiddleDistanceGroupBox.Controls.Add(this.maleMiddleDistanceLowIsBetterCheckBox);
      this.maleMiddleDistanceGroupBox.Controls.Add(this.maleMiddleDistanceLowIsBetterLabel);
      this.maleMiddleDistanceGroupBox.Controls.Add(this.maleMiddleDistanceUnitComboBox);
      this.maleMiddleDistanceGroupBox.Controls.Add(this.maleMiddleDistanceNameComboBox);
      this.maleMiddleDistanceGroupBox.Controls.Add(this.maleMiddleDistanceNameLabel);
      this.maleMiddleDistanceGroupBox.Controls.Add(this.maleMiddleDistanceUnitLabel);
      this.maleMiddleDistanceGroupBox.Location = new System.Drawing.Point(1417, 25);
      this.maleMiddleDistanceGroupBox.Name = "maleMiddleDistanceGroupBox";
      this.maleMiddleDistanceGroupBox.Size = new System.Drawing.Size(420, 163);
      this.maleMiddleDistanceGroupBox.TabIndex = 16;
      this.maleMiddleDistanceGroupBox.TabStop = false;
      this.maleMiddleDistanceGroupBox.Text = "Ausdauer";
      // 
      // maleMiddleDistanceLowIsBetterCheckBox
      // 
      this.maleMiddleDistanceLowIsBetterCheckBox.AutoSize = true;
      this.maleMiddleDistanceLowIsBetterCheckBox.Location = new System.Drawing.Point(152, 117);
      this.maleMiddleDistanceLowIsBetterCheckBox.Name = "maleMiddleDistanceLowIsBetterCheckBox";
      this.maleMiddleDistanceLowIsBetterCheckBox.Size = new System.Drawing.Size(22, 21);
      this.maleMiddleDistanceLowIsBetterCheckBox.TabIndex = 14;
      this.maleMiddleDistanceLowIsBetterCheckBox.UseVisualStyleBackColor = true;
      // 
      // maleMiddleDistanceLowIsBetterLabel
      // 
      this.maleMiddleDistanceLowIsBetterLabel.AutoSize = true;
      this.maleMiddleDistanceLowIsBetterLabel.Location = new System.Drawing.Point(6, 116);
      this.maleMiddleDistanceLowIsBetterLabel.Name = "maleMiddleDistanceLowIsBetterLabel";
      this.maleMiddleDistanceLowIsBetterLabel.Size = new System.Drawing.Size(140, 20);
      this.maleMiddleDistanceLowIsBetterLabel.TabIndex = 13;
      this.maleMiddleDistanceLowIsBetterLabel.Text = "Weniger ist besser";
      // 
      // maleMiddleDistanceUnitComboBox
      // 
      this.maleMiddleDistanceUnitComboBox.FormattingEnabled = true;
      this.maleMiddleDistanceUnitComboBox.Location = new System.Drawing.Point(152, 53);
      this.maleMiddleDistanceUnitComboBox.Name = "maleMiddleDistanceUnitComboBox";
      this.maleMiddleDistanceUnitComboBox.Size = new System.Drawing.Size(262, 28);
      this.maleMiddleDistanceUnitComboBox.TabIndex = 10;
      // 
      // maleMiddleDistanceNameComboBox
      // 
      this.maleMiddleDistanceNameComboBox.FormattingEnabled = true;
      this.maleMiddleDistanceNameComboBox.Location = new System.Drawing.Point(152, 19);
      this.maleMiddleDistanceNameComboBox.Name = "maleMiddleDistanceNameComboBox";
      this.maleMiddleDistanceNameComboBox.Size = new System.Drawing.Size(262, 28);
      this.maleMiddleDistanceNameComboBox.TabIndex = 9;
      // 
      // maleMiddleDistanceNameLabel
      // 
      this.maleMiddleDistanceNameLabel.AutoSize = true;
      this.maleMiddleDistanceNameLabel.Location = new System.Drawing.Point(6, 22);
      this.maleMiddleDistanceNameLabel.Name = "maleMiddleDistanceNameLabel";
      this.maleMiddleDistanceNameLabel.Size = new System.Drawing.Size(140, 20);
      this.maleMiddleDistanceNameLabel.TabIndex = 7;
      this.maleMiddleDistanceNameLabel.Text = "Name der Disziplin";
      // 
      // maleMiddleDistanceUnitLabel
      // 
      this.maleMiddleDistanceUnitLabel.AutoSize = true;
      this.maleMiddleDistanceUnitLabel.Location = new System.Drawing.Point(88, 56);
      this.maleMiddleDistanceUnitLabel.Name = "maleMiddleDistanceUnitLabel";
      this.maleMiddleDistanceUnitLabel.Size = new System.Drawing.Size(58, 20);
      this.maleMiddleDistanceUnitLabel.TabIndex = 8;
      this.maleMiddleDistanceUnitLabel.Text = "Einheit";
      // 
      // maleThrowGroupBox
      // 
      this.maleThrowGroupBox.AutoSize = true;
      this.maleThrowGroupBox.Controls.Add(this.maleThrowLowIsBetterCheckBox);
      this.maleThrowGroupBox.Controls.Add(this.maleThrowLowIsBetterLabel);
      this.maleThrowGroupBox.Controls.Add(this.maleThrowUnitComboBox);
      this.maleThrowGroupBox.Controls.Add(this.maleThrowNameComboBox);
      this.maleThrowGroupBox.Controls.Add(this.maleThrowNameLabel);
      this.maleThrowGroupBox.Controls.Add(this.maleThrowUnitLabel);
      this.maleThrowGroupBox.Location = new System.Drawing.Point(991, 25);
      this.maleThrowGroupBox.Name = "maleThrowGroupBox";
      this.maleThrowGroupBox.Size = new System.Drawing.Size(420, 163);
      this.maleThrowGroupBox.TabIndex = 15;
      this.maleThrowGroupBox.TabStop = false;
      this.maleThrowGroupBox.Text = "Wurf";
      // 
      // maleThrowLowIsBetterCheckBox
      // 
      this.maleThrowLowIsBetterCheckBox.AutoSize = true;
      this.maleThrowLowIsBetterCheckBox.Location = new System.Drawing.Point(152, 117);
      this.maleThrowLowIsBetterCheckBox.Name = "maleThrowLowIsBetterCheckBox";
      this.maleThrowLowIsBetterCheckBox.Size = new System.Drawing.Size(22, 21);
      this.maleThrowLowIsBetterCheckBox.TabIndex = 14;
      this.maleThrowLowIsBetterCheckBox.UseVisualStyleBackColor = true;
      // 
      // maleThrowLowIsBetterLabel
      // 
      this.maleThrowLowIsBetterLabel.AutoSize = true;
      this.maleThrowLowIsBetterLabel.Location = new System.Drawing.Point(6, 116);
      this.maleThrowLowIsBetterLabel.Name = "maleThrowLowIsBetterLabel";
      this.maleThrowLowIsBetterLabel.Size = new System.Drawing.Size(140, 20);
      this.maleThrowLowIsBetterLabel.TabIndex = 13;
      this.maleThrowLowIsBetterLabel.Text = "Weniger ist besser";
      // 
      // maleThrowUnitComboBox
      // 
      this.maleThrowUnitComboBox.FormattingEnabled = true;
      this.maleThrowUnitComboBox.Location = new System.Drawing.Point(152, 53);
      this.maleThrowUnitComboBox.Name = "maleThrowUnitComboBox";
      this.maleThrowUnitComboBox.Size = new System.Drawing.Size(262, 28);
      this.maleThrowUnitComboBox.TabIndex = 10;
      // 
      // maleThrowNameComboBox
      // 
      this.maleThrowNameComboBox.FormattingEnabled = true;
      this.maleThrowNameComboBox.Location = new System.Drawing.Point(152, 19);
      this.maleThrowNameComboBox.Name = "maleThrowNameComboBox";
      this.maleThrowNameComboBox.Size = new System.Drawing.Size(262, 28);
      this.maleThrowNameComboBox.TabIndex = 9;
      // 
      // maleThrowNameLabel
      // 
      this.maleThrowNameLabel.AutoSize = true;
      this.maleThrowNameLabel.Location = new System.Drawing.Point(6, 22);
      this.maleThrowNameLabel.Name = "maleThrowNameLabel";
      this.maleThrowNameLabel.Size = new System.Drawing.Size(140, 20);
      this.maleThrowNameLabel.TabIndex = 7;
      this.maleThrowNameLabel.Text = "Name der Disziplin";
      // 
      // maleThrowUnitLabel
      // 
      this.maleThrowUnitLabel.AutoSize = true;
      this.maleThrowUnitLabel.Location = new System.Drawing.Point(88, 56);
      this.maleThrowUnitLabel.Name = "maleThrowUnitLabel";
      this.maleThrowUnitLabel.Size = new System.Drawing.Size(58, 20);
      this.maleThrowUnitLabel.TabIndex = 8;
      this.maleThrowUnitLabel.Text = "Einheit";
      // 
      // maleJumpGroupBox
      // 
      this.maleJumpGroupBox.AutoSize = true;
      this.maleJumpGroupBox.Controls.Add(this.maleJumpLowIsBetterCheckBox);
      this.maleJumpGroupBox.Controls.Add(this.maleJumpLowIsBetterLabel);
      this.maleJumpGroupBox.Controls.Add(this.maleJumpUnitComboBox);
      this.maleJumpGroupBox.Controls.Add(this.maleJumpNameComboBox);
      this.maleJumpGroupBox.Controls.Add(this.maleJumpNameLabel);
      this.maleJumpGroupBox.Controls.Add(this.maleJumpUnitLabel);
      this.maleJumpGroupBox.Location = new System.Drawing.Point(565, 25);
      this.maleJumpGroupBox.Name = "maleJumpGroupBox";
      this.maleJumpGroupBox.Size = new System.Drawing.Size(420, 163);
      this.maleJumpGroupBox.TabIndex = 10;
      this.maleJumpGroupBox.TabStop = false;
      this.maleJumpGroupBox.Text = "Sprung";
      // 
      // maleJumpLowIsBetterCheckBox
      // 
      this.maleJumpLowIsBetterCheckBox.AutoSize = true;
      this.maleJumpLowIsBetterCheckBox.Location = new System.Drawing.Point(152, 117);
      this.maleJumpLowIsBetterCheckBox.Name = "maleJumpLowIsBetterCheckBox";
      this.maleJumpLowIsBetterCheckBox.Size = new System.Drawing.Size(22, 21);
      this.maleJumpLowIsBetterCheckBox.TabIndex = 14;
      this.maleJumpLowIsBetterCheckBox.UseVisualStyleBackColor = true;
      // 
      // maleJumpLowIsBetterLabel
      // 
      this.maleJumpLowIsBetterLabel.AutoSize = true;
      this.maleJumpLowIsBetterLabel.Location = new System.Drawing.Point(6, 116);
      this.maleJumpLowIsBetterLabel.Name = "maleJumpLowIsBetterLabel";
      this.maleJumpLowIsBetterLabel.Size = new System.Drawing.Size(140, 20);
      this.maleJumpLowIsBetterLabel.TabIndex = 13;
      this.maleJumpLowIsBetterLabel.Text = "Weniger ist besser";
      // 
      // maleJumpUnitComboBox
      // 
      this.maleJumpUnitComboBox.FormattingEnabled = true;
      this.maleJumpUnitComboBox.Location = new System.Drawing.Point(152, 53);
      this.maleJumpUnitComboBox.Name = "maleJumpUnitComboBox";
      this.maleJumpUnitComboBox.Size = new System.Drawing.Size(262, 28);
      this.maleJumpUnitComboBox.TabIndex = 10;
      // 
      // maleJumpNameComboBox
      // 
      this.maleJumpNameComboBox.FormattingEnabled = true;
      this.maleJumpNameComboBox.Location = new System.Drawing.Point(152, 19);
      this.maleJumpNameComboBox.Name = "maleJumpNameComboBox";
      this.maleJumpNameComboBox.Size = new System.Drawing.Size(262, 28);
      this.maleJumpNameComboBox.TabIndex = 9;
      // 
      // maleJumpNameLabel
      // 
      this.maleJumpNameLabel.AutoSize = true;
      this.maleJumpNameLabel.Location = new System.Drawing.Point(6, 22);
      this.maleJumpNameLabel.Name = "maleJumpNameLabel";
      this.maleJumpNameLabel.Size = new System.Drawing.Size(140, 20);
      this.maleJumpNameLabel.TabIndex = 7;
      this.maleJumpNameLabel.Text = "Name der Disziplin";
      // 
      // maleJumpUnitLabel
      // 
      this.maleJumpUnitLabel.AutoSize = true;
      this.maleJumpUnitLabel.Location = new System.Drawing.Point(88, 56);
      this.maleJumpUnitLabel.Name = "maleJumpUnitLabel";
      this.maleJumpUnitLabel.Size = new System.Drawing.Size(58, 20);
      this.maleJumpUnitLabel.TabIndex = 8;
      this.maleJumpUnitLabel.Text = "Einheit";
      // 
      // maleSprintGroupBox
      // 
      this.maleSprintGroupBox.AutoSize = true;
      this.maleSprintGroupBox.Controls.Add(this.maleSprintElectronicMeasurementRadioButton);
      this.maleSprintGroupBox.Controls.Add(this.maleSprintManualMeasurementRadioButton);
      this.maleSprintGroupBox.Controls.Add(this.maleSprintLowIsBetterCheckBox);
      this.maleSprintGroupBox.Controls.Add(this.maleSprintLowIsBetterLabel);
      this.maleSprintGroupBox.Controls.Add(this.maleSprintMeasurementLabel);
      this.maleSprintGroupBox.Controls.Add(this.maleSprintUnitComboBox);
      this.maleSprintGroupBox.Controls.Add(this.maleSprintNameComboBox);
      this.maleSprintGroupBox.Controls.Add(this.maleSprintNameLabel);
      this.maleSprintGroupBox.Controls.Add(this.maleSprintUnitLabel);
      this.maleSprintGroupBox.Location = new System.Drawing.Point(6, 25);
      this.maleSprintGroupBox.Name = "maleSprintGroupBox";
      this.maleSprintGroupBox.Size = new System.Drawing.Size(553, 163);
      this.maleSprintGroupBox.TabIndex = 9;
      this.maleSprintGroupBox.TabStop = false;
      this.maleSprintGroupBox.Text = "Sprint";
      // 
      // maleSprintElectronicMeasurementRadioButton
      // 
      this.maleSprintElectronicMeasurementRadioButton.AutoSize = true;
      this.maleSprintElectronicMeasurementRadioButton.Location = new System.Drawing.Point(321, 87);
      this.maleSprintElectronicMeasurementRadioButton.Name = "maleSprintElectronicMeasurementRadioButton";
      this.maleSprintElectronicMeasurementRadioButton.Size = new System.Drawing.Size(226, 24);
      this.maleSprintElectronicMeasurementRadioButton.TabIndex = 16;
      this.maleSprintElectronicMeasurementRadioButton.TabStop = true;
      this.maleSprintElectronicMeasurementRadioButton.Text = "Elektronische Zeitmessung";
      this.maleSprintElectronicMeasurementRadioButton.UseVisualStyleBackColor = true;
      // 
      // maleSprintManualMeasurementRadioButton
      // 
      this.maleSprintManualMeasurementRadioButton.AutoSize = true;
      this.maleSprintManualMeasurementRadioButton.Location = new System.Drawing.Point(152, 87);
      this.maleSprintManualMeasurementRadioButton.Name = "maleSprintManualMeasurementRadioButton";
      this.maleSprintManualMeasurementRadioButton.Size = new System.Drawing.Size(163, 24);
      this.maleSprintManualMeasurementRadioButton.TabIndex = 15;
      this.maleSprintManualMeasurementRadioButton.TabStop = true;
      this.maleSprintManualMeasurementRadioButton.Text = "Handzeitmessung";
      this.maleSprintManualMeasurementRadioButton.UseVisualStyleBackColor = true;
      // 
      // maleSprintLowIsBetterCheckBox
      // 
      this.maleSprintLowIsBetterCheckBox.AutoSize = true;
      this.maleSprintLowIsBetterCheckBox.Location = new System.Drawing.Point(152, 117);
      this.maleSprintLowIsBetterCheckBox.Name = "maleSprintLowIsBetterCheckBox";
      this.maleSprintLowIsBetterCheckBox.Size = new System.Drawing.Size(22, 21);
      this.maleSprintLowIsBetterCheckBox.TabIndex = 14;
      this.maleSprintLowIsBetterCheckBox.UseVisualStyleBackColor = true;
      // 
      // maleSprintLowIsBetterLabel
      // 
      this.maleSprintLowIsBetterLabel.AutoSize = true;
      this.maleSprintLowIsBetterLabel.Location = new System.Drawing.Point(6, 118);
      this.maleSprintLowIsBetterLabel.Name = "maleSprintLowIsBetterLabel";
      this.maleSprintLowIsBetterLabel.Size = new System.Drawing.Size(140, 20);
      this.maleSprintLowIsBetterLabel.TabIndex = 13;
      this.maleSprintLowIsBetterLabel.Text = "Weniger ist besser";
      // 
      // maleSprintMeasurementLabel
      // 
      this.maleSprintMeasurementLabel.AutoSize = true;
      this.maleSprintMeasurementLabel.Location = new System.Drawing.Point(45, 89);
      this.maleSprintMeasurementLabel.Name = "maleSprintMeasurementLabel";
      this.maleSprintMeasurementLabel.Size = new System.Drawing.Size(101, 20);
      this.maleSprintMeasurementLabel.TabIndex = 11;
      this.maleSprintMeasurementLabel.Text = "Zeitmessung";
      // 
      // maleSprintNameComboBox
      // 
      this.maleSprintNameComboBox.FormattingEnabled = true;
      this.maleSprintNameComboBox.Location = new System.Drawing.Point(152, 19);
      this.maleSprintNameComboBox.Name = "maleSprintNameComboBox";
      this.maleSprintNameComboBox.Size = new System.Drawing.Size(262, 28);
      this.maleSprintNameComboBox.TabIndex = 9;
      // 
      // maleSprintUnitLabel
      // 
      this.maleSprintUnitLabel.AutoSize = true;
      this.maleSprintUnitLabel.Location = new System.Drawing.Point(88, 56);
      this.maleSprintUnitLabel.Name = "maleSprintUnitLabel";
      this.maleSprintUnitLabel.Size = new System.Drawing.Size(58, 20);
      this.maleSprintUnitLabel.TabIndex = 8;
      this.maleSprintUnitLabel.Text = "Einheit";
      // 
      // maleSprintUnitComboBox
      // 
      this.maleSprintUnitComboBox.FormattingEnabled = true;
      this.maleSprintUnitComboBox.Location = new System.Drawing.Point(152, 53);
      this.maleSprintUnitComboBox.Name = "maleSprintUnitComboBox";
      this.maleSprintUnitComboBox.Size = new System.Drawing.Size(262, 28);
      this.maleSprintUnitComboBox.TabIndex = 10;
      // 
      // DisciplineConfiguration
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.AutoSize = true;
      this.ClientSize = new System.Drawing.Size(1884, 652);
      this.Controls.Add(this.maleGroupBox);
      this.Controls.Add(this.gameTypeGroupBox);
      this.Controls.Add(this.classComboBox);
      this.Controls.Add(this.classLabel);
      this.Controls.Add(this.yearComboBox);
      this.Controls.Add(this.yearLabel);
      this.Name = "DisciplineConfiguration";
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
      this.Text = "DisciplineConfiguration";
      this.gameTypeGroupBox.ResumeLayout(false);
      this.gameTypeGroupBox.PerformLayout();
      this.maleGroupBox.ResumeLayout(false);
      this.maleGroupBox.PerformLayout();
      this.maleMiddleDistanceGroupBox.ResumeLayout(false);
      this.maleMiddleDistanceGroupBox.PerformLayout();
      this.maleThrowGroupBox.ResumeLayout(false);
      this.maleThrowGroupBox.PerformLayout();
      this.maleJumpGroupBox.ResumeLayout(false);
      this.maleJumpGroupBox.PerformLayout();
      this.maleSprintGroupBox.ResumeLayout(false);
      this.maleSprintGroupBox.PerformLayout();
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.Label yearLabel;
    private System.Windows.Forms.ComboBox yearComboBox;
    private System.Windows.Forms.Label classLabel;
    private System.Windows.Forms.ComboBox classComboBox;
    private System.Windows.Forms.GroupBox gameTypeGroupBox;
    private System.Windows.Forms.RadioButton tradtitionalRadioButton;
    private System.Windows.Forms.RadioButton competitionRadioButton;
    private System.Windows.Forms.Label maleSprintNameLabel;
    private System.Windows.Forms.GroupBox maleGroupBox;
    private System.Windows.Forms.GroupBox maleSprintGroupBox;
    private System.Windows.Forms.ComboBox maleSprintNameComboBox;
    private System.Windows.Forms.RadioButton maleSprintElectronicMeasurementRadioButton;
    private System.Windows.Forms.RadioButton maleSprintManualMeasurementRadioButton;
    private System.Windows.Forms.CheckBox maleSprintLowIsBetterCheckBox;
    private System.Windows.Forms.Label maleSprintLowIsBetterLabel;
    private System.Windows.Forms.Label maleSprintMeasurementLabel;
    private System.Windows.Forms.GroupBox maleMiddleDistanceGroupBox;
    private System.Windows.Forms.CheckBox maleMiddleDistanceLowIsBetterCheckBox;
    private System.Windows.Forms.Label maleMiddleDistanceLowIsBetterLabel;
    private System.Windows.Forms.ComboBox maleMiddleDistanceUnitComboBox;
    private System.Windows.Forms.ComboBox maleMiddleDistanceNameComboBox;
    private System.Windows.Forms.Label maleMiddleDistanceNameLabel;
    private System.Windows.Forms.Label maleMiddleDistanceUnitLabel;
    private System.Windows.Forms.GroupBox maleThrowGroupBox;
    private System.Windows.Forms.CheckBox maleThrowLowIsBetterCheckBox;
    private System.Windows.Forms.Label maleThrowLowIsBetterLabel;
    private System.Windows.Forms.ComboBox maleThrowUnitComboBox;
    private System.Windows.Forms.ComboBox maleThrowNameComboBox;
    private System.Windows.Forms.Label maleThrowNameLabel;
    private System.Windows.Forms.Label maleThrowUnitLabel;
    private System.Windows.Forms.GroupBox maleJumpGroupBox;
    private System.Windows.Forms.CheckBox maleJumpLowIsBetterCheckBox;
    private System.Windows.Forms.Label maleJumpLowIsBetterLabel;
    private System.Windows.Forms.ComboBox maleJumpUnitComboBox;
    private System.Windows.Forms.ComboBox maleJumpNameComboBox;
    private System.Windows.Forms.Label maleJumpNameLabel;
    private System.Windows.Forms.Label maleJumpUnitLabel;
    private System.Windows.Forms.ComboBox maleSprintUnitComboBox;
    private System.Windows.Forms.Label maleSprintUnitLabel;
  }
}