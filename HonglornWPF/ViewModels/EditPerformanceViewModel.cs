using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HonglornWPF.ViewModels {
  class EditPerformanceViewModel {
    public event Action CoursesLoaded;
    public event Action YearsLoaded;

    public ObservableCollection<string> Courses { get; set; }
    public ObservableCollection<short> Years { get; set; }

    public EditPerformanceViewModel() {
      Courses = new ObservableCollection<string>();
      Years = new ObservableCollection<short>();
    }

    public void LoadCourseNames(short year) {
      Courses.Clear();

      ICollection<string> courseNames = HonglornBL.Honglorn.ValidCourseNames(year);

      foreach (string courseName in courseNames) {
        Courses.Add(courseName);
      }

      CoursesLoaded?.Invoke();
    }

    public void LoadYears() {
      Years.Clear();

      ICollection<short> years = HonglornBL.Honglorn.YearsWithStudentData();

      foreach (short year in years) {
        Years.Add(year);
      }

      YearsLoaded?.Invoke();
    }
  }
}
