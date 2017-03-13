using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;

namespace HonglornWPF.ViewModels {
  class EditPerformanceViewModel : INotifyPropertyChanged {
    public event PropertyChangedEventHandler PropertyChanged;
    public event Action CoursesLoaded;
    public event Action YearsLoaded;

    public ObservableCollection<string> Courses { get; set; }
    public ObservableCollection<short> Years { get; set; }

    string currentCourse;
    short currentYear;

    public short CurrentYear {
      get {
        return currentYear;
      }

      set {
        currentYear = value;
        OnPropertyChanged(nameof(CurrentYear));

        string previouslySelectedCourse = CurrentCourse;

        LoadCourseNames(currentYear);

        int courseIndex = Courses.IndexOf(previouslySelectedCourse);
        CurrentCourse = courseIndex != -1 ? previouslySelectedCourse : Courses.FirstOrDefault();
      }
    }

    public string CurrentCourse {
      get {
        return currentCourse;
      }
      set {
        currentCourse = value;
        OnPropertyChanged(nameof(CurrentCourse));
      }
    }

    public EditPerformanceViewModel() {
      Courses = new ObservableCollection<string>();
      Years = new ObservableCollection<short>();

      LoadYears();
      if (Years.Any()) {
        CurrentYear = Years.First();
      }
    }

    void LoadCourseNames(short year) {
      Courses.Clear();

      ICollection<string> courseNames = HonglornBL.Honglorn.ValidCourseNames(year);

      foreach (string courseName in courseNames) {
        Courses.Add(courseName);
      }

      CoursesLoaded?.Invoke();
    }

    void LoadYears() {
      Years.Clear();

      ICollection<short> years = HonglornBL.Honglorn.YearsWithStudentData();

      foreach (short year in years) {
        Years.Add(year);
      }

      YearsLoaded?.Invoke();
    }

    void OnPropertyChanged(string propertyName) {
      PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
  }
}
