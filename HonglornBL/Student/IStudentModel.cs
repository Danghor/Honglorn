using HonglornBL.Enums;
using System;

namespace HonglornBL.Models.Entities
{
    public interface IStudentModel
    {
        string Surname { get; }
        string Forename { get; }
        Sex Sex { get; }
        DateTime DateOfBirth { get; }
    }
}