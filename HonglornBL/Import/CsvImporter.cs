using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace HonglornBL.Import
{
    class CsvImporter : StudentImporter
    {
        public override ICollection<ImportedStudentRecord> ReadStudentsFromFile(string filePath)
        {
            if (string.IsNullOrWhiteSpace(filePath))
            {
                throw new ArgumentException("File path is null, empty or consist of only white-space characters.");
            }

            ICollection<ImportedStudentRecord> extractedStudents = new List<ImportedStudentRecord>();

            using (var reader = new StreamReader(filePath))
            {
                if (!reader.EndOfStream)
                {
                    string[] headerValues = reader.ReadLine()?.Split(',');
                    if (!headerValues.SequenceEqual(new [] { "Nachname", "Vorname", "Kursbezeichnung", "Geschlecht", "Geburtsjahr" }))
                    {
                        throw new ArgumentException("Header row was not in the expected condition.");
                    }
                }

                while (!reader.EndOfStream)
                {
                    string[] row = reader.ReadLine()?.Split(',');
                    extractedStudents.Add(new ImportedStudentRecord(row?[0], row?[1], row?[2], row?[3], row?[4]));
                }
            }

            return extractedStudents;
        }
    }
}
