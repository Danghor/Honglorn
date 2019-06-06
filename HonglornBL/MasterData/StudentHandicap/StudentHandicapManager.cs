using HonglornBL.Models.Framework;
using System;
using System.Data.Entity;

namespace HonglornBL.MasterData.StudentHandicap
{
    public class StudentHandicapManager : EntityManager<Models.Entities.StudentHandicap>, IStudentHandicapModel, IEntityManager<IStudentHandicapModel>
    {
        internal StudentHandicapManager(Guid pKey, HonglornDbFactory contextFactory) : base(pKey, contextFactory) { }

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

        public void Update(IStudentHandicapModel model)
        {
            StudentPKey = model.StudentPKey;
            HandicapPKey = model.HandicapPKey;
            DateStart = model.DateStart;
            DateEnd = model.DateEnd;
        }

        protected override Exception CreateNotFoundException(string message) => new StudentHandicapNotFoundException(message);

        protected override DbSet<Models.Entities.StudentHandicap> GetDbSet(HonglornDb db) => db.StudentHandicap;
    }
}