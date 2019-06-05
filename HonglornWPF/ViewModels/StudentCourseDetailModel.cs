using HonglornBL.MasterData.StudentCourse;
using System;
using System.Collections.Generic;
using System.Linq;

namespace HonglornWPF.ViewModels
{
    class StudentCourseDetailModel : DetailViewModel<IStudentCourseModel>, IStudentCourseModel
    {
        Guid studentPKey;

        public Guid StudentPKey
        {
            get => studentPKey;
            set => OnPropertyChanged(out studentPKey, value);
        }

        Guid coursePKey;

        public Guid CoursePKey
        {
            get => coursePKey;
            set => OnPropertyChanged(out coursePKey, value);
        }

        DateTime dateStart;

        public DateTime DateStart
        {
            get => dateStart;
            set => OnPropertyChanged(out dateStart, value);
        }

        DateTime dateEnd;

        public DateTime DateEnd
        {
            get => dateEnd;
            set => OnPropertyChanged(out dateEnd, value);
        }

        public IDictionary<Guid, string> ValidCourses { get; }

        KeyValuePair<Guid, string>? currentCourse;

        public KeyValuePair<Guid, string>? CurrentCourse
        {
            get => currentCourse;
            set => OnPropertyChanged(out currentCourse, value);
        }

        public IDictionary<Guid, string> ValidStudents { get; }

        KeyValuePair<Guid, string>? currentStudent;

        public KeyValuePair<Guid, string>? CurrentStudent
        {
            get => currentStudent;
            set => OnPropertyChanged(out currentStudent, value);
        }

        public StudentCourseDetailModel(Action cancelAction) : base(cancelAction)
        {
            ValidStudents = Honglorn.StudentService().GetManagers().ToDictionary(s => s.PKey, s => $"{s.Forename} {s.Surname}");
            ValidCourses = Honglorn.CourseService().GetManagers().ToDictionary(c => c.PKey, c => c.Name);
        }

        internal override void Clear()
        {
            StudentPKey = default;
            CoursePKey = default;
            DateStart = default;
            dateEnd = default;
        }

        internal override void CopyValues(IStudentCourseModel model)
        {
            StudentPKey = model.StudentPKey;
            CoursePKey = model.CoursePKey;
            DateStart = model.DateStart;
            DateEnd = model.DateEnd;
        }
    }
}
