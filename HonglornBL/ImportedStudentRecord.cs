using System;
using System.Collections.Generic;
using System.Linq;

namespace HonglornBL {
  class ImportedStudentRecord {
    string ImportedSurname { get; }
    string ImportedForename { get; }
    string ImportedCourseName { get; }
    string ImportedSex { get; }
    string ImportedYearOfBirth { get; }

    internal RecordErrorInfo Error { get; private set; }

    //is it valid? which field is invalid? whats the content?
    public ImportedStudentRecord(string importedSurname, string importedForename, string importedCourseName, string importedSex, string importedYearOfBirth) {
      ImportedSurname = importedSurname;
      ImportedForename = importedForename;
      ImportedCourseName = importedCourseName;
      ImportedSex = importedSex;
      ImportedYearOfBirth = importedYearOfBirth;
    }

    void ValidateFields() {
      List<FieldErrorInfo> fieldErrors = new List<FieldErrorInfo> {
        FieldError(nameof(ImportedSurname), ImportedSurname, IsValidName, "Surname cannot be empty or contain any digits."),
        FieldError(nameof(ImportedForename), ImportedForename, IsValidName, "Forename cannot be empty or contain any digits."),
        FieldError(nameof(ImportedSex), ImportedSex, IsValidSex, "Sex can only be 'M', 'm', 'W' or 'w'.")
      };

      fieldErrors.RemoveAll(e => e == null);

      if (fieldErrors.Any()) {
        Error = new RecordErrorInfo(fieldErrors);
      }
    }

    static FieldErrorInfo FieldError(string fieldName, string fieldContent, Func<string, bool> isValid, string errorMessage) {
      FieldErrorInfo result = null;

      if (!isValid(fieldContent)) {
        result = new FieldErrorInfo(fieldName, fieldContent, errorMessage);
      }

      return result;
    }

    static readonly Func<string, bool> IsValidName = name => !string.IsNullOrWhiteSpace(name) && !name.Any(c => char.IsDigit(c));
    static readonly Func<string, bool> IsValidSex = sex => sex.Equals("W", StringComparison.InvariantCultureIgnoreCase) || sex.Equals("M", StringComparison.InvariantCultureIgnoreCase);
    static readonly Func<string, bool> IsValidYearOfBirth = delegate (string year) {
                                                              bool isValid = false;
                                                              short shortYear;

                                                              if (short.TryParse(year, out shortYear)) {
                                                                isValid = Prerequisites.IsValidYear(shortYear);
                                                              }

                                                              return isValid;
                                                            };
  }

  class RecordErrorInfo {
    internal ICollection<FieldErrorInfo> FieldErrorInfos { get; }

    public RecordErrorInfo(ICollection<FieldErrorInfo> fieldErrorInfos) {
      FieldErrorInfos = fieldErrorInfos;
    }
  }

  class FieldErrorInfo {
    string FieldName { get; }
    string FieldContent { get; }
    string Message { get; }

    public FieldErrorInfo(string fieldName, string fieldContent, string message) {
      FieldName = fieldName;
      FieldContent = fieldContent;
      Message = message;
    }
  }
}
