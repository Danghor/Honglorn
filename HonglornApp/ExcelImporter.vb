Imports System.Runtime.InteropServices.Marshal
Imports Microsoft.Office.Interop

Public Class ExcelImporter
  Private Shared _MySingletonInstance As ExcelImporter

  Private Const CsAlphabet As String = "ABCDEFGHIJKLMNOPQRSTUVWXYZ"

  Private ReadOnly CsaExpectedHeaderColumnNames As String() = {"Nachname", "Vorname", "Kursbezeichnung", "Geschlecht", "Geburtsjahr"}

  Public Shared ReadOnly Property Instance As ExcelImporter
    Get
      If IsNothing(_MySingletonInstance) Then
        _MySingletonInstance = New ExcelImporter()
      End If

      Instance = _MySingletonInstance
    End Get
  End Property

  Private Sub New()
  End Sub

  ''' <summary>
  ''' Takes a file path as a string as input and returns a DataTable containing the extracted data. Designed to work together with the DBHandler to import the data into the database.
  ''' </summary>
  ''' <param name="sFilePath">The file path of the Excel-file containing the relevant data.</param>
  ''' <remarks></remarks>
  Friend Function GetStudentCourseDataTable(sFilePath As String) As DataTable
    If String.IsNullOrWhiteSpace(sFilePath) Then
      Throw New ArgumentException("File path is null, empty or consist of only white-space characters.")
    Else
      Dim oExcel As Excel.Application = Nothing
      Dim oWorkbook As Excel.Workbook = Nothing
      Dim oWorksheet As Excel.Worksheet

      Try
        oExcel = New Excel.Application()

        oWorkbook = oExcel.Workbooks.Open(sFilePath)

        oWorksheet = CType(oWorkbook.Worksheets(1), Excel.Worksheet)

        'validate header row
        For iColIdx As Integer = 0 To 4
          'iterates from "A1" to "E1"
          If CStr(oWorksheet.Range(CsAlphabet(iColIdx) + "1").Text) <> CsaExpectedHeaderColumnNames(iColIdx) Then
            Throw New ArgumentException("Header row of Excel-File is not in the expected condition.")
          End If
        Next

        'create DataTable and initialize column names
        Dim oDataTable As New DataTable()
        For iCol As Integer = 0 To CsaExpectedHeaderColumnNames.Count - 1
          oDataTable.Columns.Add(CsaExpectedHeaderColumnNames(iCol))
        Next

        'import content
        Dim iCurrentRow As Integer = 2
        Dim iCurrentColIdx As Integer = 0

        Dim oNewDataRow As DataRow
        Dim sCurrentCell As String
        Dim bRowIsEmpty As Boolean

        'todo: handle half-empty rows correctly! (Error message and removal from DataTable, so it's not imported)
        Do
          bRowIsEmpty = True
          oNewDataRow = oDataTable.NewRow()

          'read one row
          For iColIdx As Integer = 0 To 4
            sCurrentCell = CStr(oWorksheet.Range(CsAlphabet(iColIdx) + CStr(iCurrentRow)).Text)
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

        ReleaseComObject(oWorkbook)
        ReleaseComObject(oExcel)
      End Try
    End If
  End Function
End Class
