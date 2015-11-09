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
      this.maleLabel = new System.Windows.Forms.Label();
      this.gameTypeGroupBox.SuspendLayout();
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
      this.classComboBox.Location = new System.Drawing.Point(316, 10);
      this.classComboBox.Name = "classComboBox";
      this.classComboBox.Size = new System.Drawing.Size(121, 28);
      this.classComboBox.TabIndex = 3;
      // 
      // gameTypeGroupBox
      // 
      this.gameTypeGroupBox.Controls.Add(this.competitionRadioButton);
      this.gameTypeGroupBox.Controls.Add(this.tradtitionalRadioButton);
      this.gameTypeGroupBox.Location = new System.Drawing.Point(17, 52);
      this.gameTypeGroupBox.Name = "gameTypeGroupBox";
      this.gameTypeGroupBox.Size = new System.Drawing.Size(246, 61);
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
      // maleLabel
      // 
      this.maleLabel.AutoSize = true;
      this.maleLabel.Location = new System.Drawing.Point(17, 120);
      this.maleLabel.Name = "maleLabel";
      this.maleLabel.Size = new System.Drawing.Size(72, 20);
      this.maleLabel.TabIndex = 5;
      this.maleLabel.Text = "Männlich";
      // 
      // DisciplineConfiguration
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(1109, 587);
      this.Controls.Add(this.maleLabel);
      this.Controls.Add(this.gameTypeGroupBox);
      this.Controls.Add(this.classComboBox);
      this.Controls.Add(this.classLabel);
      this.Controls.Add(this.yearComboBox);
      this.Controls.Add(this.yearLabel);
      this.Name = "DisciplineConfiguration";
      this.Text = "DisciplineConfiguration";
      this.gameTypeGroupBox.ResumeLayout(false);
      this.gameTypeGroupBox.PerformLayout();
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
    private System.Windows.Forms.Label maleLabel;
  }
}