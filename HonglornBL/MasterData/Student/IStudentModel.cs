using System;

namespace HonglornBL.MasterData.Student
{
    public interface IStudentModel
    {
        string Surname { get; }
        string Forename { get; }
        Sex Sex { get; }
        DateTime DateOfBirth { get; }
    }
}