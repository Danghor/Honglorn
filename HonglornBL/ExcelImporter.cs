using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using Microsoft.Office.Interop.Excel;
using static HonglornBL.Prerequisites;

namespace HonglornBL {
  public static class ExcelImporter {
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
    internal static IEnumerable<Student> GetStudentArrayFromExcelFile(string filePath) {
      List<Student> importedStudents = new List<Student>();

      if (string.IsNullOrWhiteSpace(filePath)) {
        throw new ArgumentException("File path is null, empty or consist of only white-space characters.");
      }

      _Application excelInstance = null;
      _Workbook workbook = null;

      try {
        excelInstance = new Application();
        workbook = excelInstance.Workbooks.Open(filePath);
        _Worksheet worksheet = workbook.Worksheets[0];

        ValidateHeaderRow(worksheet);

        //import content
        //todo: handle half-empty rows correctly! (Error message and removal from DataTable, so it's not imported)
        int rowIdx = 1;
        bool rowIsEmpty = false;
        while (!rowIsEmpty) {
          string surname = GetText(worksheet, $"A{rowIdx}");
          string forename = GetText(worksheet, $"B{rowIdx}");
          string courseName = GetText(worksheet, $"C{rowIdx}");
          string rawSex = GetText(worksheet, $"D{rowIdx}");
          string rawYearOfBirth = GetText(worksheet, $"E{rowIdx}");

          rowIsEmpty = CoalesceIsNullOrWhitespace(surname, forename, courseName, rawSex, rawYearOfBirth);

          if (!rowIsEmpty) {
            Sex sex = SexDictionary[rawSex];
            uint yearOfBirth = Convert.ToUInt32(rawYearOfBirth);
            importedStudents.Add(new Student(surname, forename, yearOfBirth, sex, courseName));
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

    static string GetText(_Worksheet sheet, string range) {
      return sheet.Range[range].Text;
    }

    static void ValidateHeaderRow(_Worksheet sheet) {
      ValidateString(SURNAME_HEADER_COLUMN, GetText(sheet, "A1"));
      ValidateString(FORENAME_HEADER_COLUMN, GetText(sheet, "B1"));
      ValidateString(COURSENAME_HEADER_COLUMN, GetText(sheet, "C1"));
      ValidateString(SEX_HEADER_COLUMN, GetText(sheet, "D1"));
      ValidateString(YEAROFBIRTH_HEADER_COLUMN, GetText(sheet, "E1"));
    }

    static void ValidateString(string expected, string actual) {
      if (expected != actual) {
        throw new ArgumentException($"Header row was in unexpected condition. Expected {expected} but was {actual}.");
      }
    }

    static bool CoalesceIsNullOrWhitespace(params string[] args) {
      return args.All(string.IsNullOrWhiteSpace);
    }
  }
}