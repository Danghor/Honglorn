using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using HonglornBL.Models.Entities;
using static HonglornBL.Honglorn;
using static HonglornBL.Prerequisites;
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

        //Set GameType
        gameTypeGroupBox.Enabled = true;

        GameType? gameType = GetGameType(SelectedClass, (short) SelectedYear);

        switch (gameType) {
          case GameType.Competition:
            competitionRadioButton.Checked = true;
            break;
          case GameType.Traditional:
            tradtitionalRadioButton.Checked = true;
            break;
          case null:
            tradtitionalRadioButton.Checked = false;
            competitionRadioButton.Checked = false;
            break;
          default:
            throw new ArgumentOutOfRangeException(nameof(GameType));
        }

        //Set Disciplines
        HonglornBL.Models.Entities.DisciplineCollection collection = ConfiguredDisciplines(SelectedClass, (short) SelectedYear);

      }
    }

    void radioButtons_CheckedChanged(object sender, EventArgs e) {
      RadioButton button = sender as RadioButton;

      if (button != null && button.Checked) {
        if (button == tradtitionalRadioButton) {

          ICollection<TraditionalDiscipline> maleSprintDisciplines = FilteredTraditionalDisciplines(DisciplineType.Sprint, Sex.Male);
          foreach (TraditionalDiscipline discipline in maleSprintDisciplines) {
            discipline.Name = $"{discipline.Name} [{discipline.Measurement} Measurement]";
          }

          maleSprintComboBox.DataSource = maleSprintDisciplines;
          maleJumpComboBox.DataSource = FilteredTraditionalDisciplines(DisciplineType.Jump, Sex.Male);
          maleThrowComboBox.DataSource = FilteredTraditionalDisciplines(DisciplineType.Throw, Sex.Male);
          maleMiddleDistanceComboBox.DataSource = FilteredTraditionalDisciplines(DisciplineType.MiddleDistance, Sex.Male);

          ICollection<TraditionalDiscipline> femaleSprintDisciplines = FilteredTraditionalDisciplines(DisciplineType.Sprint, Sex.Female);
          foreach (TraditionalDiscipline discipline in femaleSprintDisciplines) {
            discipline.Name = $"{discipline.Name} [{discipline.Measurement} Measurement]";
          }

          femaleSprintComboBox.DataSource = femaleSprintDisciplines;
          femaleJumpComboBox.DataSource = FilteredTraditionalDisciplines(DisciplineType.Jump, Sex.Female);
          femaleThrowComboBox.DataSource = FilteredTraditionalDisciplines(DisciplineType.Throw, Sex.Female);
          femaleMiddleDistanceComboBox.DataSource = FilteredTraditionalDisciplines(DisciplineType.MiddleDistance, Sex.Female);

          foreach (ComboBox box in new[] { maleSprintComboBox, maleJumpComboBox, maleThrowComboBox, maleMiddleDistanceComboBox, femaleSprintComboBox, femaleJumpComboBox, femaleThrowComboBox, femaleMiddleDistanceComboBox }) {
            box.DisplayMember = "Name";
          }

          maleGroupBox.Enabled = true;
          femaleGroupBox.Enabled = true;
        } else if (button == competitionRadioButton) {
          ICollection<CompetitionDiscipline> sprintDisciplines = FilteredCompetitionDisciplines(DisciplineType.Sprint);
          ICollection<CompetitionDiscipline> jumpDisciplines = FilteredCompetitionDisciplines(DisciplineType.Jump);
          ICollection<CompetitionDiscipline> throwDisciplines = FilteredCompetitionDisciplines(DisciplineType.Throw);
          ICollection<CompetitionDiscipline> middleDistanceDisciplines = FilteredCompetitionDisciplines(DisciplineType.MiddleDistance);

          if (sprintDisciplines.Any() && jumpDisciplines.Any() && throwDisciplines.Any() && middleDistanceDisciplines.Any()) {
            maleSprintComboBox.DataSource = sprintDisciplines;
            maleJumpComboBox.DataSource = jumpDisciplines;
            maleThrowComboBox.DataSource = throwDisciplines;
            maleMiddleDistanceComboBox.DataSource = middleDistanceDisciplines;

            femaleSprintComboBox.DataSource = sprintDisciplines;
            femaleJumpComboBox.DataSource = jumpDisciplines;
            femaleThrowComboBox.DataSource = throwDisciplines;
            femaleMiddleDistanceComboBox.DataSource = middleDistanceDisciplines;

            maleGroupBox.Enabled = true;
            femaleGroupBox.Enabled = true;
          } else {
            MessageBox.Show("Für mindestens eine Disziplin (Sprint, Sprung etc.) wurden keinerlei Einträge in der Datenbank gefunden. Legen Sie zunächst über \"Wettkampfdisziplinen bearbeiten\" neue Disziplinen an.", "Keine Disziplinen gefunden", MessageBoxButtons.OK, MessageBoxIcon.Error);
          }
        }
      }
    }
  }
}