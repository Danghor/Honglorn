using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using HonglornBL;
using static HonglornWinForm.Tools;

namespace HonglornWinForm {
  public partial class MainForm : Form {
    const float SCALING_FACTOR = 0.8f;

    short SelectedYear {
      get {
        short year;

        try {
          year = Convert.ToInt16(selectEditYearComboBox.SelectedValue);
        } catch (FormatException) {
          try {
            year = Convert.ToInt16(DateTime.Now.Year);
          } catch (FormatException) {
            year = 0;
          }
        }

        return year;
      }
    }

    string SelectedCourseName => selectEditCourseComboBox.SelectedValue?.ToString() ?? string.Empty;

    public MainForm() {
      InitializeComponent();
    }

    protected override void OnLoad(EventArgs e) {
      base.OnLoad(e);

      //dummy();

      ScaleScreenAware(this, SCALING_FACTOR);
      Center(this);

      smartRefreshComboBoxes();
      refreshDataGrid();
    }

    void smartRefreshComboBoxes() {
      smartRefreshYearComboBox();
      smartRefreshCourseComboBox();
    }

    void smartRefreshCourseComboBox() {
      ICollection<string> retrievedCourseNames = Honglorn.GetValidCourseNames(SelectedYear);
      smartRefreshComboBox(selectEditCourseComboBox, retrievedCourseNames);
    }

    void smartRefreshYearComboBox() {
      ICollection<short> retrievedYears = Honglorn.GetYearsWithStudentData();
      smartRefreshComboBox(selectEditYearComboBox, retrievedYears);
    }

    /// <summary>
    ///   Replaces the current data source with the retrieved items iff they are not the same.
    /// </summary>
    /// <typeparam name="CollectionType">The data type of the items contained in the combo box.</typeparam>
    /// <param name="box">The combo box to be updated.</param>
    /// <param name="retrievedItems">The items freshly retrieved from the database.</param>
    static void smartRefreshComboBox<CollectionType>(ComboBox box, ICollection<CollectionType> retrievedItems) {
      ICollection<CollectionType> currentData = (ICollection<CollectionType>) box.DataSource;

      if (retrievedItems != null && currentData?.SequenceEqual(retrievedItems) != true) {
        box.DataSource = retrievedItems;
      }
    }

    void refreshDataGrid() {
      competitionDataGridView.DataSource = Honglorn.GetStudentCompetitionData(SelectedCourseName, SelectedYear);
      DataGridViewColumn pkeyColumn = competitionDataGridView.Columns["PKey"];
      if (pkeyColumn != null) {
        pkeyColumn.Visible = false;
      }

      makeColumnReadOnly("Surname");
      makeColumnReadOnly("Forename");
      makeColumnReadOnly("Sex");
    }

    void makeColumnReadOnly(string name) {
      DataGridViewColumn column = competitionDataGridView.Columns[name];
      if (column != null) {
        column.ReadOnly = true;
      }
    }

    void dummy() {
      Honglorn.ImportStudentCourseExcelSheet(@"C:\Git\Honglorn\IMPORT~1.XLS", 2015);
    }

    void selectEditCourseComboBox_SelectedValueChanged(object sender, EventArgs e) {
      refreshDataGrid();
    }

    void selectEditYearComboBox_SelectedValueChanged(object sender, EventArgs e) {
      refreshDataGrid();
    }
  }
}