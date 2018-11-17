using System.Collections.Generic;
using System.Linq;
using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Spreadsheet;

namespace HonglornBL.Import
{
    class ExcelImporter : StudentImporter
    {
        /// <summary>
        ///     Reads student data from an Excel file and returns a collection containing the students.
        /// </summary>
        /// <param name="filePath">The file path of the Excel file containing the relevant data.</param>
        public override ICollection<ImportedStudentRecord> ReadStudentsFromFile(string filePath)
        {
            var extractedStudents = new List<ImportedStudentRecord>();

            using (SpreadsheetDocument document = SpreadsheetDocument.Open(filePath, false))
            {
                WorkbookPart workbookPart = document.WorkbookPart;
                StringValue sheetId = workbookPart.Workbook.Descendants<Sheet>().First().Id;
                SharedStringTablePart stringTable = workbookPart.GetPartsOfType<SharedStringTablePart>().First();
                var worksheetPart = (WorksheetPart) workbookPart.GetPartById(sheetId);
                IEnumerable<Cell> cells = worksheetPart.Worksheet.Descendants<Cell>();

                string[] valueList = cells.Select(cell => cell.DataType?.Value == CellValues.SharedString ? stringTable.SharedStringTable.ElementAt(int.Parse(cell.InnerText)).InnerText : cell.InnerText).ToArray();

                for (var offset = 5; offset <= valueList.Length - 5; offset += 5)
                {
                    extractedStudents.Add(new ImportedStudentRecord(valueList[offset], valueList[offset + 1], valueList[offset + 2], valueList[offset + 3], valueList[offset + 4]));
                }
            }

            return extractedStudents;
        }
    }
}