Imports MySql.Data.MySqlClient

Friend Class MySqlHandler
  Private ReadOnly _oConnection As MySqlConnection

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

    oSelectCommand.CommandText = "SELECT * FROM ValidYears"

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
    oSelectCommand.CommandText =
      "SELECT DISTINCT CourseName FROM StudentCourseRel WHERE year = @iYear ORDER BY CourseName ASC"
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

  Function GetValidClassNames(iYear As Integer) As Char()
    Dim oDataAdapter As New MySqlDataAdapter()
    Dim oSelectCommand As New MySqlCommand()
    Dim dtDataTable As New DataTable()
    Dim acResult As Char()
    Dim iArrayLength As Integer
    Dim cCurrentClass As Char

    oSelectCommand.Connection = _oConnection
    oSelectCommand.CommandText =
      "SELECT DISTINCT ClassName FROM StudentCourseRel INNER JOIN CourseClassRel ON StudentCourseRel.CourseName = CourseClassRel.CourseName INNER JOIN Class on courseclassrel.ClassPKey = Class.PKey WHERE StudentCourseRel.year = @iYear ORDER BY ClassName ASC"
    oSelectCommand.Parameters.AddWithValue("@iYear", iYear)

    oDataAdapter.SelectCommand = oSelectCommand

    oDataAdapter.Fill(dtDataTable)

    iArrayLength = dtDataTable.Rows.Count - 1
    acResult = New Char(iArrayLength) {}

    For iRow As Integer = 0 To iArrayLength
      cCurrentClass = CChar(dtDataTable.Rows(iRow)(0))

      If IsValidClassName(cCurrentClass) Then
        acResult(iRow) = CChar(dtDataTable.Rows(iRow)(0))
      Else
        Throw New ArgumentOutOfRangeException("Invalid ClassName" + cCurrentClass + "received from database.")
      End If

    Next

    GetValidClassNames = acResult
  End Function

  ''' <summary>
  '''   Returns a data table with information about the allowed traditional disciplines, i.e. the disciplines that can be
  '''   selected for the given parameters.
  ''' </summary>
  ''' <param name="eSex">The students' gender.</param>
  ''' <param name="eDiscipline">The disciple type to be looked up.</param>
  ''' <returns></returns>
  ''' <remarks></remarks>
  Function GetValidTraditionalDisciplinesTable(eSex As Sex, eDiscipline As Discipline) As DataTable
    Dim oDataAdapter As New MySqlDataAdapter()
    Dim oDataTable As New DataTable()
    Dim oSelectCommand As New MySqlCommand()

    oSelectCommand.CommandText = "Select * from "

    If eSex = Sex.Male Then

      Select Case eDiscipline
        Case Discipline.Sprint
          oSelectCommand.CommandText += "TraditionalMaleSprintDisciplines"
        Case Discipline.Throw
          oSelectCommand.CommandText += "TraditionalMaleThrowDisciplines"
        Case Discipline.Jump
          oSelectCommand.CommandText += "TraditionalMaleJumpDisciplines"
        Case Discipline.MiddleDistance
          oSelectCommand.CommandText += "TraditionalMaleMiddleDistanceDisciplines"
        Case Else
          Throw New ArgumentException("Invalid discipline.")
      End Select

    ElseIf eSex = Sex.Female Then

      Select Case eDiscipline
        Case Discipline.Sprint
          oSelectCommand.CommandText += "TraditionalFemaleSprintDisciplines"
        Case Discipline.Throw
          oSelectCommand.CommandText += "TraditionalFemaleThrowDisciplines"
        Case Discipline.Jump
          oSelectCommand.CommandText += "TraditionalFemaleJumpDisciplines"
        Case Discipline.MiddleDistance
          oSelectCommand.CommandText += "TraditionalFemaleMiddleDistanceDisciplines"
        Case Else
          Throw New ArgumentException("Invalid discipline.")
      End Select

    Else
      Throw New ArgumentException("Invalid sex.")
    End If

    oSelectCommand.Connection = _oConnection

    oDataAdapter.SelectCommand = oSelectCommand

    oDataAdapter.Fill(oDataTable)

    GetValidTraditionalDisciplinesTable = oDataTable
  End Function

  Function GetValidCompetitionDisciplinesTable(eDiscipline As Discipline) As DataTable
    Dim oDataAdapter As New MySqlDataAdapter()
    Dim oDataTable As New DataTable()
    Dim oSelectCommand As New MySqlCommand()

    oSelectCommand.CommandText = "Select * from "

    Select Case eDiscipline
      Case Discipline.Sprint
        oSelectCommand.CommandText += "CompetitionSprintDisciplines"
      Case Discipline.Throw
        oSelectCommand.CommandText += "CompetitionThrowDisciplines"
      Case Discipline.Jump
        oSelectCommand.CommandText += "CompetitionJumpDisciplines"
      Case Discipline.MiddleDistance
        oSelectCommand.CommandText += "CompetitionMiddleDistanceDisciplines"
      Case Else
        Throw New ArgumentException("Invalid discipline.")
    End Select

    oSelectCommand.Connection = _oConnection

    oDataAdapter.SelectCommand = oSelectCommand

    oDataAdapter.Fill(oDataTable)

    GetValidCompetitionDisciplinesTable = oDataTable
  End Function

  Function GetGameType(cClassName As Char, iYear As Integer) As GameType
    Dim oSelectCommand As MySqlCommand
    Dim oReturnParameter As MySqlParameter

    If IsValidYear(iYear) AndAlso IsValidClassName(cClassName) Then
      oSelectCommand = New MySqlCommand()
      oSelectCommand.CommandType = CommandType.StoredProcedure

      oSelectCommand.Connection = _oConnection
      oSelectCommand.CommandText = "GetGameType"
      oSelectCommand.Parameters.AddWithValue("@cClassName", cClassName)
      oSelectCommand.Parameters.AddWithValue("@yYear", iYear)

      oReturnParameter = New MySqlParameter()
      oReturnParameter.Direction = ParameterDirection.ReturnValue
      oReturnParameter.ParameterName = "@eReturnValue"
      oReturnParameter.MySqlDbType = MySqlDbType.Enum

      oSelectCommand.Parameters.Add(oReturnParameter)

      Try
        oSelectCommand.Connection.Open()
        oSelectCommand.ExecuteNonQuery()

        Select Case oReturnParameter.Value.ToString()
          Case "Competition"
            GetGameType = GameType.Competition
          Case "Traditional"
            GetGameType = GameType.Traditional
          Case ""
            GetGameType = GameType.Unknown
          Case Else
            Throw New Exception("Invalid GameType received from database.")
        End Select

      Finally
        If oSelectCommand.Connection IsNot Nothing Then
          oSelectCommand.Connection.Close()
        End If
      End Try

    Else
      'todo: distiguish between which provided argument is invalid
      Throw _
        New ArgumentException(
          "Invalid year or class name provided. Year: '" + CStr(iYear) + "'; Class Name: '" + CStr(cClassName) + "'")
    End If
  End Function

  Function GetRawDataEditAdapter(sCourseName As String, iYear As Integer) As MySqlDataAdapter
    Dim oDataAdapter As New MySqlDataAdapter()
    Dim oSelectCommand As New MySqlCommand()
    Dim oUpdateCommand As MySqlCommand

    oSelectCommand.Connection = _oConnection

    oSelectCommand.CommandText =
      "SELECT Student.PKey, Surname, Forename, Sex, Sprint, Jump, Throw, MiddleDistance FROM Student INNER JOIN StudentCourseRel ON Student.Pkey = StudentCourseRel.StudentPKey LEFT JOIN Competition On Student.PKey = Competition.StudentPKey and Competition.Year = @Year WHERE StudentCourseRel.Year = @Year AND StudentCourseRel.CourseName = @CourseName ORDER BY Surname ASC, Forename ASC"

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
    Dim oUpdateCommand As MySqlCommand

    oSelectCommand.Connection = _oConnection

    oSelectCommand.CommandText = "SELECT * FROM ClassDisciplineMeta WHERE ClassName = @cClassName AND YEAR = @yYear"

    oSelectCommand.Parameters.AddWithValue("@cClassName", cClassName)
    oSelectCommand.Parameters.AddWithValue("@yYear", iYear)

    oUpdateCommand = New MySqlCommand("EnterDisciplineMeta", _oConnection)
    oUpdateCommand.CommandType = CommandType.StoredProcedure

    oUpdateCommand.Parameters.AddWithValue("cClassName", cClassName)
    oUpdateCommand.Parameters.AddWithValue("yYear", iYear)

    oUpdateCommand.Parameters.Add("eGameType", MySqlDbType.Enum, 1, "GameType") ' todo: test this
    oUpdateCommand.Parameters.Add("cMaleSprintPKey", MySqlDbType.Guid, 36, "MaleSprintPKey")
    oUpdateCommand.Parameters.Add("cMaleJumpPKey", MySqlDbType.Guid, 36, "MaleJumpPKey")
    oUpdateCommand.Parameters.Add("cMaleThrowPKey", MySqlDbType.Guid, 36, "MaleThrowPKey")
    oUpdateCommand.Parameters.Add("cMaleMiddleDistancePKey", MySqlDbType.Guid, 36, "MaleMiddleDistancePKey")
    oUpdateCommand.Parameters.Add("cFemaleSprintPKey", MySqlDbType.Guid, 36, "FemaleSprintPKey")
    oUpdateCommand.Parameters.Add("cFemaleJumpPKey", MySqlDbType.Guid, 36, "FemaleJumpPKey")
    oUpdateCommand.Parameters.Add("cFemaleThrowPKey", MySqlDbType.Guid, 36, "FemaleThrowPKey")
    oUpdateCommand.Parameters.Add("cFemaleMiddleDistancePKey", MySqlDbType.Guid, 36, "FemaleMiddleDistancePKey")

    oDataAdapter.SelectCommand = oSelectCommand
    oDataAdapter.UpdateCommand = oUpdateCommand

    GetDisciplinesEditAdapter = oDataAdapter
  End Function

  Sub ImportStudentData(sSurname As String, sForename As String, sCourseName As String, sClassName As String,
                        eSex As Sex, iYearOfBirth As Integer, iYear As Integer)
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
