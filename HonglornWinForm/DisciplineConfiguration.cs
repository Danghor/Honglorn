using System;
using System.Windows.Forms;
using static HonglornBL.Honglorn;
using static HonglornWinForm.Prerequisites;

namespace HonglornWinForm {
  partial class DisciplineConfiguration : Form {
    short? SelectedYear => yearComboBox.SelectedValue as short?;
    string SelectedClass => classComboBox.SelectedValue as string;

    internal DisciplineConfiguration() {
      InitializeComponent();
    }

    protected override void OnLoad(EventArgs e) {
      base.OnLoad(e);

      SmartRefreshComboBox(yearComboBox, YearsWithStudentData());
    }

    void yearComboBox_DropDown(object sender, EventArgs e) {
      SmartRefreshComboBox(yearComboBox, YearsWithStudentData());
    }

    void RefreshClassComboBox() {
      if (SelectedYear == null) {
        classComboBox.Enabled = false;
        classComboBox.DataSource = null;
      } else {
        SmartRefreshComboBox(classComboBox, ValidClassNames((short) SelectedYear));
      }
    }

    void yearComboBox_SelectedValueChanged(object sender, EventArgs e) {
      RefreshClassComboBox();
    }

    void classComboBox_SelectedValueChanged(object sender, EventArgs e) {
      if (SelectedYear != null && !string.IsNullOrWhiteSpace(SelectedClass)) {
        gameTypeGroupBox.Enabled = true;

        HonglornBL.Prerequisites.GameType? gameType = GetGameType(SelectedClass, (short) SelectedYear);

        switch (gameType) {
          case HonglornBL.Prerequisites.GameType.Competition:
            competitionRadioButton.Checked = true;
            break;
          case HonglornBL.Prerequisites.GameType.Traditional:
            tradtitionalRadioButton.Checked = true;
            break;
          case null:
            tradtitionalRadioButton.Checked = false;
            competitionRadioButton.Checked = false;
            break;
          default:
            throw new ArgumentOutOfRangeException(nameof(HonglornBL.Prerequisites.GameType));
        }
      }
    }
  }
}