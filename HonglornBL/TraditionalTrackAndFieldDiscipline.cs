using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HonglornBL.Models.Entities;

namespace HonglornBL
{
    public abstract class TraditionalTrackAndFieldDiscipline : Discipline
    {
        internal int CalculateScore(Student student, double? value)
        {
            return value == null ? 0 : CalculateNonNullScore(student, value.Value);
        }

        internal abstract int CalculateNonNullScore(Student student, double value);
    }
}