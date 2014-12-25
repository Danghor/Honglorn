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

  Friend Function GetCompetitionEditAdapter(sCourseName As String, iYear As Integer) As MySqlDataAdapter
    Dim oDataAdapter As New MySqlDataAdapter()
    Dim oSelectCommand As New MySqlCommand()
    Dim oUpdateCommand As New MySqlCommand()

    oSelectCommand.Connection = _oConnection
    oUpdateCommand.Connection = _oConnection

    oSelectCommand.CommandText = "SELECT PKey, Surname, Forename, Sprint, Jump, Throw, MiddleDistance FROM (Student LEFT JOIN Competition ON Student.PKey = Competition.StudentPKey) INNER JOIN StudentCourseRel ON Student.Pkey = StudentCourseRel.StudentPKey INNER JOIN Course ON StudentCourseRel.CoursePKey = Course.PKey WHERE StudentCourseRel.Year = @Year AND Competition.Year = @Year AND Course.CourseName = @CourseName"

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
