using HonglornBL.Enums;
using HonglornBL.Models.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Xml.Serialization;

namespace HonglornBL.Games.Traditional.TrackAndField
{
    public abstract class TraditionalTrackAndFieldDiscipline : Discipline
    {
        [Required]
        public Sex Sex { get; set; }

        [Required]
        public float ConstantA { get; set; }

        [Required]
        public float ConstantC { get; set; }

        [XmlIgnore]
        public virtual ICollection<TraditionalTrackAndFieldDisciplineHandicap> TraditionalTrackAndFieldDisciplineHandicaps { get; set; }

        protected double ValueWithHandicap(Handicap handicap, double value)
        {
            if (handicap != null)
            {
                double factor = (from h in TraditionalTrackAndFieldDisciplineHandicaps
                                 where h.Handicap == handicap
                                 select h.Factor).Single();

                value *= factor;
            }

            return value;
        }

        internal int CalculateScore(Handicap handicap, double? value)
        {
            return value == null ? 0 : CleanScore(CalculateNonNullRawScore(ValueWithHandicap(handicap, value.Value)));
        }

        static int CleanScore(double rawScore)
        {
            return (int)Math.Max(0, Math.Floor(rawScore));
        }

        internal abstract double CalculateNonNullRawScore(double value);
    }
}