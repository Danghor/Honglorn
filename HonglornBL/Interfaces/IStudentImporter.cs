using System.Collections.Generic;
using HonglornBL.Import;

namespace HonglornBL.Interfaces
{
    internal interface IStudentImporter
    {
        ICollection<ImportedStudentRecord> ReadStudentsFromFile(string filePath);
    }
}