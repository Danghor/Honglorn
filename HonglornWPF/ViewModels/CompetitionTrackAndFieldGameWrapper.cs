using System;
using HonglornBL.Game.Competition.TrackAndField;

namespace HonglornWPF.ViewModels
{
    class CompetitionTrackAndFieldGameWrapper : GameWrapper<CompetitionTrackAndFieldGameManager>
    {
        public CompetitionTrackAndFieldGameWrapper(CompetitionTrackAndFieldGameManager manager) : base(manager) { }

        public override string Name => manager.Name;

        public override DateTime Date => manager.Date;

        public override ViewModel CreateViewModel() => new CompetitionTrackAndFieldViewModel();
    }
}