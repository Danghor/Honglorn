using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HonglornBL.Models.Entities;

namespace HonglornBL
{
    public class TraditionalTrackAndFieldThrowDiscipline : TraditionalTrackAndFieldDiscipline
    {
        internal override int CalculateNonNullScore(Student student, double value)
        {
            throw new NotImplementedException();
        }
    }
}