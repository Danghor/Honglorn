using HonglornBL.Enums;
using HonglornBL.Models.Entities;

namespace HonglornBL
{
    public interface IStudentResult
    {
        int TotalScore { get; }
        CertificateType CertificateType { get; }
        GamePerformance<Discipline> GamePerformance { get; set; }
        IPdfDocument Certificate { get; }
    }
}