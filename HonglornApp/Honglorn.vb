Imports System.Text.RegularExpressions

Public Class Honglorn
  Private Const CsDataBaseName As String = "bjs"

  Private _oMySqlHandler As MySqlHandler
  Private _oExcelImporter As ExcelImporter

  Private _daCurrentEditDataAdapter As MySql.Data.MySqlClient.MySqlDataAdapter

  Public Sub New(sServer As String, sUser As String, sPassword As String)
    _oMySqlHandler = New MySqlHandler(sServer, sUser, sPassword, CsDataBaseName)
    _oExcelImporter = ExcelImporter.Instance
  End Sub

  ''' <summary>
  ''' Returns a DataTable containing the relevant data to fill the DataGridView for editing the competition data per course in the UI. Simultaneously, the corresponding DataAdapter is preserved, so it can be used for updating the DataBase later.
  ''' </summary>
  ''' <param name="sCourseName">The name of the course to be edited.</param>
  ''' <param name="iYear">The year for which the data should be selected.</param>
  ''' <returns></returns>
  ''' <remarks></remarks>
  Public Function GetCompetitionEditDataTable(sCourseName As String, iYear As Integer) As DataTable
    Dim dtEditDataTable As New DataTable()
    _daCurrentEditDataAdapter = _oMySqlHandler.GetCompetitionEditAdapter(sCourseName, iYear)

    _daCurrentEditDataAdapter.Fill(dtEditDataTable)

    GetCompetitionEditDataTable = dtEditDataTable
  End Function

  Public Sub SaveChanges(oChanges As DataTable)
    _daCurrentEditDataAdapter.Update(oChanges)
  End Sub

  ''' <summary>
  ''' Get an Integer Array representing the years for which data is present in the database.
  ''' </summary>
  ''' <returns>An Integer Array representing the valid years.</returns>
  ''' <remarks></remarks>
  Public Function GetValidYears() As Integer()
    GetValidYears = _oMySqlHandler.GetValidYears()
  End Function

  ''' <summary>
  ''' Get a String Array representing the course names for which there is at least one student present in the given year. 
  ''' </summary>
  ''' <param name="iYear">The year for which the valid course names should be retrieved.</param>
  ''' <returns>A String Array representing the valid course names.</returns>
  ''' <remarks></remarks>
  Public Function GetValidCourseNames(iYear As Integer) As String()
    GetValidCourseNames = _oMySqlHandler.GetValidCourseNames(iYear)
  End Function

  ''' <summary>
  ''' Get a String Array representing the class names for which there is at least one student present in the given year. 
  ''' </summary>
  ''' <param name="iYear">The year for which the valid class names should be retrieved.</param>
  ''' <returns>A String Array representing the valid class names.</returns>
  ''' <remarks></remarks>
  Public Function GetValidClassNames(iYear As Integer) As String()
    GetValidClassNames = _oMySqlHandler.GetValidClassNames(iYear)
  End Function

  'todo: currently only works with a "perfect" Excel sheet
  'todo: test inserting an already existing student
  ''' <summary>
  ''' Imports an Excel sheet containing data for multiple students into the database.
  ''' </summary>
  ''' <param name="sFilePath">The full path to the Excel file to be imported.</param>
  ''' <param name="iYear">The year in which the imported data is valid (relevant for mapping the courses).</param>
  Public Sub ImportStudentCourseExcelSheet(sFilePath As String, iYear As Integer)
    Dim sCurSurname As String
    Dim sCurForename As String
    Dim sCurCourseName As String
    Dim eCurrentSex As MySqlHandler.Sex
    Dim iCurYearOfBirth As Integer

    Dim oDataTable As DataTable = _oExcelImporter.GetStudentCourseDataTable(sFilePath)

    For Each oRow As DataRow In oDataTable.Rows
      sCurSurname = CStr(oRow(0))
      sCurForename = CStr(oRow(1))
      sCurCourseName = CStr(oRow(2))

      Select Case (CStr(oRow(3)))
        Case "M"
          eCurrentSex = MySqlHandler.Sex.Male
        Case "W"
          eCurrentSex = MySqlHandler.Sex.Female
      End Select

      iCurYearOfBirth = CInt(oRow(4))

      ImportSingleStudent(sCurSurname, sCurForename, sCurCourseName, eCurrentSex, iCurYearOfBirth, iYear)
    Next
  End Sub

  Public Sub ImportSingleStudent(sSurname As String, sForename As String, sCourseName As String, eSex As MySqlHandler.Sex, iYearOfBirth As Integer, iYear As Integer)
    Dim sClassName As String

    If Regex.IsMatch(sCourseName, "0[5-9][A-Z]") Then
      sClassName = CStr(sCourseName(1))
    ElseIf Regex.IsMatch(sCourseName, "E(0[1-9]|[1-9][0-9])") Then
      sClassName = "E"
    Else
      Throw New ArgumentException("Invalid course name. Automatic mapping to class name failed.")
    End If

    _oMySqlHandler.ImportStudentData(sSurname, sForename, sCourseName, sClassName, eSex, iYearOfBirth, iYear)
  End Sub
End Class
