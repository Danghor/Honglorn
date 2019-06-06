using HonglornBL.MasterData.StudentHandicap;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HonglornWPF.ViewModels
{
    class StudentHandicapDetailViewModel : DetailViewModel<IStudentHandicapModel>, IStudentHandicapModel
    {
        public Guid StudentPKey => CurrentStudent?.Key ?? default;

        public Guid HandicapPKey => CurrentHandicap?.Key ?? default;

        DateTime dateStart;

        public DateTime DateStart
        {
            get => dateStart;
            set => OnPropertyChanged(out dateStart, value);
        }

        DateTime? dateEnd;

        public DateTime? DateEnd
        {
            get => dateEnd;
            set => OnPropertyChanged(out dateEnd, value);
        }

        public IDictionary<Guid, string> ValidHandicaps { get; }

        KeyValuePair<Guid, string>? currentHandicap;

        public KeyValuePair<Guid, string>? CurrentHandicap
        {
            get => currentHandicap;
            set => OnPropertyChanged(out currentHandicap, value);
        }

        public IDictionary<Guid, string> ValidStudents { get; }

        KeyValuePair<Guid, string>? currentStudent;

        public KeyValuePair<Guid, string>? CurrentStudent
        {
            get => currentStudent;
            set => OnPropertyChanged(out currentStudent, value);
        }

        public StudentHandicapDetailViewModel(Action cancelAction) : base(cancelAction)
        {
            ValidStudents = Honglorn.StudentService().GetManagers().ToDictionary(s => s.PKey, s => $"{s.Forename} {s.Surname}");
            ValidHandicaps = Honglorn.HandicapService().GetManagers().ToDictionary(c => c.PKey, c => c.Name);
        }

        internal override void Clear()
        {
            CurrentStudent = default;
            CurrentHandicap = default;
            DateStart = default;
            dateEnd = default;
        }

        internal override void CopyValues(IStudentHandicapModel model)
        {
            CurrentStudent = ValidStudents.SingleOrDefault(i => i.Key == model.StudentPKey);
            CurrentHandicap = ValidHandicaps.SingleOrDefault(i => i.Key == model.HandicapPKey);
            DateStart = model.DateStart;
            DateEnd = model.DateEnd;
        }
    }
}