using System.Linq;
using HonglornBL.Models.Entities;
using HonglornBL.Models.Framework;

namespace HonglornBL.Game.Traditional.TrackAndField
{
    public class TraditionalTrackAndFieldPerformance : GamePerformance<TraditionalTrackAndFieldMeasuringPoint, TraditionalTrackAndFieldDiscipline, TraditionalTrackAndFieldPerformance>
    {
        internal TraditionalTrackAndFieldResult CalculateResult(HonglornDb context)
        {
            var handicap = (from h in Student.StudentHandicaps
                            where h.DateStart >= Game.Date && (h.DateEnd == null || h.DateEnd <= Game.Date)
                            select h.Handicap).SingleOrDefault();

            var totalScore = MeasuringPoints.Select(m => m.CalculateScore(handicap)).OrderByDescending(i => i).Take(3).Sum();

            var certificateType = DetermineCertificateType(context, totalScore);

            return new TraditionalTrackAndFieldResult(totalScore, certificateType, Student);
        }

        CertificateType DetermineCertificateType(HonglornDb context, int totalScore)
        {
            var studentAge = Game.Date.Year - Student.DateOfBirth.Year;

            var scoreBoundaries = (from a in context.TraditionalTrackAndFieldCertificateAssignment
                                   where a.Sex == Student.Sex && a.Age <= studentAge
                                   orderby a.Age descending
                                   select new { a.MinimumHonoraryCertificateScore, a.MinimumVictoryCertificateScore }).First();

            CertificateType certificateType;

            if (totalScore >= scoreBoundaries.MinimumHonoraryCertificateScore)
            {
                certificateType = CertificateType.Honorary;
            }
            else if (totalScore >= scoreBoundaries.MinimumVictoryCertificateScore)
            {
                certificateType = CertificateType.Victory;
            }
            else
            {
                certificateType = CertificateType.Participation;
            }

            return certificateType;
        }
    }
}