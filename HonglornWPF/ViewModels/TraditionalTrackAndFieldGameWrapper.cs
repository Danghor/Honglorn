using System;
using HonglornBL.Game.Traditional.TrackAndField;

namespace HonglornWPF.ViewModels
{
    class TraditionalTrackAndFieldGameWrapper : GameWrapper<TraditionalTrackAndFieldGameManager>
    {
        public TraditionalTrackAndFieldGameWrapper(TraditionalTrackAndFieldGameManager manager) : base(manager) { }

        public override string Name => manager.Name;

        public override DateTime Date => manager.Date;
    }
}