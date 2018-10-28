using HonglornBL.Enums;

namespace HonglornBL
{
    public class Result : IResult
    {
        public string Forename { get; }
        public string Surname { get; }
        public ushort Score { get; }
        public Certificate Certificate { get; }

        internal Result(string forename, string surname, ushort score, Certificate certificate)
        {
            Forename = forename;
            Surname = surname;
            Score = score;
            Certificate = certificate;
        }
    }
}
