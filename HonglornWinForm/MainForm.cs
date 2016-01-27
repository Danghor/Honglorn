using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using HonglornBL;
using HonglornBL.Models.Entities;
using static HonglornWinForm.Prerequisites;

namespace HonglornWinForm {
  public partial class MainForm : Form {
    const float SCALING_FACTOR = 0.8f;

    short SelectedYear => selectEditYearComboBox.SelectedValue as short? ?? Convert.ToInt16(DateTime.Now.Year);

    string SelectedCourseName => selectEditCourseComboBox.SelectedValue?.ToString() ?? string.Empty;

    public MainForm() {
      InitializeComponent();
    }

    protected override void OnLoad(EventArgs e) {
      base.OnLoad(e);

      ScaleScreenAware(this, SCALING_FACTOR);
      CenterToScreen();

      smartRefreshComboBoxes();
      RefreshDataGrid();
    }

    void smartRefreshComboBoxes() {
      smartRefreshYearComboBox();
      smartRefreshCourseComboBox();
    }

    void smartRefreshCourseComboBox() {
      ICollection<string> retrievedCourseNames = Honglorn.ValidCourseNames(SelectedYear);
      SmartRefreshComboBox(selectEditCourseComboBox, retrievedCourseNames);
    }

    void smartRefreshYearComboBox() {
      ICollection<short> retrievedYears = Honglorn.YearsWithStudentData();
      SmartRefreshComboBox(selectEditYearComboBox, retrievedYears);
    }

    void RefreshDataGrid() {
      DataTable table = Honglorn.GetStudentCompetitionTable(SelectedCourseName, SelectedYear);

      competitionDataGridView.DataSource = table;

      DataGridViewColumn pkeyColumn = competitionDataGridView.Columns[nameof(Student.PKey)];
      if (pkeyColumn != null) {
        pkeyColumn.Visible = false;
      }

      MakeColumnsReadOnly(competitionDataGridView, nameof(Student.Surname), nameof(Student.Forename), nameof(Student.Sex));

      foreach (string key in GermanColumnNameMap.Keys) {
        SetHeaderText(competitionDataGridView, key, GermanColumnNameMap[key]);
      }
    }

    void SaveDataGrid() {
      DataTable table = (DataTable) competitionDataGridView.DataSource;
      Honglorn.UpdateStudentCompetitionData(table, SelectedYear);
    }

    static void SetHeaderText(DataGridView dgv, string oldText, string newText) {
      DataGridViewColumn column = dgv.Columns[oldText];
      if (column != null) {
        column.HeaderText = newText;
      }
    }

    static void MakeColumnsReadOnly(DataGridView dgv, params string[] columnNames) {
      foreach (string name in columnNames) {
        MakeColumnReadOnly(dgv, name);
      }
    }

    static void MakeColumnReadOnly(DataGridView dgv, string name) {
      DataGridViewColumn column = dgv.Columns[name];
      if (column != null) {
        column.ReadOnly = true;
      }
    }

    void selectEditCourseComboBox_SelectedValueChanged(object sender, EventArgs e) {
      RefreshDataGrid();
    }

    void selectEditYearComboBox_SelectedValueChanged(object sender, EventArgs e) {
      RefreshDataGrid();
    }

    void importStudentsToolStripMenuItem_Click(object sender, EventArgs e) {
      ImportDialog importDialog = new ImportDialog();
      ScaleScreenAware(importDialog, 0.3f);
      importDialog.ShowDialog();
    }

    void competitionDataGridView_CellEndEdit(object sender, DataGridViewCellEventArgs e) {
      SaveDataGrid();
    }

    void setDisciplinesToolStripMenuItem_Click(object sender, EventArgs e) {
      DisciplineConfiguration config = new DisciplineConfiguration();
      config.ShowDialog();
    }

    void editCompetitionDisciplinesToolStripMenuItem_Click(object sender, EventArgs e) {
      CompetitionDisciplinesConfiguration config = new CompetitionDisciplinesConfiguration();
      config.ShowDialog();
    }
  }
}