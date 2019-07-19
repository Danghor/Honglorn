using System;

namespace HonglornBL.Models.Entities
{
    public interface IMeasuringPoint
    {
        Guid DisciplinePKey { get; }
        double Measurement { get; }
    }
}