using System;
using System.ComponentModel;
using System.Windows.Forms;
using HonglornBL;
using HonglornBL.Interfaces;

namespace HonglornWinForm {
  public partial class ImportDialog : Form {
    public ImportDialog() {
      InitializeComponent();
      yearTextBox.Text = DateTime.Now.Year.ToString();
    }

    void browseLabel_Click(object sender, EventArgs e) {
      openFileDialog.ShowDialog();
    }

    void openFileDialog_FileOk(object sender, CancelEventArgs e) {
      filePathTextBox.Text = openFileDialog.FileName;
    }

    void backgroundWorker_DoWork(object sender, DoWorkEventArgs e) {
      Honglorn.ImportStudentCourseExcelSheet(filePathTextBox.Text, 2015, backgroundWorker);
    }

    void startImportButton_Click(object sender, EventArgs e) {
      try {
        backgroundWorker.RunWorkerAsync();
      } catch (Exception ex) {
        MessageBox.Show(ex.Message);
      }
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
      MessageBox.Show("Import erfolgreich!", "Schülerdaten Import", MessageBoxButtons.OK, MessageBoxIcon.Information);
    }
  }
}