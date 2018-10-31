using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using HonglornBL.Interfaces;
using Microsoft.Office.Interop.Excel;

namespace HonglornBL.Import
{
    class ExcelImporter : IStudentImporter
    {
        const string SurnameHeaderColumn = "Nachname";
        const string ForenameHeaderColumn = "Vorname";
        const string CoursenameHeaderColumn = "Kursbezeichnung";
        const string SexHeaderColumn = "Geschlecht";
        const string YearofbirthHeaderColumn = "Geburtsjahr";

        /// <summary>
        ///     Takes a file path as a string as input and returns a DataTable containing the extracted data.
        ///     Designed to work together with the DBHandler to import the data into the database.
        /// </summary>
        /// <param name="filePath">The file path of the Excel-file containing the relevant data.</param>
        ICollection<ImportedStudentRecord> IStudentImporter.ReadStudentsFromFile(string filePath)
        {
            if (string.IsNullOrWhiteSpace(filePath))
            {
                throw new ArgumentException("File path is null, empty or consist of only white-space characters.");
            }

            ICollection<ImportedStudentRecord> extractedStudents = new List<ImportedStudentRecord>();

            _Application excelInstance = null;
            _Workbook workbook = null;

            try
            {
                excelInstance = new Application();
                workbook = excelInstance.Workbooks.Open(filePath);
                _Worksheet worksheet = workbook.Worksheets[1];

                ValidateHeaderRow(worksheet);

                int rowIdx = 2;
                bool rowIsEmpty = false;
                while (!rowIsEmpty)
                {
                    string[] row = GetRow(worksheet, rowIdx, 5);
                    rowIsEmpty = row.All(string.IsNullOrWhiteSpace);

                    if (!rowIsEmpty)
                    {
                        extractedStudents.Add(new ImportedStudentRecord(row[0], row[1], row[2], row[3], row[4]));
                    }

                    rowIdx++;
                }
            }
            finally
            {
                workbook?.Close();
                excelInstance?.Quit();

                SafelyReleaseComObject(workbook);
                SafelyReleaseComObject(excelInstance);
            }

            return extractedStudents;
        }

        static void SafelyReleaseComObject(object obj)
        {
            if (obj != null)
            {
                Marshal.ReleaseComObject(obj);
            }
        }

        static string GetTextFromRange(_Worksheet sheet, string range)
        {
            return sheet.Range[range].Text;
        }

        static char GetColumnName(int colIdx)
        {
            if (colIdx > 25)
            {
                throw new NotImplementedException($"The {nameof(GetColumnName)}-function is only designed for column indices up to 25.");
            }

            return Prerequisites.Alphabet[colIdx];
        }

        static string[] GetRow(_Worksheet sheet, int rowIdx, int length)
        {
            string[] row = new string[length];

            for (int colIdx = 0; colIdx < length; colIdx++)
            {
                row[colIdx] = GetTextFromCell(sheet, colIdx, rowIdx);
            }

            return row;
        }

        static string GetTextFromCell(_Worksheet sheet, int colIdx, int rowIdx)
        {
            return sheet.Range[$"{GetColumnName(colIdx)}{rowIdx}"].Text;
        }

        static void ValidateHeaderRow(_Worksheet sheet)
        {
            ValidateString(SurnameHeaderColumn, GetTextFromRange(sheet, "A1"));
            ValidateString(ForenameHeaderColumn, GetTextFromRange(sheet, "B1"));
            ValidateString(CoursenameHeaderColumn, GetTextFromRange(sheet, "C1"));
            ValidateString(SexHeaderColumn, GetTextFromRange(sheet, "D1"));
            ValidateString(YearofbirthHeaderColumn, GetTextFromRange(sheet, "E1"));
        }

        static void ValidateString(string expected, string actual)
        {
            if (!actual.Equals(expected, StringComparison.InvariantCulture))
            {
                throw new ArgumentException($"Header row was in unexpected condition. Expected {expected} but was {actual}.");
            }
        }
    }
}