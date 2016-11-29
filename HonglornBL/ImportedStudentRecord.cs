using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace HonglornBL {
  class ImportedStudentRecord {
    string ImportedSurname { get; }
    string ImportedForename { get; }
    string ImportedCourseName { get; }
    string ImportedSex { get; }
    string ImportedYearOfBirth { get; }

    RecordErrorInfo Error { get; }

    //is it valid? which field is invalid? whats the content?
    public ImportedStudentRecord(string importedSurname, string importedForename, string importedCourseName, string importedSex, string importedYearOfBirth) {
      ImportedSurname = importedSurname;
      ImportedForename = importedForename;
      ImportedCourseName = importedCourseName;
      ImportedSex = importedSex;
      ImportedYearOfBirth = importedYearOfBirth;
    }

    void ValidateFields() {
      
    }

    static FieldErrorInfo ValidateField(string fieldName, string fieldContent, Func<string, bool> isValid, string errorMessage) {
      FieldErrorInfo result = null;

      if (!isValid(fieldContent)) {
        result = new FieldErrorInfo(fieldName, fieldContent, errorMessage);
      }

      return result;
    }

    FieldErrorInfo ValidateSurname() {
      FieldErrorInfo result = null;

      if (string.IsNullOrWhiteSpace(ImportedSurname)) {
        result = new FieldErrorInfo(nameof(ImportedSurname), ImportedSurname, $"Expected {nameof(ImportedSurname)} to be a non-empty string.");
      }

      return result;
    }
  }

  class RecordErrorInfo {
    ICollection<FieldErrorInfo> FieldErrorInfos { get; }

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
