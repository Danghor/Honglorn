using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using Microsoft.Office.Interop.Excel;
using static HonglornBL.Prerequisites;

namespace HonglornBL {
  static class ExcelImporter {
    const string SURNAME_HEADER_COLUMN = "Nachname";
    const string FORENAME_HEADER_COLUMN = "Vorname";
    const string COURSENAME_HEADER_COLUMN = "Kursbezeichnung";
    const string SEX_HEADER_COLUMN = "Geschlecht";
    const string YEAROFBIRTH_HEADER_COLUMN = "Geburtsjahr";

    static readonly Dictionary<string, Sex> SexDictionary = new Dictionary<string, Sex> {
      {"W", Sex.Female},
      {"M", Sex.Male}
    };

    /// <summary>
    ///   Takes a file path as a string as input and returns a DataTable containing the extracted data.
    ///   Designed to work together with the DBHandler to import the data into the database.
    /// </summary>
    /// <param name="filePath">The file path of the Excel-file containing the relevant data.</param>
    internal static ICollection<ImportStudent> GetStudentDataTableFromExcelFile(string filePath) {
      if (string.IsNullOrWhiteSpace(filePath)) {
        throw new ArgumentException("File path is null, empty or consist of only white-space characters.");
      }

      ICollection<ImportStudent> importedStudents = new List<ImportStudent>();

      _Application excelInstance = null;
      _Workbook workbook = null;

      try {
        excelInstance = new Application();
        workbook = excelInstance.Workbooks.Open(filePath);
        _Worksheet worksheet = workbook.Worksheets[1];

        ValidateHeaderRow(worksheet);

        //import content
        //todo: handle half-empty rows correctly! (Error message and removal from DataTable, so it's not imported)
        int rowIdx = 2;
        bool rowIsEmpty = false;
        while (!rowIsEmpty) {
          string surname = GetTextFromRange(worksheet, $"A{rowIdx}");
          string forename = GetTextFromRange(worksheet, $"B{rowIdx}");
          string courseName = GetTextFromRange(worksheet, $"C{rowIdx}");
          string rawSex = GetTextFromRange(worksheet, $"D{rowIdx}");
          string rawYearOfBirth = GetTextFromRange(worksheet, $"E{rowIdx}");

          rowIsEmpty = CoalesceIsNullOrWhitespace(surname, forename, courseName, rawSex, rawYearOfBirth);

          if (!rowIsEmpty) {
            Sex sex;
            if (SexDictionary.TryGetValue(rawSex, out sex)) {
              short yearOfBirth = Convert.ToInt16(rawYearOfBirth);
              if (IsValidYear(yearOfBirth)) {
                importedStudents.Add(new ImportStudent(surname, forename, courseName, sex, yearOfBirth));
              }
            }
          }

          rowIdx++;
        }
      } finally {
        workbook?.Close();
        excelInstance?.Quit();

        if (workbook != null) {
          Marshal.ReleaseComObject(workbook);
        }

        if (excelInstance != null) {
          Marshal.ReleaseComObject(excelInstance);
        }
      }

      return importedStudents;
    }

    static string GetTextFromRange(_Worksheet sheet, string range) {
      return sheet.Range[range].Text;
    }

    static void ValidateHeaderRow(_Worksheet sheet) {
      ValidateString(SURNAME_HEADER_COLUMN, GetTextFromRange(sheet, "A1"));
      ValidateString(FORENAME_HEADER_COLUMN, GetTextFromRange(sheet, "B1"));
      ValidateString(COURSENAME_HEADER_COLUMN, GetTextFromRange(sheet, "C1"));
      ValidateString(SEX_HEADER_COLUMN, GetTextFromRange(sheet, "D1"));
      ValidateString(YEAROFBIRTH_HEADER_COLUMN, GetTextFromRange(sheet, "E1"));
    }

    static void ValidateString(string expected, string actual) {
      if (!actual.Equals(expected, StringComparison.InvariantCulture)) {
        throw new ArgumentException($"Header row was in unexpected condition. Expected {expected} but was {actual}.");
      }
    }

    static bool CoalesceIsNullOrWhitespace(params string[] args) {
      return args.All(string.IsNullOrWhiteSpace);
    }
  }
}