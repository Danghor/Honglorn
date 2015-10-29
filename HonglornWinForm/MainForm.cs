using System;
using System.Windows.Forms;
using HonglornBL;
using static HonglornWinForm.Tools;

namespace HonglornWinForm {
  public partial class MainForm : Form {
    const float SCALING_FACTOR = 0.8f;

    public MainForm() {
      InitializeComponent();
    }

    protected override void OnLoad(EventArgs e) {
      base.OnLoad(e);

      ScaleScreenAware(this, SCALING_FACTOR);
      Center(this);

      selectEditYearComboBox.DataSource = Honglorn.GetYearsWithStudentData();
    }
  }
}