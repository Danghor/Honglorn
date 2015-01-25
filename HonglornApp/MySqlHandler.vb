Imports MySql.Data.MySqlClient
Imports MySql.Data.Types
Imports HonglornApp.Honglorn

Friend Class MySqlHandler
  Private _oConnection As MySqlConnection

  'todo: handle exception when connection cannot be established
  Sub New(sServer As String, sUser As String, sPassword As String, sDatabase As String)
    Dim oConStringBuilder As New MySqlConnectionStringBuilder

    oConStringBuilder.Server = sServer
    oConStringBuilder.UserID = sUser
    oConStringBuilder.Password = sPassword
    oConStringBuilder.Database = sDatabase
    oConStringBuilder.CharacterSet = "utf8"

    _oConnection = New MySqlConnection(oConStringBuilder.GetConnectionString(True))
  End Sub

  Function GetValidYears() As Integer()
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

  Function GetValidCourseNames(iYear As Integer) As String()
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

  Function GetValidClassNames(iYear As Integer) As String()
    Dim oDataAdapter As New MySqlDataAdapter()
    Dim oSelectCommand As New MySqlCommand()
    Dim dtDataTable As New DataTable()
    Dim asResult As String()
    Dim iArrayLength As Integer

    oSelectCommand.Connection = _oConnection
    oSelectCommand.CommandText = "SELECT DISTINCT ClassName FROM StudentCourseRel INNER JOIN CourseClassRel ON StudentCourseRel.CourseName = CourseClassRel.CourseName INNER JOIN Class on courseclassrel.ClassPKey = Class.PKey WHERE StudentCourseRel.year = @iYear ORDER BY ClassName ASC"
    oSelectCommand.Parameters.AddWithValue("@iYear", iYear)

    oDataAdapter.SelectCommand = oSelectCommand

    oDataAdapter.Fill(dtDataTable)

    iArrayLength = dtDataTable.Rows.Count - 1
    asResult = New String(iArrayLength) {}

    For iRow As Integer = 0 To iArrayLength
      asResult(iRow) = CStr(dtDataTable.Rows(iRow)(0))
    Next

    GetValidClassNames = asResult
  End Function

  Function GetValidDisciplinesTable(eGameType As GameType, eSex As Sex, eDiscipline As Discipline) As DataTable
    Dim oDataAdapter As New MySqlDataAdapter()
    Dim oDataTable As New DataTable()
    Dim oSelectCommand As New MySqlCommand()

    If eGameType = GameType.Traditional Then
      If eSex = Sex.Male Then
        Select Case eDiscipline
          Case Discipline.Sprint
            oSelectCommand.CommandText = "TraditionalMaleSprintDisciplines"
          Case Discipline.Throwing
            oSelectCommand.CommandText = "TraditionalMaleThrowDisciplines"
          Case Discipline.Jump
            oSelectCommand.CommandText = "TraditionalMaleJumpDisciplines"
          Case Discipline.MiddleDistance
            oSelectCommand.CommandText = "TraditionalMaleMiddleDistanceDisciplines"
          Case Else
            Throw New ArgumentException("Invalid discipline.")
        End Select
      ElseIf eSex = Sex.Female Then
        Select Case eDiscipline
          Case Discipline.Sprint
            oSelectCommand.CommandText = "TraditionalFemaleSprintDisciplines"
          Case Discipline.Throwing
            oSelectCommand.CommandText = "TraditionalFemaleThrowDisciplines"
          Case Discipline.Jump
            oSelectCommand.CommandText = "TraditionalFemaleJumpDisciplines"
          Case Discipline.MiddleDistance
            oSelectCommand.CommandText = "TraditionalFemaleMiddleDistanceDisciplines"
          Case Else
            Throw New ArgumentException("Invalid discipline.")
        End Select
      Else
        Throw New ArgumentException("Invalid sex.")
      End If
    ElseIf eGameType = GameType.Competition Then
      Throw New NotImplementedException()
    Else
      Throw New ArgumentException("Invalid GameType.")
    End If

    oSelectCommand.Connection = _oConnection
    oSelectCommand.CommandType = CommandType.StoredProcedure

    oDataAdapter.SelectCommand = oSelectCommand

    oDataAdapter.Fill(oDataTable)

    GetValidDisciplinesTable = oDataTable
  End Function

  Private Function GetGameType(cClassName As Char, iYear As Integer) As GameType
    'Throw New NotImplementedException
    Dim oSelectCommand As New MySqlCommand()

    oSelectCommand.Connection = _oConnection
    oSelectCommand.CommandText = "GetGameType"
    oSelectCommand.Parameters.AddWithValue("@cClassName", cClassName)
    oSelectCommand.Parameters.AddWithValue("@yYear", iYear)

    oSelectCommand.Parameters.Add("@eReturnValue", MySqlDbType.Enum)
    oSelectCommand.Parameters("@eReturnValue").Direction = ParameterDirection.ReturnValue

    oSelectCommand.CommandType = CommandType.StoredProcedure

    Try
      oSelectCommand.Connection.Open()
      Dim o As Object = oSelectCommand.ExecuteScalar()
    Finally
      If oSelectCommand.Connection IsNot Nothing Then
        oSelectCommand.Connection.Close()
      End If
    End Try

    Select Case oSelectCommand.ExecuteScalar().ToString()
      Case "Competition"
        GetGameType = GameType.Competition
      Case "Traditional"
        GetGameType = GameType.Traditional
      Case ""
        GetGameType = Nothing
      Case Else
        Throw New Exception("Invalid GameType received from database.")
    End Select

  End Function

  Function GetRawDataEditAdapter(sCourseName As String, iYear As Integer) As MySqlDataAdapter
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

    GetRawDataEditAdapter = oDataAdapter
  End Function

  Function GetDisciplinesEditAdapter(cClassName As Char, iYear As Integer) As MySqlDataAdapter
    Dim oDataAdapter As New MySqlDataAdapter()
    Dim oSelectCommand As New MySqlCommand()
    Dim oUpdateCommand As New MySqlCommand()

    oSelectCommand.Connection = _oConnection

    oSelectCommand.CommandText = "SELECT * FROM ClassDisciplineMeta WHERE ClassName = @cClassName AND YEAR = @yYear"

    oSelectCommand.Parameters.AddWithValue("@cClassName", cClassName)
    oSelectCommand.Parameters.AddWithValue("@yYear", iYear)

    'todo: update command
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

    GetDisciplinesEditAdapter = oDataAdapter
  End Function

  Sub ImportStudentData(sSurname As String, sForename As String, sCourseName As String, sClassName As String, eSex As Sex, iYearOfBirth As Integer, iYear As Integer)
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
