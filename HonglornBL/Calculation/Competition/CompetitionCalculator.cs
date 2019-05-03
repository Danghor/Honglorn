using HonglornBL.Enums;
using System;
using System.Collections.Generic;
using System.Linq;

namespace HonglornBL.Calculation.Competition
{
    class CompetitionCalculator
    {
        readonly ICollection<RawMeasurement> studentMeasurements;
        readonly bool sprintLowIsBetter;
        readonly bool jumpLowIsBetter;
        readonly bool throwLowIsBetter;
        readonly bool middleDistanceLowIsBetter;

        internal CompetitionCalculator(bool sprintLowIsBetter, bool jumpLowIsBetter, bool throwLowIsBetter, bool middleDistanceLowIsBetter)
        {
            studentMeasurements = new List<RawMeasurement>();
            this.sprintLowIsBetter = sprintLowIsBetter;
            this.jumpLowIsBetter = jumpLowIsBetter;
            this.throwLowIsBetter = throwLowIsBetter;
            this.middleDistanceLowIsBetter = middleDistanceLowIsBetter;
        }

        internal void AddStudentMeasurement(Guid identifier, float? sprint, float? jump, float? @throw, float? middleDistance) => studentMeasurements.Add(new RawMeasurement(identifier, sprint, jump, @throw, middleDistance));

        internal IEnumerable<ICompetitionResult> Results()
        {
            ICollection<CompetitionCalculatorContainer> containers = (from s in studentMeasurements
                                                                      select new CompetitionCalculatorContainer(s.Id, s.Sprint, s.Jump, s.Throw, s.MiddleDistance)).ToList();

            CalculateScoresForDiscipline(containers, sprintLowIsBetter, c => c.SprintValue, (c, s) => c.SprintScore = s);
            CalculateScoresForDiscipline(containers, jumpLowIsBetter, c => c.JumpValue, (c, s) => c.JumpScore = s);
            CalculateScoresForDiscipline(containers, throwLowIsBetter, c => c.ThrowValue, (c, s) => c.ThrowScore = s);
            CalculateScoresForDiscipline(containers, middleDistanceLowIsBetter, c => c.MiddleDistanceValue, (c, s) => c.MiddleDistanceScore = s);

            CalculateScoresForDiscipline(containers, true, c => c.TotalScore, (c, r) => c.Rank = r);

            containers = containers.OrderBy(c => c.Rank).ToList();

            int lastRank = containers.First().Rank;
            var currentCertificate = CertificateType.Honorary;
            var count = 0;

            foreach (CompetitionCalculatorContainer container in containers)
            {
                if (container.Rank != lastRank)
                {
                    float percentile = (float)count / containers.Count * 100;

                    if (percentile > 70)
                    {
                        currentCertificate = CertificateType.Participation;
                    }
                    else if (percentile > 20)
                    {
                        currentCertificate = CertificateType.Victory;
                    }

                    lastRank = container.Rank;
                }

                container.Certificate = currentCertificate;
                count++;
            }

            return containers;
        }

        static void CalculateScoresForDiscipline(ICollection<CompetitionCalculatorContainer> containers, bool lowIsBetter, Func<CompetitionCalculatorContainer, float?> selectValue, Action<CompetitionCalculatorContainer, ushort> setScore)
        {
            var sortedContainers = containers.OrderBy(c => selectValue(c) == null);

            containers = lowIsBetter ? sortedContainers.ThenBy(selectValue).ToList() : sortedContainers.ThenByDescending(selectValue).ToList();

            float? lastValue = selectValue(containers.First());
            ushort lastScore = 1;
            ushort count = 1;

            var comparer = new FloatComparer();

            foreach (CompetitionCalculatorContainer c in containers)
            {
                if (comparer.Equals(selectValue(c), lastValue))
                {
                    setScore(c, lastScore);
                }
                else
                {
                    setScore(c, count);
                    lastScore = count;
                    lastValue = selectValue(c);
                }

                count++;
            }
        }
    }
}