using HonglornBL.Models.Framework;
using System;
using System.Data.Entity;

namespace HonglornBL.MasterData.StudentHandicap
{
    public class StudentHandicapService : EntityService<StudentHandicapManager, Models.Entities.StudentHandicap, IStudentHandicapModel>
    {
        internal StudentHandicapService(HonglornDbFactory contextFactory) : base(contextFactory) { }

        protected override IDbSet<Models.Entities.StudentHandicap> GetDbSet(HonglornDb context)
        {
            return context.StudentHandicap;
        }

        protected override Models.Entities.StudentHandicap CreateEntity(IStudentHandicapModel model)
        {
            return new Models.Entities.StudentHandicap
            {
                StudentPKey = model.StudentPKey,
                HandicapPKey = model.HandicapPKey,
                DateStart = model.DateStart,
                DateEnd = model.DateEnd
            };
        }

        protected override StudentHandicapManager CreateManager(Guid pKey, HonglornDbFactory contextFactory)
        {
            return new StudentHandicapManager(pKey, contextFactory);
        }
    }
}