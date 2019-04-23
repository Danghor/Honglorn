using System;
using System.Collections.Generic;
using System.Linq;
using HonglornBL.Properties;

namespace HonglornBL.Import
{
    public class ImportedStudentRecord
    {
        public string ImportedSurname { get; }
        public string ImportedForename { get; }
        public string ImportedCourseName { get; }
        public string ImportedSex { get; }
        public string ImportedYearOfBirth { get; }

        public IEnumerable<FieldErrorInfo> Errors { get; }

        public ImportedStudentRecord(string importedSurname, string importedForename, string importedCourseName, string importedSex, string importedYearOfBirth)
        {
            ImportedSurname = importedSurname;
            ImportedForename = importedForename;
            ImportedCourseName = importedCourseName;
            ImportedSex = importedSex;
            ImportedYearOfBirth = importedYearOfBirth;

            Errors = FieldErrors();
        }

        IEnumerable<FieldErrorInfo> FieldErrors()
        {
            var fieldErrors = new List<FieldErrorInfo>
            {
                FieldError(nameof(ImportedSurname), ImportedSurname, IsValidName, "Surname cannot be empty or contain any digits."),
                FieldError(nameof(ImportedForename), ImportedForename, IsValidName, "Forename cannot be empty or contain any digits."),
                FieldError(nameof(ImportedCourseName), ImportedCourseName, IsValidCourseName, "The course name has to match the regular expression 0?[5-9][A-Za-z]|(E|e)(0[1-9]|[1-9][0-9])."),
                FieldError(nameof(ImportedSex), ImportedSex, IsValidSex, "Sex can only be 'M', 'm', 'W' or 'w'."),
                FieldError(nameof(ImportedYearOfBirth), ImportedYearOfBirth, IsValidYearOfBirth, $"Year of birth must be a four-digit number between {Settings.Default.MinValidYear} and {Settings.Default.MaxValidYear}.")
            };

            fieldErrors.RemoveAll(e => e == null);

            return fieldErrors.Any() ? fieldErrors : null;
        }

        static FieldErrorInfo FieldError(string fieldName, string fieldContent, Func<string, bool> isValid, string errorMessage)
        {
            return isValid(fieldContent) ? null : new FieldErrorInfo(fieldName, fieldContent, errorMessage);
        }

        static readonly Func<string, bool> IsValidName = (name) =>
        {
            return !string.IsNullOrWhiteSpace(name) && !name.Any(char.IsDigit);
        };

        static readonly Func<string, bool> IsValidCourseName = (courseName) =>
        {
            // TODO: verify if entity exists in database
            return true;
        };

        static readonly Func<string, bool> IsValidSex = (sex) =>
        {
            return sex.Equals("W", StringComparison.InvariantCultureIgnoreCase) || sex.Equals("M", StringComparison.InvariantCultureIgnoreCase);
        };

        static readonly Func<string, bool> IsValidYearOfBirth = (year) =>
        {
            bool isValid = false;

            if (short.TryParse(year, out short shortYear))
            {
                isValid = Prerequisites.IsValidYear(shortYear);
            }

            return isValid;
        };
    }
}