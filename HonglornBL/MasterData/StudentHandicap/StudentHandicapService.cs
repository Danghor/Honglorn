using HonglornBL.Models.Framework;
using System;
using System.Data.Entity;

namespace HonglornBL.MasterData.StudentHandicap
{
    public sealed class StudentHandicapService : EntityService<StudentHandicapManager, Models.Entities.StudentHandicap, IStudentHandicapModel>
    {
        internal StudentHandicapService(HonglornDbFactory contextFactory) : base(contextFactory) { }

        public override StudentHandicapManager CreateManager(Guid pKey)
        {
            return new StudentHandicapManager(pKey, ContextFactory, GetDbSet);
        }

        protected override IDbSet<Models.Entities.StudentHandicap> GetDbSet(HonglornDb context)
        {
            return context.StudentHandicap;
        }
    }
}