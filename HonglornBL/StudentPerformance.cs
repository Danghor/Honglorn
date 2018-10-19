using System;

namespace HonglornBL
{
    class StudentPerformance : IStudentPerformance
    {
        public Guid StudentPKey { get; }
        public string Forename { get; }
        public string Surname { get; }
        public float? Sprint { get; }
        public float? Jump { get; }
        public float? Throw { get; }
        public float? MiddleDistance { get; }

        internal StudentPerformance(Guid studentPKey, string forename, string surname, float? sprint, float? jump, float? @throw, float? middleDistance)
        {
            StudentPKey = studentPKey;
            Forename = forename;
            Surname = surname;
            Sprint = sprint;
            Jump = jump;
            Throw = @throw;
            MiddleDistance = middleDistance;
        }
    }
}
