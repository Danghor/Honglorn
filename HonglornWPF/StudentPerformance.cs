using HonglornBL;
using System;

namespace HonglornWPF
{
    class StudentPerformance : IStudentPerformance
    {
        public Guid StudentPKey { get; }
        public string Forename { get; }
        public string Surname { get; }
        public float? Sprint { get; set; }
        public float? Jump { get; set; }
        public float? Throw { get; set; }
        public float? MiddleDistance { get; set; }

        internal StudentPerformance(IStudentPerformance interfaceObject)
        {
            StudentPKey = interfaceObject.StudentPKey;
            Forename = interfaceObject.Forename;
            Surname = interfaceObject.Surname;
            Sprint = interfaceObject.Sprint;
            Jump = interfaceObject.Jump;
            Throw = interfaceObject.Throw;
            MiddleDistance = interfaceObject.MiddleDistance;
        }
    }
}
