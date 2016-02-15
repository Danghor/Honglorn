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
      this.maleGroupBox = new System.Windows.Forms.GroupBox();
      this.maleMiddleDistanceComboBox = new System.Windows.Forms.ComboBox();
      this.maleThrowComboBox = new System.Windows.Forms.ComboBox();
      this.maleJumpComboBox = new System.Windows.Forms.ComboBox();
      this.maleMiddleDistanceLabel = new System.Windows.Forms.Label();
      this.maleThrowLabel = new System.Windows.Forms.Label();
      this.maleJumpLabel = new System.Windows.Forms.Label();
      this.maleSprintComboBox = new System.Windows.Forms.ComboBox();
      this.maleSprintLabel = new System.Windows.Forms.Label();
      this.femaleGroupBox = new System.Windows.Forms.GroupBox();
      this.femaleMiddleDistanceComboBox = new System.Windows.Forms.ComboBox();
      this.femaleThrowComboBox = new System.Windows.Forms.ComboBox();
      this.femaleJumpComboBox = new System.Windows.Forms.ComboBox();
      this.femaleMiddleDistanceLabel = new System.Windows.Forms.Label();
      this.femaleThrowLabel = new System.Windows.Forms.Label();
      this.femaleJumpLabel = new System.Windows.Forms.Label();
      this.femaleSprintComboBox = new System.Windows.Forms.ComboBox();
      this.femaleSprintLabel = new System.Windows.Forms.Label();
      this.gameTypeGroupBox.SuspendLayout();
      this.maleGroupBox.SuspendLayout();
      this.femaleGroupBox.SuspendLayout();
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
      this.yearComboBox.DropDown += new System.EventHandler(this.yearComboBox_DropDown);
      this.yearComboBox.SelectedValueChanged += new System.EventHandler(this.yearComboBox_SelectedValueChanged);
      // 
      // classLabel
      // 
      this.classLabel.AutoSize = true;
      this.classLabel.Location = new System.Drawing.Point(250, 13);
      this.classLabel.Name = "classLabel";
      this.classLabel.Size = new System.Drawing.Size(101, 20);
      this.classLabel.TabIndex = 2;
      this.classLabel.Text = "Klassenstufe";
      // 
      // classComboBox
      // 
      this.classComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
      this.classComboBox.Enabled = false;
      this.classComboBox.FormattingEnabled = true;
      this.classComboBox.Location = new System.Drawing.Point(357, 10);
      this.classComboBox.Name = "classComboBox";
      this.classComboBox.Size = new System.Drawing.Size(121, 28);
      this.classComboBox.TabIndex = 3;
      this.classComboBox.SelectedValueChanged += new System.EventHandler(this.classComboBox_SelectedValueChanged);
      // 
      // gameTypeGroupBox
      // 
      this.gameTypeGroupBox.AutoSize = true;
      this.gameTypeGroupBox.Controls.Add(this.competitionRadioButton);
      this.gameTypeGroupBox.Controls.Add(this.tradtitionalRadioButton);
      this.gameTypeGroupBox.Enabled = false;
      this.gameTypeGroupBox.Location = new System.Drawing.Point(17, 44);
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
      this.competitionRadioButton.CheckedChanged += new System.EventHandler(this.radioButtons_CheckedChanged);
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
      this.tradtitionalRadioButton.CheckedChanged += new System.EventHandler(this.radioButtons_CheckedChanged);
      // 
      // maleGroupBox
      // 
      this.maleGroupBox.Controls.Add(this.maleMiddleDistanceComboBox);
      this.maleGroupBox.Controls.Add(this.maleThrowComboBox);
      this.maleGroupBox.Controls.Add(this.maleJumpComboBox);
      this.maleGroupBox.Controls.Add(this.maleMiddleDistanceLabel);
      this.maleGroupBox.Controls.Add(this.maleThrowLabel);
      this.maleGroupBox.Controls.Add(this.maleJumpLabel);
      this.maleGroupBox.Controls.Add(this.maleSprintComboBox);
      this.maleGroupBox.Controls.Add(this.maleSprintLabel);
      this.maleGroupBox.Enabled = false;
      this.maleGroupBox.Location = new System.Drawing.Point(17, 125);
      this.maleGroupBox.Name = "maleGroupBox";
      this.maleGroupBox.Size = new System.Drawing.Size(461, 163);
      this.maleGroupBox.TabIndex = 5;
      this.maleGroupBox.TabStop = false;
      this.maleGroupBox.Text = "Männlich";
      // 
      // maleMiddleDistanceComboBox
      // 
      this.maleMiddleDistanceComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
      this.maleMiddleDistanceComboBox.FormattingEnabled = true;
      this.maleMiddleDistanceComboBox.Location = new System.Drawing.Point(98, 127);
      this.maleMiddleDistanceComboBox.Name = "maleMiddleDistanceComboBox";
      this.maleMiddleDistanceComboBox.Size = new System.Drawing.Size(357, 28);
      this.maleMiddleDistanceComboBox.TabIndex = 7;
      // 
      // maleThrowComboBox
      // 
      this.maleThrowComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
      this.maleThrowComboBox.FormattingEnabled = true;
      this.maleThrowComboBox.Location = new System.Drawing.Point(98, 93);
      this.maleThrowComboBox.Name = "maleThrowComboBox";
      this.maleThrowComboBox.Size = new System.Drawing.Size(357, 28);
      this.maleThrowComboBox.TabIndex = 6;
      // 
      // maleJumpComboBox
      // 
      this.maleJumpComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
      this.maleJumpComboBox.FormattingEnabled = true;
      this.maleJumpComboBox.Location = new System.Drawing.Point(98, 59);
      this.maleJumpComboBox.Name = "maleJumpComboBox";
      this.maleJumpComboBox.Size = new System.Drawing.Size(357, 28);
      this.maleJumpComboBox.TabIndex = 5;
      // 
      // maleMiddleDistanceLabel
      // 
      this.maleMiddleDistanceLabel.AutoSize = true;
      this.maleMiddleDistanceLabel.Location = new System.Drawing.Point(6, 130);
      this.maleMiddleDistanceLabel.Name = "maleMiddleDistanceLabel";
      this.maleMiddleDistanceLabel.Size = new System.Drawing.Size(78, 20);
      this.maleMiddleDistanceLabel.TabIndex = 4;
      this.maleMiddleDistanceLabel.Text = "Ausdauer";
      // 
      // maleThrowLabel
      // 
      this.maleThrowLabel.AutoSize = true;
      this.maleThrowLabel.Location = new System.Drawing.Point(6, 96);
      this.maleThrowLabel.Name = "maleThrowLabel";
      this.maleThrowLabel.Size = new System.Drawing.Size(43, 20);
      this.maleThrowLabel.TabIndex = 3;
      this.maleThrowLabel.Text = "Wurf";
      // 
      // maleJumpLabel
      // 
      this.maleJumpLabel.AutoSize = true;
      this.maleJumpLabel.Location = new System.Drawing.Point(6, 62);
      this.maleJumpLabel.Name = "maleJumpLabel";
      this.maleJumpLabel.Size = new System.Drawing.Size(61, 20);
      this.maleJumpLabel.TabIndex = 2;
      this.maleJumpLabel.Text = "Sprung";
      // 
      // maleSprintComboBox
      // 
      this.maleSprintComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
      this.maleSprintComboBox.FormattingEnabled = true;
      this.maleSprintComboBox.Location = new System.Drawing.Point(98, 25);
      this.maleSprintComboBox.Name = "maleSprintComboBox";
      this.maleSprintComboBox.Size = new System.Drawing.Size(357, 28);
      this.maleSprintComboBox.TabIndex = 1;
      // 
      // maleSprintLabel
      // 
      this.maleSprintLabel.AutoSize = true;
      this.maleSprintLabel.Location = new System.Drawing.Point(6, 28);
      this.maleSprintLabel.Name = "maleSprintLabel";
      this.maleSprintLabel.Size = new System.Drawing.Size(51, 20);
      this.maleSprintLabel.TabIndex = 0;
      this.maleSprintLabel.Text = "Sprint";
      // 
      // femaleGroupBox
      // 
      this.femaleGroupBox.Controls.Add(this.femaleMiddleDistanceComboBox);
      this.femaleGroupBox.Controls.Add(this.femaleThrowComboBox);
      this.femaleGroupBox.Controls.Add(this.femaleJumpComboBox);
      this.femaleGroupBox.Controls.Add(this.femaleMiddleDistanceLabel);
      this.femaleGroupBox.Controls.Add(this.femaleThrowLabel);
      this.femaleGroupBox.Controls.Add(this.femaleJumpLabel);
      this.femaleGroupBox.Controls.Add(this.femaleSprintComboBox);
      this.femaleGroupBox.Controls.Add(this.femaleSprintLabel);
      this.femaleGroupBox.Enabled = false;
      this.femaleGroupBox.Location = new System.Drawing.Point(17, 294);
      this.femaleGroupBox.Name = "femaleGroupBox";
      this.femaleGroupBox.Size = new System.Drawing.Size(461, 163);
      this.femaleGroupBox.TabIndex = 6;
      this.femaleGroupBox.TabStop = false;
      this.femaleGroupBox.Text = "Weiblich";
      // 
      // femaleMiddleDistanceComboBox
      // 
      this.femaleMiddleDistanceComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
      this.femaleMiddleDistanceComboBox.FormattingEnabled = true;
      this.femaleMiddleDistanceComboBox.Location = new System.Drawing.Point(98, 127);
      this.femaleMiddleDistanceComboBox.Name = "femaleMiddleDistanceComboBox";
      this.femaleMiddleDistanceComboBox.Size = new System.Drawing.Size(357, 28);
      this.femaleMiddleDistanceComboBox.TabIndex = 7;
      // 
      // femaleThrowComboBox
      // 
      this.femaleThrowComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
      this.femaleThrowComboBox.FormattingEnabled = true;
      this.femaleThrowComboBox.Location = new System.Drawing.Point(98, 93);
      this.femaleThrowComboBox.Name = "femaleThrowComboBox";
      this.femaleThrowComboBox.Size = new System.Drawing.Size(357, 28);
      this.femaleThrowComboBox.TabIndex = 6;
      // 
      // femaleJumpComboBox
      // 
      this.femaleJumpComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
      this.femaleJumpComboBox.FormattingEnabled = true;
      this.femaleJumpComboBox.Location = new System.Drawing.Point(98, 59);
      this.femaleJumpComboBox.Name = "femaleJumpComboBox";
      this.femaleJumpComboBox.Size = new System.Drawing.Size(357, 28);
      this.femaleJumpComboBox.TabIndex = 5;
      // 
      // femaleMiddleDistanceLabel
      // 
      this.femaleMiddleDistanceLabel.AutoSize = true;
      this.femaleMiddleDistanceLabel.Location = new System.Drawing.Point(6, 130);
      this.femaleMiddleDistanceLabel.Name = "femaleMiddleDistanceLabel";
      this.femaleMiddleDistanceLabel.Size = new System.Drawing.Size(78, 20);
      this.femaleMiddleDistanceLabel.TabIndex = 4;
      this.femaleMiddleDistanceLabel.Text = "Ausdauer";
      // 
      // femaleThrowLabel
      // 
      this.femaleThrowLabel.AutoSize = true;
      this.femaleThrowLabel.Location = new System.Drawing.Point(6, 96);
      this.femaleThrowLabel.Name = "femaleThrowLabel";
      this.femaleThrowLabel.Size = new System.Drawing.Size(43, 20);
      this.femaleThrowLabel.TabIndex = 3;
      this.femaleThrowLabel.Text = "Wurf";
      // 
      // femaleJumpLabel
      // 
      this.femaleJumpLabel.AutoSize = true;
      this.femaleJumpLabel.Location = new System.Drawing.Point(6, 62);
      this.femaleJumpLabel.Name = "femaleJumpLabel";
      this.femaleJumpLabel.Size = new System.Drawing.Size(61, 20);
      this.femaleJumpLabel.TabIndex = 2;
      this.femaleJumpLabel.Text = "Sprung";
      // 
      // femaleSprintComboBox
      // 
      this.femaleSprintComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
      this.femaleSprintComboBox.FormattingEnabled = true;
      this.femaleSprintComboBox.Location = new System.Drawing.Point(98, 25);
      this.femaleSprintComboBox.Name = "femaleSprintComboBox";
      this.femaleSprintComboBox.Size = new System.Drawing.Size(357, 28);
      this.femaleSprintComboBox.TabIndex = 1;
      // 
      // femaleSprintLabel
      // 
      this.femaleSprintLabel.AutoSize = true;
      this.femaleSprintLabel.Location = new System.Drawing.Point(6, 28);
      this.femaleSprintLabel.Name = "femaleSprintLabel";
      this.femaleSprintLabel.Size = new System.Drawing.Size(51, 20);
      this.femaleSprintLabel.TabIndex = 0;
      this.femaleSprintLabel.Text = "Sprint";
      // 
      // DisciplineConfiguration
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.AutoSize = true;
      this.ClientSize = new System.Drawing.Size(500, 482);
      this.Controls.Add(this.femaleGroupBox);
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
      this.femaleGroupBox.ResumeLayout(false);
      this.femaleGroupBox.PerformLayout();
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
    private System.Windows.Forms.GroupBox maleGroupBox;
    private System.Windows.Forms.ComboBox maleMiddleDistanceComboBox;
    private System.Windows.Forms.ComboBox maleThrowComboBox;
    private System.Windows.Forms.ComboBox maleJumpComboBox;
    private System.Windows.Forms.Label maleMiddleDistanceLabel;
    private System.Windows.Forms.Label maleThrowLabel;
    private System.Windows.Forms.Label maleJumpLabel;
    private System.Windows.Forms.ComboBox maleSprintComboBox;
    private System.Windows.Forms.Label maleSprintLabel;
    private System.Windows.Forms.GroupBox femaleGroupBox;
    private System.Windows.Forms.ComboBox femaleMiddleDistanceComboBox;
    private System.Windows.Forms.ComboBox femaleThrowComboBox;
    private System.Windows.Forms.ComboBox femaleJumpComboBox;
    private System.Windows.Forms.Label femaleMiddleDistanceLabel;
    private System.Windows.Forms.Label femaleThrowLabel;
    private System.Windows.Forms.Label femaleJumpLabel;
    private System.Windows.Forms.ComboBox femaleSprintComboBox;
    private System.Windows.Forms.Label femaleSprintLabel;
  }
}