using System.Collections.Generic;

namespace HonglornBL.Import
{
    abstract class StudentImporter : IStudentImporter
    {
        public abstract ICollection<ImportedStudentRecord> ReadStudentsFromFile(string filePath);
    }
}
