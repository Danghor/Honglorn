using HonglornBL.Models.Framework;
using System;
using System.Data.Entity;

namespace HonglornBL.MasterData.StudentHandicap
{
    public sealed class StudentHandicapManager : EntityManager<Models.Entities.StudentHandicap, IStudentHandicapModel>, IStudentHandicapModel, IEntityManager<IStudentHandicapModel>
    {
        internal StudentHandicapManager(Guid pKey, HonglornDbFactory contextFactory, Func<HonglornDb, IDbSet<Models.Entities.StudentHandicap>> getDbSet) : base(pKey, contextFactory, getDbSet) { }

        public Guid StudentPKey
        {
            get => GetValue(s => s.StudentPKey);
            set => SetValue((s, p) => s.StudentPKey = p, value);
        }

        public string StudentName => GetValue(s => $"{s.Student.Forename} {s.Student.Surname}");

        public Guid HandicapPKey
        {
            get => GetValue(s => s.HandicapPKey);
            set => SetValue((s, p) => s.HandicapPKey = p, value);
        }

        public string HandicapName => GetValue(s => s.Handicap.Name);

        public DateTime DateStart
        {
            get => GetValue(s => s.DateStart);
            set => SetValue((student, dateStart) => student.DateStart = dateStart, value.Date);
        }

        public DateTime? DateEnd
        {
            get => GetValue(s => s.DateEnd);
            set => SetValue((student, dateEnd) => student.DateEnd = dateEnd, value?.Date);
        }

        protected override Exception CreateNotFoundException(string message) => new StudentHandicapNotFoundException(message);
    }
}