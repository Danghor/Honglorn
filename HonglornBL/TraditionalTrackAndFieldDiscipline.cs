using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HonglornBL.Models.Entities;

namespace HonglornBL
{
    public abstract class TraditionalTrackAndFieldDiscipline : Discipline
    {
        internal abstract ushort CalculateScore(Student student, double value);
    }
}