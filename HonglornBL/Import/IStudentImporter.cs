using System.Collections.Generic;

namespace HonglornBL.Import
{
    interface IStudentImporter
    {
        ICollection<ImportedStudentRecord> ReadStudentsFromFile(string filePath);
    }
}