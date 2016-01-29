using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using HonglornBL.Models.Entities;
using static HonglornBL.Prerequisites;

namespace HonglornWinForm {
  static class Prerequisites {
    internal static readonly Dictionary<string, string> GermanColumnNameMap = new Dictionary<string, string> {
      {nameof(Student.Surname), "Nachname"},
      {nameof(Student.Forename), "Vorname"},
      {nameof(Student.Sex), "Geschlecht"},
      {nameof(Competition.Sprint), "Sprint"},
      {nameof(Competition.Jump), "Sprung"},
      {nameof(Competition.Throw), "Wurf"},
      {nameof(Competition.MiddleDistance), "Ausdauer"}
    };

    internal static readonly Dictionary<DisciplineType, string> GermanDisciplineTypeMap = new Dictionary<DisciplineType, string> {
      {DisciplineType.Sprint, "Sprint"},
      {DisciplineType.Jump, "Sprung"},
      {DisciplineType.Throw, "Wurf"},
      {DisciplineType.MiddleDistance, "Ausdauer"}
    };

    /// <summary>
    ///   Positions the given control at the center of the screen.
    /// </summary>
    /// <param name="form">The control to be centered.</param>
    internal static void Center(Control form) {
      form.Location = new Point {
        X = (Screen.PrimaryScreen.Bounds.Width - form.Width) / 2,
        Y = (Screen.PrimaryScreen.Bounds.Height - form.Height) / 2
      };
    }

    /// <summary>
    ///   Scales the given control dependent on the screen-measurements.
    /// </summary>
    /// <param name="form">The control to be scaled.</param>
    /// <param name="scalingFactor">The scale factor to be used. 1 will make the control just as big as the screen.</param>
    internal static void ScaleScreenAware(Control form, float scalingFactor) {
      form.Height = Convert.ToInt32(Screen.PrimaryScreen.Bounds.Height * scalingFactor);
      form.Width = Convert.ToInt32(Screen.PrimaryScreen.Bounds.Width * scalingFactor);
    }

    /// <summary>
    ///   Replaces the current data source with the retrieved items iff they are not the same.
    /// </summary>
    /// <typeparam name="CollectionType">The data type of the items contained in the combo box.</typeparam>
    /// <param name="box">The combo box to be updated.</param>
    /// <param name="retrievedItems">The items freshly retrieved from the database.</param>
    internal static void SmartRefreshComboBox<CollectionType>(ComboBox box, IEnumerable<CollectionType> retrievedItems) {
      if (retrievedItems == null) {
        box.Enabled = false;
        box.DataSource = null;
      } else {
        box.Enabled = true;

        IEnumerable<CollectionType> currentData = box.DataSource as IEnumerable<CollectionType>;
        if (currentData?.SequenceEqual(retrievedItems) != true) {
          box.DataSource = retrievedItems;
        }
      }
    }
  }
}