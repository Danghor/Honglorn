namespace HonglornWinForm {
  partial class CompetitionDisciplinesConfiguration {
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
      this.disciplineListBox = new System.Windows.Forms.ListBox();
      this.typeLabel = new System.Windows.Forms.Label();
      this.nameLabel = new System.Windows.Forms.Label();
      this.unitLabel = new System.Windows.Forms.Label();
      this.lowIsBetterLabel = new System.Windows.Forms.Label();
      this.addButton = new System.Windows.Forms.Button();
      this.deleteButton = new System.Windows.Forms.Button();
      this.typeComboBox = new System.Windows.Forms.ComboBox();
      this.nameTextBox = new System.Windows.Forms.TextBox();
      this.unitTextBox = new System.Windows.Forms.TextBox();
      this.lowIsBetterCheckBox = new System.Windows.Forms.CheckBox();
      this.SuspendLayout();
      // 
      // disciplineListBox
      // 
      this.disciplineListBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
      this.disciplineListBox.FormattingEnabled = true;
      this.disciplineListBox.ItemHeight = 20;
      this.disciplineListBox.Location = new System.Drawing.Point(12, 12);
      this.disciplineListBox.Name = "disciplineListBox";
      this.disciplineListBox.Size = new System.Drawing.Size(301, 184);
      this.disciplineListBox.TabIndex = 0;
      this.disciplineListBox.SelectedIndexChanged += new System.EventHandler(this.disciplineListBox_SelectedIndexChanged);
      // 
      // typeLabel
      // 
      this.typeLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.typeLabel.AutoSize = true;
      this.typeLabel.Location = new System.Drawing.Point(319, 12);
      this.typeLabel.Name = "typeLabel";
      this.typeLabel.Size = new System.Drawing.Size(30, 20);
      this.typeLabel.TabIndex = 1;
      this.typeLabel.Text = "Art";
      // 
      // nameLabel
      // 
      this.nameLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.nameLabel.AutoSize = true;
      this.nameLabel.Location = new System.Drawing.Point(319, 46);
      this.nameLabel.Name = "nameLabel";
      this.nameLabel.Size = new System.Drawing.Size(51, 20);
      this.nameLabel.TabIndex = 2;
      this.nameLabel.Text = "Name";
      // 
      // unitLabel
      // 
      this.unitLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.unitLabel.AutoSize = true;
      this.unitLabel.Location = new System.Drawing.Point(319, 78);
      this.unitLabel.Name = "unitLabel";
      this.unitLabel.Size = new System.Drawing.Size(58, 20);
      this.unitLabel.TabIndex = 3;
      this.unitLabel.Text = "Einheit";
      // 
      // lowIsBetterLabel
      // 
      this.lowIsBetterLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.lowIsBetterLabel.AutoSize = true;
      this.lowIsBetterLabel.Location = new System.Drawing.Point(319, 106);
      this.lowIsBetterLabel.Name = "lowIsBetterLabel";
      this.lowIsBetterLabel.Size = new System.Drawing.Size(140, 20);
      this.lowIsBetterLabel.TabIndex = 4;
      this.lowIsBetterLabel.Text = "Weniger ist besser";
      // 
      // addButton
      // 
      this.addButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
      this.addButton.Location = new System.Drawing.Point(12, 210);
      this.addButton.Name = "addButton";
      this.addButton.Size = new System.Drawing.Size(301, 42);
      this.addButton.TabIndex = 5;
      this.addButton.Text = "Neue Disziplin hinzufügen";
      this.addButton.UseVisualStyleBackColor = true;
      this.addButton.Click += new System.EventHandler(this.addButton_Click);
      // 
      // deleteButton
      // 
      this.deleteButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
      this.deleteButton.Location = new System.Drawing.Point(12, 258);
      this.deleteButton.Name = "deleteButton";
      this.deleteButton.Size = new System.Drawing.Size(301, 42);
      this.deleteButton.TabIndex = 6;
      this.deleteButton.Text = "Disziplin löschen";
      this.deleteButton.UseVisualStyleBackColor = true;
      this.deleteButton.Click += new System.EventHandler(this.deleteButton_Click);
      // 
      // typeComboBox
      // 
      this.typeComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
      this.typeComboBox.FormattingEnabled = true;
      this.typeComboBox.Location = new System.Drawing.Point(466, 9);
      this.typeComboBox.Name = "typeComboBox";
      this.typeComboBox.Size = new System.Drawing.Size(356, 28);
      this.typeComboBox.TabIndex = 7;
      this.typeComboBox.SelectedValueChanged += new System.EventHandler(this.typeComboBox_SelectedValueChanged);
      // 
      // nameTextBox
      // 
      this.nameTextBox.Location = new System.Drawing.Point(466, 43);
      this.nameTextBox.Name = "nameTextBox";
      this.nameTextBox.Size = new System.Drawing.Size(356, 26);
      this.nameTextBox.TabIndex = 8;
      this.nameTextBox.Leave += new System.EventHandler(this.nameTextBox_Leave);
      // 
      // unitTextBox
      // 
      this.unitTextBox.Location = new System.Drawing.Point(466, 75);
      this.unitTextBox.Name = "unitTextBox";
      this.unitTextBox.Size = new System.Drawing.Size(356, 26);
      this.unitTextBox.TabIndex = 9;
      this.unitTextBox.Leave += new System.EventHandler(this.unitTextBox_Leave);
      // 
      // lowIsBetterCheckBox
      // 
      this.lowIsBetterCheckBox.AutoSize = true;
      this.lowIsBetterCheckBox.Location = new System.Drawing.Point(466, 107);
      this.lowIsBetterCheckBox.Name = "lowIsBetterCheckBox";
      this.lowIsBetterCheckBox.Size = new System.Drawing.Size(22, 21);
      this.lowIsBetterCheckBox.TabIndex = 10;
      this.lowIsBetterCheckBox.UseVisualStyleBackColor = true;
      this.lowIsBetterCheckBox.CheckedChanged += new System.EventHandler(this.lowIsBetterCheckBox_CheckedChanged);
      // 
      // CompetitionDisciplinesConfiguration
      // 
      this.AutoSize = true;
      this.ClientSize = new System.Drawing.Size(837, 312);
      this.Controls.Add(this.lowIsBetterCheckBox);
      this.Controls.Add(this.unitTextBox);
      this.Controls.Add(this.nameTextBox);
      this.Controls.Add(this.typeComboBox);
      this.Controls.Add(this.deleteButton);
      this.Controls.Add(this.addButton);
      this.Controls.Add(this.lowIsBetterLabel);
      this.Controls.Add(this.unitLabel);
      this.Controls.Add(this.nameLabel);
      this.Controls.Add(this.typeLabel);
      this.Controls.Add(this.disciplineListBox);
      this.Name = "CompetitionDisciplinesConfiguration";
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.ListBox disciplineListBox;
    private System.Windows.Forms.Label typeLabel;
    private System.Windows.Forms.Label nameLabel;
    private System.Windows.Forms.Label unitLabel;
    private System.Windows.Forms.Label lowIsBetterLabel;
    private System.Windows.Forms.Button addButton;
    private System.Windows.Forms.Button deleteButton;
    private System.Windows.Forms.ComboBox typeComboBox;
    private System.Windows.Forms.TextBox nameTextBox;
    private System.Windows.Forms.TextBox unitTextBox;
    private System.Windows.Forms.CheckBox lowIsBetterCheckBox;
  }
}