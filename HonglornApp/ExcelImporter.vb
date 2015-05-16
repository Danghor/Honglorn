Imports System.Runtime.InteropServices
Imports Microsoft.Office.Interop.Excel

Public Class ExcelImporter
  Private Shared _oMySingletonInstance As ExcelImporter

  Private ReadOnly EXPECTED_HEADER_COLUMN_NAMES As String() = {"Nachname", "Vorname", "Kursbezeichnung", "Geschlecht", "Geburtsjahr"}

  Public Shared ReadOnly Property Instance As ExcelImporter
    Get
      If IsNothing(_oMySingletonInstance) Then
        _oMySingletonInstance = New ExcelImporter()
      End If

      Instance = _oMySingletonInstance
    End Get
  End Property

  Private Sub New()
  End Sub

  ''' <summary>
  '''   Takes a file path as a string as input and returns a DataTable containing the extracted data. Designed to work together with the DBHandler to import the data into the database.
  ''' </summary>
  ''' <param name="sFilePath">The file path of the Excel-file containing the relevant data.</param>
  ''' <remarks></remarks>
  Friend Function GetStudentCourseDataTable(sFilePath As String) As Data.DataTable
    If String.IsNullOrWhiteSpace(sFilePath) Then
      Throw New ArgumentException("File path is null, empty or consist of only white-space characters.")
    Else
      Dim oExcel As Application = Nothing
      Dim oWorkbook As Workbook = Nothing
      Dim oWorksheet As Worksheet

      Try
        oExcel = New Application()

        oWorkbook = oExcel.Workbooks.Open(sFilePath)

        oWorksheet = CType(oWorkbook.Worksheets(1), Worksheet)

        'validate header row
        For iColIdx As Integer = 0 To 4
          'iterates from "A1" to "E1"
          If CStr(oWorksheet.Range(ALPHABET(iColIdx) + "1").Text) <> EXPECTED_HEADER_COLUMN_NAMES(iColIdx) Then
            Throw New ArgumentException("Header row of Excel-File is not in the expected condition.")
          End If
        Next

        'create DataTable and initialize column names
        Dim oDataTable As New Data.DataTable()
        For iCol As Integer = 0 To EXPECTED_HEADER_COLUMN_NAMES.Count - 1
          oDataTable.Columns.Add(EXPECTED_HEADER_COLUMN_NAMES(iCol))
        Next

        'import content
        Dim iCurrentRow As Integer = 2

        Dim oNewDataRow As DataRow
        Dim sCurrentCell As String
        Dim bRowIsEmpty As Boolean

        'todo: handle half-empty rows correctly! (Error message and removal from DataTable, so it's not imported)
        Do
          bRowIsEmpty = True
          oNewDataRow = oDataTable.NewRow()

          'read one row
          For iColIdx As Integer = 0 To EXPECTED_HEADER_COLUMN_NAMES.Count - 1
            sCurrentCell = CStr(oWorksheet.Range(ALPHABET(iColIdx) + CStr(iCurrentRow)).Text)
            oNewDataRow(iColIdx) = sCurrentCell

            If Not String.IsNullOrWhiteSpace(sCurrentCell) Then
              bRowIsEmpty = False
            End If
          Next

          'add row to DataTable, if it contains at least one entry
          If Not bRowIsEmpty Then
            oDataTable.Rows.Add(oNewDataRow)
          End If

          iCurrentRow += 1
        Loop Until bRowIsEmpty

        GetStudentCourseDataTable = oDataTable

      Finally
        If oWorkbook IsNot Nothing Then oWorkbook.Close()
        If oExcel IsNot Nothing Then oExcel.Quit()

        Marshal.ReleaseComObject(oWorkbook)
        Marshal.ReleaseComObject(oExcel)
      End Try
    End If
  End Function
End Class
