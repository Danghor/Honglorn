using System.Collections.Generic;

namespace HonglornBL.Import
{
    abstract class StudentImporter : IStudentImporter
    {
        protected const string SurnameHeaderColumn = "Nachname";
        protected const string ForenameHeaderColumn = "Vorname";
        protected const string CoursenameHeaderColumn = "Kursbezeichnung";
        protected const string SexHeaderColumn = "Geschlecht";
        protected const string YearofbirthHeaderColumn = "Geburtsjahr";

        public abstract ICollection<ImportedStudentRecord> ReadStudentsFromFile(string filePath);
    }
}