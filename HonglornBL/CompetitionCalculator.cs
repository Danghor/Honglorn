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

        internal CompetitionCalculator(bool sprintLowIsBetter, bool jumpLowIsBetter, bool throwLowIsBetter, bool middleDistanceLowIsBetter)
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

        internal IEnumerable<ICompetitionResult> Results()
        {
            IEnumerable<CompetitionCalculatorContainer> containers = from s in studentMeasurements
                                                                     select new CompetitionCalculatorContainer(s.Item1, s.Item2.Sprint, s.Item2.Jump, s.Item2.Throw, s.Item2.MiddleDistance);

            if (sprintLowIsBetter)
            {
                containers = containers.OrderBy(c => c.SprintValue);
            }
            else
            {
                containers = containers.OrderByDescending(c => c.SprintValue);
            }

            float? lastValue = containers.First().SprintValue;
            ushort lastScore = 1;
            ushort count = 1;

            foreach (var c in containers)
            {
                if (c.SprintValue == lastValue)
                {
                    c.SprintScore = lastScore;
                }
                else
                {
                    c.SprintScore = count;
                    lastScore = c.SprintScore;
                    lastValue = c.SprintValue;
                }

                count++;
            }

            return containers;
        }

        void CalculateScoresForDiscipline(IEnumerable<CompetitionCalculatorContainer> containers, bool lowIsBetter, Func<CompetitionCalculatorContainer, float?> selectValue, Func<CompetitionCalculatorContainer, ushort> selectScore)
        {
            if (lowIsBetter)
            {
                containers = containers.OrderBy(selectValue);
            }
            else
            {
                containers = containers.OrderByDescending(selectValue);
            }

            float? lastValue = selectValue(containers.First());
            ushort lastScore = 1;
            ushort count = 1;

            foreach (var c in containers)
            {
                if (selectValue(c) == lastValue)
                {
                    //selectScore(c) = lastScore;
                }
                else
                {
                    c.SprintScore = count;
                    lastScore = c.SprintScore;
                    lastValue = c.SprintValue;
                }

                count++;
            }
        }
    }
}
