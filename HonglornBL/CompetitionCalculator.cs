using System;
using System.Collections.Generic;
using System.Linq;

namespace HonglornBL
{
    class CompetitionCalculator
    {
        readonly ICollection<Tuple<Guid, RawMeasurement>> studentMeasurements;
        readonly bool sprintLowIsBetter;
        readonly bool jumpLowIsBetter;
        readonly bool throwLowIsBetter;
        readonly bool middleDistanceLowIsBetter;

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
            ICollection<CompetitionCalculatorContainer> containers = (from s in studentMeasurements
                                                                      select new CompetitionCalculatorContainer(s.Item1, s.Item2.Sprint, s.Item2.Jump, s.Item2.Throw, s.Item2.MiddleDistance)).ToList();

            CalculateScoresForDiscipline(containers, sprintLowIsBetter, c => c.SprintValue, c => c.SprintScore, (c, s) => c.SprintScore = s);
            CalculateScoresForDiscipline(containers, jumpLowIsBetter, c => c.JumpValue, c => c.JumpScore, (c, s) => c.JumpScore = s);
            CalculateScoresForDiscipline(containers, throwLowIsBetter, c => c.ThrowValue, c => c.ThrowScore, (c, s) => c.ThrowScore = s);
            CalculateScoresForDiscipline(containers, middleDistanceLowIsBetter, c => c.MiddleDistanceValue, c => c.MiddleDistanceScore, (c, s) => c.MiddleDistanceScore = s);

            return containers;
        }

        static void CalculateScoresForDiscipline(ICollection<CompetitionCalculatorContainer> containers, bool lowIsBetter, Func<CompetitionCalculatorContainer, float?> selectValue, Func<CompetitionCalculatorContainer, ushort> selectScore, Action<CompetitionCalculatorContainer, ushort> setScore)
        {
            if (lowIsBetter)
            {
                containers = containers.OrderBy(c => selectValue(c) == null).ThenBy(selectValue).ToList();
            }
            else
            {
                containers = containers.OrderBy(c => selectValue(c) == null).ThenByDescending(selectValue).ToList();
            }

            float? lastValue = selectValue(containers.First());
            ushort lastScore = 1;
            ushort count = 1;

            foreach (CompetitionCalculatorContainer c in containers)
            {
                if (selectValue(c) == lastValue)
                {
                    setScore(c, lastScore);
                }
                else
                {
                    setScore(c, count);
                    lastScore = selectScore(c);
                    lastValue = selectValue(c);
                }

                count++;
            }
        }
    }
}
