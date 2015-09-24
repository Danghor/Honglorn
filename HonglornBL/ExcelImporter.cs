using System;
using System.Data;
using System.Runtime.InteropServices;
using Microsoft.Office.Interop.Excel;
using DataTable = System.Data.DataTable;

namespace HonglornBL {
  public static class ExcelImporter {
    static readonly string[] EXPECTED_HEADER_COLUMN_NAMES = {
      "Nachname",
      "Vorname",
      "Kursbezeichnung",
      "Geschlecht",
      "Geburtsjahr"
    };

    /// <summary>
    ///   Takes a file path as a string as input and returns a DataTable containing the extracted data.
    ///   Designed to work together with the DBHandler to import the data into the database.
    /// </summary>
    /// <param name="filePath">The file path of the Excel-file containing the relevant data.</param>
    internal static DataTable GetStudentCourseDataTable(string filePath) {
      DataTable result;
      if (string.IsNullOrWhiteSpace(filePath)) {
        throw new ArgumentException("File path is null, empty or consist of only white-space characters.");
      }

      Application excelInstance = null;
      Workbook workbook = null;

      try {
        excelInstance = new Application();
        workbook = excelInstance.Workbooks.Open(filePath);
        Worksheet worksheet = workbook.Worksheets[0];

        //validate header row
        for (int colIdx = 0; colIdx <= EXPECTED_HEADER_COLUMN_NAMES.Length - 1; colIdx++) {
          string actualHeader = worksheet.Range[Prerequisites.ALPHABET[colIdx] + "1"].Text;
          string expectedHeader = EXPECTED_HEADER_COLUMN_NAMES[colIdx];
          if (actualHeader != expectedHeader) {
            throw new ArgumentException(
              $"Column {colIdx + 1} in Row 1 was named '{actualHeader}. Expected '{expectedHeader}'.");
          }
        }

        //create DataTable and initialize column names
        result = new DataTable();
        for (int colIdx = 0; colIdx <= EXPECTED_HEADER_COLUMN_NAMES.Length - 1; colIdx++) {
          result.Columns.Add(EXPECTED_HEADER_COLUMN_NAMES[colIdx]);
        }

        //import content
        int iCurrentRow = 2;

        bool bRowIsEmpty;

        //todo: handle half-empty rows correctly! (Error message and removal from DataTable, so it's not imported)
        do {
          bRowIsEmpty = true;
          DataRow oNewDataRow = result.NewRow();

          //read one row
          for (int iColIdx = 0; iColIdx <= EXPECTED_HEADER_COLUMN_NAMES.Length - 1; iColIdx++) {
            string sCurrentCell =
              Convert.ToString(worksheet.Range[Prerequisites.ALPHABET[iColIdx] + Convert.ToString(iCurrentRow)].Text);
            oNewDataRow[iColIdx] = sCurrentCell;

            if (!string.IsNullOrWhiteSpace(sCurrentCell)) {
              bRowIsEmpty = false;
            }
          }

          //add row to DataTable, if it contains at least one entry
          if (!bRowIsEmpty) {
            result.Rows.Add(oNewDataRow);
          }

          iCurrentRow += 1;
        } while (!(bRowIsEmpty));
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

      return result;
    }
  }
}