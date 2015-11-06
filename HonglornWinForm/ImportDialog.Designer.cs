namespace HonglornWinForm {
  partial class ImportDialog {
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
      this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
      this.filePathTextBox = new System.Windows.Forms.TextBox();
      this.browseLabel = new System.Windows.Forms.Button();
      this.progressBar = new System.Windows.Forms.ProgressBar();
      this.progressLabel = new System.Windows.Forms.Label();
      this.startImportButton = new System.Windows.Forms.Button();
      this.fileLabel = new System.Windows.Forms.Label();
      this.backgroundWorker = new System.ComponentModel.BackgroundWorker();
      this.yearLabel = new System.Windows.Forms.Label();
      this.yearNumericUpDown = new System.Windows.Forms.NumericUpDown();
      ((System.ComponentModel.ISupportInitialize)(this.yearNumericUpDown)).BeginInit();
      this.SuspendLayout();
      // 
      // openFileDialog
      // 
      this.openFileDialog.Title = "Import Datei auswählen";
      this.openFileDialog.FileOk += new System.ComponentModel.CancelEventHandler(this.openFileDialog_FileOk);
      // 
      // filePathTextBox
      // 
      this.filePathTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.filePathTextBox.Location = new System.Drawing.Point(138, 12);
      this.filePathTextBox.Name = "filePathTextBox";
      this.filePathTextBox.Size = new System.Drawing.Size(253, 26);
      this.filePathTextBox.TabIndex = 0;
      // 
      // browseLabel
      // 
      this.browseLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.browseLabel.Location = new System.Drawing.Point(397, 9);
      this.browseLabel.Name = "browseLabel";
      this.browseLabel.Size = new System.Drawing.Size(129, 32);
      this.browseLabel.TabIndex = 1;
      this.browseLabel.Text = "Durchsuchen...";
      this.browseLabel.UseVisualStyleBackColor = true;
      this.browseLabel.Click += new System.EventHandler(this.browseLabel_Click);
      // 
      // progressBar
      // 
      this.progressBar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.progressBar.Location = new System.Drawing.Point(12, 125);
      this.progressBar.MarqueeAnimationSpeed = 30;
      this.progressBar.Name = "progressBar";
      this.progressBar.Size = new System.Drawing.Size(514, 35);
      this.progressBar.TabIndex = 2;
      // 
      // progressLabel
      // 
      this.progressLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.progressLabel.AutoSize = true;
      this.progressLabel.Location = new System.Drawing.Point(256, 163);
      this.progressLabel.Name = "progressLabel";
      this.progressLabel.Size = new System.Drawing.Size(30, 20);
      this.progressLabel.TabIndex = 3;
      this.progressLabel.Text = "bla";
      // 
      // startImportButton
      // 
      this.startImportButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.startImportButton.Location = new System.Drawing.Point(12, 76);
      this.startImportButton.Name = "startImportButton";
      this.startImportButton.Size = new System.Drawing.Size(514, 43);
      this.startImportButton.TabIndex = 4;
      this.startImportButton.Text = "Start Import";
      this.startImportButton.UseVisualStyleBackColor = true;
      this.startImportButton.Click += new System.EventHandler(this.startImportButton_Click);
      // 
      // fileLabel
      // 
      this.fileLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.fileLabel.AutoSize = true;
      this.fileLabel.Location = new System.Drawing.Point(12, 15);
      this.fileLabel.Name = "fileLabel";
      this.fileLabel.Size = new System.Drawing.Size(120, 20);
      this.fileLabel.TabIndex = 5;
      this.fileLabel.Text = "Datei für Import";
      // 
      // backgroundWorker
      // 
      this.backgroundWorker.WorkerReportsProgress = true;
      this.backgroundWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker_DoWork);
      this.backgroundWorker.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.backgroundWorker_ProgressChanged);
      this.backgroundWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker_RunWorkerCompleted);
      // 
      // yearLabel
      // 
      this.yearLabel.AutoSize = true;
      this.yearLabel.Location = new System.Drawing.Point(12, 44);
      this.yearLabel.Name = "yearLabel";
      this.yearLabel.Size = new System.Drawing.Size(109, 20);
      this.yearLabel.TabIndex = 6;
      this.yearLabel.Text = "Aktuelles Jahr";
      // 
      // yearNumericUpDown
      // 
      this.yearNumericUpDown.Location = new System.Drawing.Point(138, 44);
      this.yearNumericUpDown.Maximum = new decimal(new int[] {
            2500,
            0,
            0,
            0});
      this.yearNumericUpDown.Minimum = new decimal(new int[] {
            1900,
            0,
            0,
            0});
      this.yearNumericUpDown.Name = "yearNumericUpDown";
      this.yearNumericUpDown.Size = new System.Drawing.Size(73, 26);
      this.yearNumericUpDown.TabIndex = 8;
      this.yearNumericUpDown.Value = new decimal(new int[] {
            1900,
            0,
            0,
            0});
      // 
      // ImportDialog
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(538, 192);
      this.Controls.Add(this.yearNumericUpDown);
      this.Controls.Add(this.yearLabel);
      this.Controls.Add(this.fileLabel);
      this.Controls.Add(this.startImportButton);
      this.Controls.Add(this.progressLabel);
      this.Controls.Add(this.progressBar);
      this.Controls.Add(this.browseLabel);
      this.Controls.Add(this.filePathTextBox);
      this.MaximizeBox = false;
      this.MinimizeBox = false;
      this.Name = "ImportDialog";
      this.ShowInTaskbar = false;
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
      this.Text = "ImportDialog";
      ((System.ComponentModel.ISupportInitialize)(this.yearNumericUpDown)).EndInit();
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.OpenFileDialog openFileDialog;
    private System.Windows.Forms.TextBox filePathTextBox;
    private System.Windows.Forms.Button browseLabel;
    private System.Windows.Forms.ProgressBar progressBar;
    private System.Windows.Forms.Label progressLabel;
    private System.Windows.Forms.Button startImportButton;
    private System.Windows.Forms.Label fileLabel;
    private System.ComponentModel.BackgroundWorker backgroundWorker;
    private System.Windows.Forms.Label yearLabel;
    private System.Windows.Forms.NumericUpDown yearNumericUpDown;
  }
}