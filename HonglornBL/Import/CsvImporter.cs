using System;
using System.Collections.Generic;
using System.IO;
using HonglornBL.Interfaces;

namespace HonglornBL.Import
{
    class CsvImporter : IStudentImporter
    {
        ICollection<ImportedStudentRecord> IStudentImporter.ReadStudentsFromFile(string filePath)
        {
            if (string.IsNullOrWhiteSpace(filePath))
            {
                throw new ArgumentException("File path is null, empty or consist of only white-space characters.");
            }

            ICollection<ImportedStudentRecord> extractedStudents = new List<ImportedStudentRecord>();

            using (var reader = new StreamReader(filePath))
            {
                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    var values = line.Split(';');

                }
            }

            throw new NotImplementedException();
        }
    }
}
