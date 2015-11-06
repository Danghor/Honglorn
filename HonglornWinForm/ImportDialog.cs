using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace HonglornWinForm {
  public partial class ImportDialog : Form {
    public ImportDialog() {
      InitializeComponent();
    }

    void browseLabel_Click(object sender, EventArgs e) {
      openFileDialog.ShowDialog();
    }

    void openFileDialog_FileOk(object sender, CancelEventArgs e) {
      filePathTextBox.Text = openFileDialog.FileName;
    }
  }
}