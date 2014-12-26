Imports MySql.Data.MySqlClient
Imports MySql.Data.Types

Public Class MySqlHandler
  Private _oConnection As MySqlConnection

  Public Enum Sex
    Male
    Female
  End Enum

  'todo: handle exception when connection cannot be established
  Friend Sub New(sServer As String, sUser As String, sPassword As String, sDatabase As String)
    Dim oConStringBuilder As New MySqlConnectionStringBuilder

    oConStringBuilder.Server = sServer
    oConStringBuilder.UserID = sUser
    oConStringBuilder.Password = sPassword
    oConStringBuilder.Database = sDatabase
    oConStringBuilder.CharacterSet = "utf8"

    _oConnection = New MySqlConnection(oConStringBuilder.GetConnectionString(True))
  End Sub

  Friend Function GetValidYears() As Integer()
    Dim oDataAdapter As New MySqlDataAdapter()
    Dim oSelectCommand As New MySqlCommand()
    Dim dtDataTable As New DataTable()
    Dim aiResult As Integer()
    Dim iArrayLength As Integer

    oSelectCommand.Connection = _oConnection
    'todo: create view for this
    oSelectCommand.CommandText = "SELECT DISTINCT year FROM StudentCourseRel"

    oDataAdapter.SelectCommand = oSelectCommand

    oDataAdapter.Fill(dtDataTable)

    iArrayLength = dtDataTable.Rows.Count - 1
    aiResult = New Integer(dtDataTable.Rows.Count - 1) {}

    For iRow As Integer = 0 To iArrayLength
      aiResult(iRow) = CInt(dtDataTable.Rows(iRow)(0))
    Next

    GetValidYears = aiResult
  End Function

  Friend Function GetValidCourseNames(iYear As Integer) As String()
    Dim oDataAdapter As New MySqlDataAdapter()
    Dim oSelectCommand As New MySqlCommand()
    Dim dtDataTable As New DataTable()
    Dim asResult As String()
    Dim iArrayLength As Integer

    oSelectCommand.Connection = _oConnection
    oSelectCommand.CommandText = "SELECT DISTINCT CourseName FROM course INNER JOIN StudentCourseRel ON Course.PKey = StudentCourseRel.CoursePKey WHERE year = @iYear"
    oSelectCommand.Parameters.AddWithValue("@iYear", iYear)

    oDataAdapter.SelectCommand = oSelectCommand

    oDataAdapter.Fill(dtDataTable)

    iArrayLength = dtDataTable.Rows.Count - 1
    asResult = New String(iArrayLength) {}

    For iRow As Integer = 0 To iArrayLength
      asResult(iRow) = CStr(dtDataTable.Rows(iRow)(0))
    Next

    GetValidCourseNames = asResult
  End Function

  Friend Function GetCompetitionEditAdapter(sCourseName As String, iYear As Integer) As MySqlDataAdapter
    Dim oDataAdapter As New MySqlDataAdapter()
    Dim oSelectCommand As New MySqlCommand()
    Dim oUpdateCommand As New MySqlCommand()

    oSelectCommand.Connection = _oConnection
    oUpdateCommand.Connection = _oConnection

    oSelectCommand.CommandText = "SELECT Student.PKey, Surname, Forename, Sprint, Jump, Throw, MiddleDistance FROM Student INNER JOIN StudentCourseRel ON Student.Pkey = StudentCourseRel.StudentPKey INNER JOIN Course ON StudentCourseRel.CoursePKey = Course.PKey left outer join Competition On Student.PKey = Competition.StudentPKey and Competition.Year = @Year WHERE StudentCourseRel.Year = @Year AND Course.CourseName = @CourseName"

    oSelectCommand.Parameters.AddWithValue("@Year", iYear)
    oSelectCommand.Parameters.AddWithValue("@CourseName", sCourseName)

    oUpdateCommand.CommandText = "IF EXISTS (SELECT NULL FROM Competition WHERE StudentPKey = @PKey AND Year = @Year) UPDATE Competition SET Sprint"

    'todo: update command and parameters for both commands

    oDataAdapter.SelectCommand = oSelectCommand
    oDataAdapter.UpdateCommand = oUpdateCommand

    GetCompetitionEditAdapter = oDataAdapter
  End Function

  Friend Sub ImportStudentData(sSurname As String, sForename As String, sCourseName As String, eSex As Sex, iYearOfBirth As Integer, iYear As Integer)
    Dim oCmd As New MySqlCommand("ImportStudent", _oConnection)
    oCmd.CommandType = CommandType.StoredProcedure

    'Dim oDateTime As New MySqlDateTime

    oCmd.Parameters.AddWithValue("@sSurname", sSurname)
    oCmd.Parameters.AddWithValue("@sForename", sForename)
    oCmd.Parameters.AddWithValue("@cCourseName", sCourseName)
    oCmd.Parameters.AddWithValue("@eSex", eSex.ToString())
    oCmd.Parameters.AddWithValue("@yYearOfBirth", iYearOfBirth)
    oCmd.Parameters.AddWithValue("@yYear", iYear)

    Try
      oCmd.Connection.Open()
      oCmd.ExecuteNonQuery()
    Finally
      If oCmd.Connection IsNot Nothing Then oCmd.Connection.Close()
    End Try
  End Sub
End Class
