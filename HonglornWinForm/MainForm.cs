using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using HonglornBL;
using HonglornBL.APIClasses;
using HonglornBL.Interfaces;
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
      ICollection<string> retrievedCourseNames = Honglorn.GetValidCourseNames(SelectedYear);
      SmartRefreshComboBox(selectEditCourseComboBox, retrievedCourseNames);
    }

    void smartRefreshYearComboBox() {
      ICollection<short> retrievedYears = Honglorn.GetYearsWithStudentData();
      SmartRefreshComboBox(selectEditYearComboBox, retrievedYears);
    }

    /// <summary>
    ///   Replaces the current data source with the retrieved items iff they are not the same.
    /// </summary>
    /// <typeparam name="CollectionType">The data type of the items contained in the combo box.</typeparam>
    /// <param name="box">The combo box to be updated.</param>
    /// <param name="retrievedItems">The items freshly retrieved from the database.</param>
    static void SmartRefreshComboBox<CollectionType>(ComboBox box, ICollection<CollectionType> retrievedItems) {
      ICollection<CollectionType> currentData = (ICollection<CollectionType>) box.DataSource;

      if (retrievedItems != null && currentData?.SequenceEqual(retrievedItems) != true) {
        box.DataSource = retrievedItems;
      }
    }

    void RefreshDataGrid() {
      DataTable table = Honglorn.GetStudentCompetitionTable(SelectedCourseName, SelectedYear);

      competitionDataGridView.DataSource = table;

      DataGridViewColumn pkeyColumn = competitionDataGridView.Columns[nameof(IStudentCompetitionData.PKey)];
      if (pkeyColumn != null) {
        pkeyColumn.Visible = false;
      }

      MakeColumnsReadOnly(competitionDataGridView, nameof(IStudentCompetitionData.Surname), nameof(IStudentCompetitionData.Forename), nameof(IStudentCompetitionData.Sex));

      foreach (string key in GermanColumnNameMap.Keys) {
        SetHeaderText(competitionDataGridView, key, GermanColumnNameMap[key]);
      }
    }

    void SaveDataGrid() {
      ICollection<IStudentCompetitionData> collection = new List<IStudentCompetitionData>();

      DataTable table = (DataTable) competitionDataGridView.DataSource;

      DataColumn PKeyColumn = table.Columns[nameof(IStudentCompetitionData.PKey)];
      DataColumn SurnameColumn = table.Columns[nameof(IStudentCompetitionData.Surname)];
      DataColumn ForenameColumn = table.Columns[nameof(IStudentCompetitionData.Forename)];
      DataColumn SexColumn = table.Columns[nameof(IStudentCompetitionData.Sex)];
      DataColumn SprintColumn = table.Columns[nameof(IStudentCompetitionData.Sprint)];
      DataColumn JumpColumn = table.Columns[nameof(IStudentCompetitionData.Jump)];
      DataColumn ThrowColumn = table.Columns[nameof(IStudentCompetitionData.Throw)];
      DataColumn MiddleDistanceColumn = table.Columns[nameof(IStudentCompetitionData.MiddleDistance)];

      foreach (DataRow row in table.Rows) {
        collection.Add(new StudentCompetitionData {
          PKey = (Guid) row[PKeyColumn],
          Surname = row[SurnameColumn].ToString(),
          Forename = row[ForenameColumn].ToString(),
          Sex = (HonglornBL.Prerequisites.Sex) row[SexColumn],
          Sprint = row[SprintColumn] as float?,
          Jump = row[JumpColumn] as float?,
          Throw = row[ThrowColumn] as float?,
          MiddleDistance = row[MiddleDistanceColumn] as float?
        });
      }

      Honglorn.UpdateStudentCompetitionDataCollection(collection, SelectedYear);
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
  }
}