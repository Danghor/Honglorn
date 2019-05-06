using HonglornBL.Models.Entities;

namespace HonglornBL
{
    public class MeasuringPoint<TDiscipline> : Entity where TDiscipline : Discipline
    {
        public TDiscipline Discipline { get; set; }

        public double Measurement { get; set; }
    }
}