using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HonglornBL
{
    class CompetitionCalculator
    {
        ICollection<Tuple<Guid, RawMeasurement>> studentMeasurements;
        bool sprintLowIsBetter;
        bool jumpLowIsBetter;
        bool throwLowIsBetter;
        bool middleDistanceLowIsBetter;

        internal CompetitionCalculator(CompetitionDisciplineContainer competitionDisciplineContainer, bool sprintLowIsBetter, bool jumpLowIsBetter, bool throwLowIsBetter, bool middleDistanceLowIsBetter)
        {
            studentMeasurements = new List<Tuple<Guid, RawMeasurement>>();
            this.sprintLowIsBetter = sprintLowIsBetter;
            this.jumpLowIsBetter = jumpLowIsBetter;
            this.throwLowIsBetter = throwLowIsBetter;
            this.middleDistanceLowIsBetter = middleDistanceLowIsBetter;
        }

        internal void AddStudentMeasurement(Guid identifier, RawMeasurement measurement)
        {
            studentMeasurements.Add(new Tuple<Guid, RawMeasurement>(identifier, measurement));
        }

        IEnumerable<CompetitionResult> Results()
        {
            List<CompetitionResult> results = (from t in studentMeasurements
                                               select new CompetitionResult(t.Item1)).ToList();



            if (sprintLowIsBetter)
            {
                var sprintMeasurements = from s in studentMeasurements
                                         orderby s.Item2.Sprint ascending
                                         select s;
            }
            else
            {
                var sprintMeasurements = from s in studentMeasurements
                                         orderby s.Item2.Sprint descending
                                         select s;
            }



            throw new NotImplementedException();
        }
    }
}
