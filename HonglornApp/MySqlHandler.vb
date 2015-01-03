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
    oSelectCommand.CommandText = "SELECT DISTINCT year FROM StudentCourseRel ORDER BY year DESC"

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
    oSelectCommand.CommandText = "SELECT DISTINCT CourseName FROM StudentCourseRel WHERE year = @iYear ORDER BY CourseName ASC"
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

    oSelectCommand.CommandText = "SELECT Student.PKey, Surname, Forename, Sex, Sprint, Jump, Throw, MiddleDistance FROM Student INNER JOIN StudentCourseRel ON Student.Pkey = StudentCourseRel.StudentPKey LEFT JOIN Competition On Student.PKey = Competition.StudentPKey and Competition.Year = @Year WHERE StudentCourseRel.Year = @Year AND StudentCourseRel.CourseName = @CourseName ORDER BY Surname ASC, Forename ASC"

    oSelectCommand.Parameters.AddWithValue("@Year", iYear)
    oSelectCommand.Parameters.AddWithValue("@CourseName", sCourseName)

    oUpdateCommand = New MySqlCommand("EnterCompetitionValues", _oConnection)
    oUpdateCommand.CommandType = CommandType.StoredProcedure

    oUpdateCommand.Parameters.AddWithValue("yYear", iYear)

    oUpdateCommand.Parameters.Add("cPKey", MySqlDbType.Guid, 36, "PKey")
    'todo: figure out, what exactly the size does for float :D
    oUpdateCommand.Parameters.Add("fSprintValue", MySqlDbType.Float, 7, "Sprint")
    oUpdateCommand.Parameters.Add("fJumpValue", MySqlDbType.Float, 7, "Jump")
    oUpdateCommand.Parameters.Add("fThrowValue", MySqlDbType.Float, 7, "Throw")
    oUpdateCommand.Parameters.Add("fMiddleDistanceValue", MySqlDbType.Float, 7, "MiddleDistance")

    oDataAdapter.SelectCommand = oSelectCommand
    oDataAdapter.UpdateCommand = oUpdateCommand

    GetCompetitionEditAdapter = oDataAdapter
  End Function

  Friend Sub ImportStudentData(sSurname As String, sForename As String, sCourseName As String, sClassName As String, eSex As Sex, iYearOfBirth As Integer, iYear As Integer)
    Dim oCmd As New MySqlCommand("ImportStudent", _oConnection)
    oCmd.CommandType = CommandType.StoredProcedure

    oCmd.Parameters.AddWithValue("@sSurname", sSurname)
    oCmd.Parameters.AddWithValue("@sForename", sForename)
    oCmd.Parameters.AddWithValue("@cCourseName", sCourseName)
    oCmd.Parameters.AddWithValue("@cClassName", sClassName)
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
