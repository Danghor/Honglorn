using System;

namespace HonglornWPF
{
    class StudentCompetition
    {
        // Student
        public Guid StudentPKey { get; set; }
        public string Forename { get; set; }
        public string Surname { get; set; }

        // Competition
        public float? Sprint { get; set; }
        public float? Jump { get; set; }
        public float? Throw { get; set; }
        public float? MiddleDistance { get; set; }
    }
}