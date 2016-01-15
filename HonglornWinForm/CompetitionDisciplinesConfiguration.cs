using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using HonglornBL;
using HonglornBL.Models.Entities;
using static HonglornBL.Prerequisites;
using static HonglornWinForm.Prerequisites;

namespace HonglornWinForm {
  partial class CompetitionDisciplinesConfiguration : Form {

    bool isInAddMode;
    CompetitionDiscipline previousDiscipline;

    public CompetitionDisciplinesConfiguration() {
      InitializeComponent();
    }

    protected override void OnLoad(EventArgs e) {
      base.OnLoad(e);

      DisableEditArea();
      InitializeTypeEnum();
      RefreshDisciplinesList();

      if (disciplineListBox.Items.Count > 0) {
        disciplineListBox.SelectedIndex = 0;
      }
    }

    void DisableEditArea() {
      typeComboBox.Enabled = false;
      nameTextBox.Enabled = false;
      unitTextBox.Enabled = false;
      lowIsBetterCheckBox.Enabled = false;
    }

    void EnableEditArea() {
      typeComboBox.Enabled = true;
      nameTextBox.Enabled = true;
      unitTextBox.Enabled = true;
      lowIsBetterCheckBox.Enabled = true;
    }

    void RefreshDisciplinesList() {
      disciplineListBox.Items.Clear();
      previousDiscipline = null;

      ICollection<CompetitionDiscipline> disciplines = Honglorn.CompetitionDisciplines();

      foreach (CompetitionDiscipline discipline in disciplines) {
        disciplineListBox.Items.Add(discipline);
      }

      disciplineListBox.DisplayMember = nameof(CompetitionDiscipline.Name);

      if (disciplineListBox.Items.Count > 0) {
        disciplineListBox.SelectedIndex = 0;
      }
    }

    void InitializeTypeEnum() {
      IEnumerable<DisciplineType> enumCollection = Enum.GetValues(typeof(DisciplineType)).Cast<DisciplineType>();

      foreach (DisciplineType type in enumCollection) {
        typeComboBox.Items.Add(type);
      }

      //foreach (DisciplineType type in enumCollection) {
      //  string displayedValue;
      //  if (!GermanDisciplineTypeMap.TryGetValue(type, out displayedValue)) {
      //    displayedValue = type.ToString();
      //  }
      //  Tuple<DisciplineType, string> entry = new Tuple<DisciplineType, string>(type, displayedValue);
      //  typeComboBox.Items.Add(entry);
      //}

      //typeComboBox.DisplayMember = "Item2";
    }

    void addButton_Click(object sender, EventArgs e) {
      CompetitionDiscipline tempDiscipline = new CompetitionDiscipline {
        Type = DisciplineType.Sprint,
        Name = "Neue Disziplin",
        Unit = "Bewertungseinheiten"
      };

      disciplineListBox.Items.Add(tempDiscipline);
      disciplineListBox.SelectedItem = tempDiscipline;

      isInAddMode = true;
    }

    void deleteButton_Click(object sender, EventArgs e) {
      if (!isInAddMode) {
        CompetitionDiscipline selectedDiscipline = disciplineListBox.SelectedItem as CompetitionDiscipline;
        if (selectedDiscipline != null) {
          Honglorn.DeleteCompetitionDisciplineByPKey(selectedDiscipline.PKey);
        }
      }

      isInAddMode = false;
      RefreshDisciplinesList();
    }

    void disciplineListBox_SelectedIndexChanged(object sender, EventArgs e) {
      if (previousDiscipline != null) {
        // Save previous discipline
        try {
          Honglorn.CreateOrUpdateCompetitionDiscipline(previousDiscipline);
          previousDiscipline = (CompetitionDiscipline) disciplineListBox.SelectedItem;
          isInAddMode = false;
        } catch (Exception) {
          MessageBox.Show("Die gerade bearbeitete Disziplin enthält ungültige Einträge und kann daher nicht gespeichert werden. Bitte beheben Sie die angezeigten Eingabefehler oder löschen Sie andernfalls diese Disziplin", "Ungültige Werte", MessageBoxButtons.OK);
        }
      } else {
        previousDiscipline = (CompetitionDiscipline) disciplineListBox.SelectedItem;
      }

      CompetitionDiscipline selectedDiscipline = disciplineListBox.SelectedItem as CompetitionDiscipline;
      if (selectedDiscipline != null) {
        typeComboBox.SelectedItem = selectedDiscipline.Type;
        nameTextBox.Text = selectedDiscipline.Name;
        unitTextBox.Text = selectedDiscipline.Unit;
        lowIsBetterCheckBox.Checked = selectedDiscipline.LowIsBetter;
        EnableEditArea();
      } else {
        DisableEditArea();
        typeComboBox.ResetText();
        nameTextBox.ResetText();
        unitTextBox.ResetText();
        lowIsBetterCheckBox.Checked = false;
      }
    }

    void typeComboBox_SelectedValueChanged(object sender, EventArgs e) {
      CompetitionDiscipline selectedDiscipline = (CompetitionDiscipline) disciplineListBox.SelectedItem;

      if (selectedDiscipline != null) {
        ComboBox box = (ComboBox) sender;
        selectedDiscipline.Type = (DisciplineType) box.SelectedItem;
      }
    }

    void nameTextBox_Leave(object sender, EventArgs e) {
      CompetitionDiscipline selectedDiscipline = (CompetitionDiscipline) disciplineListBox.SelectedItem;
      if (selectedDiscipline != null) {
        TextBox box = (TextBox) sender;

        selectedDiscipline.Name = box.Text;
        //todo: clean this up
        int oldIndex = disciplineListBox.Items.IndexOf(selectedDiscipline);
        disciplineListBox.Items.Remove(selectedDiscipline);
        disciplineListBox.Items.Insert(oldIndex, selectedDiscipline);
        disciplineListBox.SelectedItem = selectedDiscipline;
      }
    }

    void unitTextBox_Leave(object sender, EventArgs e) {
      CompetitionDiscipline selectedDiscipline = (CompetitionDiscipline) disciplineListBox.SelectedItem;

      if (selectedDiscipline != null) {
        TextBox box = (TextBox) sender;
        selectedDiscipline.Unit = box.Text;
      }
    }

    void lowIsBetterCheckBox_CheckedChanged(object sender, EventArgs e) {
      CompetitionDiscipline selectedDiscipline = (CompetitionDiscipline) disciplineListBox.SelectedItem;

      if (selectedDiscipline != null) {
        CheckBox box = (CheckBox) sender;
        selectedDiscipline.LowIsBetter = box.Checked;
      }
    }
  }
}