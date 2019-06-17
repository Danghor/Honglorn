using System;
using HonglornBL;

namespace HonglornWPF.ViewModels
{
    class CompetitionTrackAndFieldGameWrapper : GameWrapper<CompetitionTrackAndFieldGameManager>
    {
        public CompetitionTrackAndFieldGameWrapper(CompetitionTrackAndFieldGameManager manager) : base(manager) { }

        public override string Name => manager.Name;

        public override DateTime Date => manager.Date;
    }
}