using System.Collections.Generic;
using HonglornBL.Import;

namespace HonglornBL.Interfaces
{
    interface IStudentImporter
    {
        ICollection<ImportedStudentRecord> ReadStudentsFromFile(string filePath);
    }
}