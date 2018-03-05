using System;
using System.Collections.Generic;
using System.Linq;
using HonglornBL.Properties;

namespace HonglornBL.Import
{
    class ImportedStudentRecord
    {
        internal string ImportedSurname { get; }
        internal string ImportedForename { get; }
        internal string ImportedCourseName { get; }
        internal string ImportedSex { get; }
        internal string ImportedYearOfBirth { get; }

        internal RecordErrorInfo Error { get; private set; }

        public ImportedStudentRecord(string importedSurname, string importedForename, string importedCourseName, string importedSex, string importedYearOfBirth)
        {
            ImportedSurname = importedSurname;
            ImportedForename = importedForename;
            ImportedCourseName = importedCourseName;
            ImportedSex = importedSex;
            ImportedYearOfBirth = importedYearOfBirth;

            ValidateFields();
        }

        void ValidateFields()
        {
            List<FieldErrorInfo> fieldErrors = new List<FieldErrorInfo>
            {
                FieldError(nameof(ImportedSurname), ImportedSurname, IsValidName, "Surname cannot be empty or contain any digits."),
                FieldError(nameof(ImportedForename), ImportedForename, IsValidName, "Forename cannot be empty or contain any digits."),
                FieldError(nameof(ImportedCourseName), ImportedCourseName, IsValidCourseName, "The course name has to match the regular expression 0?[5-9][A-Za-z]|(E|e)(0[1-9]|[1-9][0-9])."),
                FieldError(nameof(ImportedSex), ImportedSex, IsValidSex, "Sex can only be 'M', 'm', 'W' or 'w'."),
                FieldError(nameof(ImportedYearOfBirth), ImportedYearOfBirth, IsValidYearOfBirth, $"Year of birth must be a four-digit number between {Settings.Default.MinValidYear} and {Settings.Default.MaxValidYear}.")
            };

            fieldErrors.RemoveAll(e => e == null);

            if (fieldErrors.Any())
            {
                Error = new RecordErrorInfo(fieldErrors);
            }
        }

        static FieldErrorInfo FieldError(string fieldName, string fieldContent, Func<string, bool> isValid, string errorMessage)
        {
            FieldErrorInfo result = null;

            if (!isValid(fieldContent))
            {
                result = new FieldErrorInfo(fieldName, fieldContent, errorMessage);
            }

            return result;
        }

        static readonly Func<string, bool> IsValidName = delegate (string name)
        {
            return !string.IsNullOrWhiteSpace(name) && !name.Any(c => char.IsDigit(c));
        };

        static readonly Func<string, bool> IsValidCourseName = delegate (string courseName)
        {
            bool isValid = true;

            try
            {
                Prerequisites.GetClassName(courseName);
            }
            catch
            {
                isValid = false;
            }

            return isValid;
        };

        static readonly Func<string, bool> IsValidSex = delegate (string sex)
        {
            return sex.Equals("W", StringComparison.InvariantCultureIgnoreCase) || sex.Equals("M", StringComparison.InvariantCultureIgnoreCase);
        };

        static readonly Func<string, bool> IsValidYearOfBirth = delegate (string year)
        {
            bool isValid = false;
            short shortYear;

            if (short.TryParse(year, out shortYear))
            {
                isValid = Prerequisites.IsValidYear(shortYear);
            }

            return isValid;
        };
    }
}