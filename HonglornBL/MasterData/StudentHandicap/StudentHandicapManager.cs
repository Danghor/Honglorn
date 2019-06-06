using HonglornBL.Models.Entities;
using HonglornBL.Models.Framework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;

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

        public Guid HandicapPKey
        {
            get => GetValue(s => s.HandicapPKey);
            set => SetValue((s, p) => s.HandicapPKey = p, value);
        }

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
