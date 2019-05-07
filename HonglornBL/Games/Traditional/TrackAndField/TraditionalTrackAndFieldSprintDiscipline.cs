using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using HonglornBL.Models.Entities;

namespace HonglornBL.Games.Traditional.TrackAndField
{
    public class TraditionalTrackAndFieldSprintDiscipline : TraditionalTrackAndFieldDiscipline
    {
        [Required]
        public Measurement Measurement { get; set; }

        public float? Overhead { get; set; }

        internal override double CalculateNonNullRawScore(Student student, double value)
        {
            throw new NotImplementedException();
        }
    }
}