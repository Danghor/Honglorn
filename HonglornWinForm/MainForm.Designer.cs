namespace HonglornWinForm {
  partial class MainForm {
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
      this.competitionDataGridView = new System.Windows.Forms.DataGridView();
      this.selectEditYearComboBox = new System.Windows.Forms.ComboBox();
      ((System.ComponentModel.ISupportInitialize)(this.competitionDataGridView)).BeginInit();
      this.SuspendLayout();
      // 
      // competitionDataGridView
      // 
      this.competitionDataGridView.AllowUserToAddRows = false;
      this.competitionDataGridView.AllowUserToDeleteRows = false;
      this.competitionDataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.competitionDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
      this.competitionDataGridView.Location = new System.Drawing.Point(12, 101);
      this.competitionDataGridView.Name = "competitionDataGridView";
      this.competitionDataGridView.ReadOnly = true;
      this.competitionDataGridView.RowTemplate.Height = 28;
      this.competitionDataGridView.Size = new System.Drawing.Size(698, 417);
      this.competitionDataGridView.TabIndex = 0;
      // 
      // selectEditYearComboBox
      // 
      this.selectEditYearComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
      this.selectEditYearComboBox.FormattingEnabled = true;
      this.selectEditYearComboBox.Location = new System.Drawing.Point(12, 31);
      this.selectEditYearComboBox.Name = "selectEditYearComboBox";
      this.selectEditYearComboBox.Size = new System.Drawing.Size(121, 28);
      this.selectEditYearComboBox.TabIndex = 1;
      // 
      // MainForm
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(722, 530);
      this.Controls.Add(this.selectEditYearComboBox);
      this.Controls.Add(this.competitionDataGridView);
      this.Name = "MainForm";
      this.Text = "Honglorn";
      ((System.ComponentModel.ISupportInitialize)(this.competitionDataGridView)).EndInit();
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.DataGridView competitionDataGridView;
    private System.Windows.Forms.ComboBox selectEditYearComboBox;
  }
}

