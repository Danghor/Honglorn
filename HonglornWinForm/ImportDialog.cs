using System;
using System.ComponentModel;
using System.Windows.Forms;
using HonglornBL;
using HonglornBL.Interfaces;
using static HonglornBL.Prerequisites;

namespace HonglornWinForm {
  public partial class ImportDialog : Form {
    public ImportDialog() {
      InitializeComponent();
      yearNumericUpDown.Value = Convert.ToDecimal(DateTime.Now.Year);
    }

    void browseLabel_Click(object sender, EventArgs e) {
      openFileDialog.ShowDialog();
    }

    void openFileDialog_FileOk(object sender, CancelEventArgs e) {
      filePathTextBox.Text = openFileDialog.FileName;
    }

    void startImportButton_Click(object sender, EventArgs e) {
      startImportButton.Enabled = false;
      try {
        backgroundWorker.RunWorkerAsync();
      } catch (Exception ex) {
        MessageBox.Show(ex.Message);
        startImportButton.Enabled = true;
      }
    }

    void backgroundWorker_DoWork(object sender, DoWorkEventArgs e) {
      short year = (short)yearNumericUpDown.Value;
      Honglorn.ImportStudentCourseExcelSheet(filePathTextBox.Text, year, backgroundWorker);
    }

    void backgroundWorker_ProgressChanged(object sender, ProgressChangedEventArgs e) {
      progressBar.Value = e.ProgressPercentage;

      IProgressInformer informer = e.UserState as IProgressInformer;
      if (informer != null) {
        progressBar.Style = informer.Style;
        progressLabel.Text = informer.StatusMessage;
      }
    }

    void backgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e) {
      if (e.Error == null) {
        MessageBox.Show("Import erfolgreich!", "Schülerdaten Import", MessageBoxButtons.OK, MessageBoxIcon.Information);
      } else {
        MessageBox.Show(e.Error.Message, "Schülerdaten Import", MessageBoxButtons.OK, MessageBoxIcon.Error);
      }

      ResetProgressBar();
      progressLabel.Text = string.Empty;
      startImportButton.Enabled = true;
    }

    void ResetProgressBar() {
      progressBar.Style = ProgressBarStyle.Continuous;
      progressBar.Value = 0;
    }
  }
}