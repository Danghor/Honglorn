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
      this.menuStrip1 = new System.Windows.Forms.MenuStrip();
      this.importStudentsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.selectEditCourseComboBox = new System.Windows.Forms.ComboBox();
      ((System.ComponentModel.ISupportInitialize)(this.competitionDataGridView)).BeginInit();
      this.menuStrip1.SuspendLayout();
      this.SuspendLayout();
      // 
      // competitionDataGridView
      // 
      this.competitionDataGridView.AllowUserToAddRows = false;
      this.competitionDataGridView.AllowUserToDeleteRows = false;
      this.competitionDataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.competitionDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
      this.competitionDataGridView.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
      this.competitionDataGridView.BackgroundColor = System.Drawing.SystemColors.Window;
      this.competitionDataGridView.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
      this.competitionDataGridView.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised;
      this.competitionDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
      this.competitionDataGridView.Location = new System.Drawing.Point(12, 101);
      this.competitionDataGridView.Name = "competitionDataGridView";
      this.competitionDataGridView.RowHeadersVisible = false;
      this.competitionDataGridView.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
      this.competitionDataGridView.RowTemplate.Height = 28;
      this.competitionDataGridView.Size = new System.Drawing.Size(754, 431);
      this.competitionDataGridView.TabIndex = 0;
      this.competitionDataGridView.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.competitionDataGridView_CellEndEdit);
      // 
      // selectEditYearComboBox
      // 
      this.selectEditYearComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
      this.selectEditYearComboBox.FormattingEnabled = true;
      this.selectEditYearComboBox.Location = new System.Drawing.Point(12, 36);
      this.selectEditYearComboBox.Name = "selectEditYearComboBox";
      this.selectEditYearComboBox.Size = new System.Drawing.Size(121, 28);
      this.selectEditYearComboBox.TabIndex = 1;
      this.selectEditYearComboBox.SelectedValueChanged += new System.EventHandler(this.selectEditYearComboBox_SelectedValueChanged);
      // 
      // menuStrip1
      // 
      this.menuStrip1.BackColor = System.Drawing.SystemColors.Control;
      this.menuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
      this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.importStudentsToolStripMenuItem});
      this.menuStrip1.Location = new System.Drawing.Point(0, 0);
      this.menuStrip1.Name = "menuStrip1";
      this.menuStrip1.Size = new System.Drawing.Size(778, 33);
      this.menuStrip1.TabIndex = 2;
      this.menuStrip1.Text = "menuStrip1";
      // 
      // importStudentsToolStripMenuItem
      // 
      this.importStudentsToolStripMenuItem.Name = "importStudentsToolStripMenuItem";
      this.importStudentsToolStripMenuItem.Size = new System.Drawing.Size(178, 29);
      this.importStudentsToolStripMenuItem.Text = "Schüler importieren";
      this.importStudentsToolStripMenuItem.Click += new System.EventHandler(this.importStudentsToolStripMenuItem_Click);
      // 
      // selectEditCourseComboBox
      // 
      this.selectEditCourseComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
      this.selectEditCourseComboBox.FormattingEnabled = true;
      this.selectEditCourseComboBox.Location = new System.Drawing.Point(12, 67);
      this.selectEditCourseComboBox.Name = "selectEditCourseComboBox";
      this.selectEditCourseComboBox.Size = new System.Drawing.Size(121, 28);
      this.selectEditCourseComboBox.TabIndex = 3;
      this.selectEditCourseComboBox.SelectedValueChanged += new System.EventHandler(this.selectEditCourseComboBox_SelectedValueChanged);
      // 
      // MainForm
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.AutoSize = true;
      this.ClientSize = new System.Drawing.Size(778, 544);
      this.Controls.Add(this.selectEditCourseComboBox);
      this.Controls.Add(this.selectEditYearComboBox);
      this.Controls.Add(this.competitionDataGridView);
      this.Controls.Add(this.menuStrip1);
      this.MainMenuStrip = this.menuStrip1;
      this.Name = "MainForm";
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
      this.Text = "Honglorn";
      ((System.ComponentModel.ISupportInitialize)(this.competitionDataGridView)).EndInit();
      this.menuStrip1.ResumeLayout(false);
      this.menuStrip1.PerformLayout();
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.DataGridView competitionDataGridView;
    private System.Windows.Forms.ComboBox selectEditYearComboBox;
    private System.Windows.Forms.MenuStrip menuStrip1;
    private System.Windows.Forms.ToolStripMenuItem importStudentsToolStripMenuItem;
    private System.Windows.Forms.ComboBox selectEditCourseComboBox;
  }
}

