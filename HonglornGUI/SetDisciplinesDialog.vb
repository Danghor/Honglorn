Imports HonglornBL

Public Class SetDisciplinesDialog

#Region "Properties"

  Private ReadOnly Property App As Honglorn
    Get
      App = CType(Owner, MainWindow)._oApp
    End Get
  End Property

  Private ReadOnly Property CurrentYear As UShort
    Get
      Dim sSelectedYearShown As String

      sSelectedYearShown = YearComboBox.Text

      If String.IsNullOrWhiteSpace(sSelectedYearShown) Then
        CurrentYear = 0
      Else
        CurrentYear = Convert.ToUInt16(sSelectedYearShown)
      End If
    End Get
  End Property

  Private ReadOnly Property CurrentClass As Char
    Get
      If String.IsNullOrWhiteSpace(ClassComboBox.Text) Then
        CurrentClass = Nothing
      Else
        CurrentClass = CChar(ClassComboBox.Text)
      End If
    End Get
  End Property

#End Region

  Private Sub SetDisciplinesDialog_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    Center(Me)

    'pre-select a year
    Dim aiValidYears As ICollection(Of UShort) = Honglorn.GetYearsWithStudentData()
    If aiValidYears.Count <> 0 Then
      YearComboBox.DataSource = aiValidYears
      YearComboBox.SelectedIndex = 0
    End If
  End Sub

  Private Sub YearComboBox_DropDown(sender As Object, e As EventArgs) Handles YearComboBox.DropDown
    YearComboBox.DataSource = Honglorn.GetYearsWithStudentData()
  End Sub

  Private Sub ClassComboBox_DropDown(sender As Object, e As EventArgs) Handles ClassComboBox.DropDown
    If CurrentYear <> 0 Then
      Dim acNewClassNames As ICollection(Of Char) = App.GetValidClassNames(CurrentYear)
      Dim acOldClassNames As ICollection(Of Char) = CType(ClassComboBox.DataSource, Char())

      If Not IsEqual(acNewClassNames, acOldClassNames) Then
        ClassComboBox.DataSource = acNewClassNames
      End If
    Else
      'todo: display tooltip "please set a year" or so
    End If
  End Sub

  Private Sub ClassComboBox_TextChanged(sender As Object, e As EventArgs) Handles ClassComboBox.TextChanged
    ValidateInputAndRefresh()
  End Sub

  Private Sub YearComboBox_TextChanged(sender As Object, e As EventArgs) Handles YearComboBox.TextChanged
    ValidateInputAndRefresh()
  End Sub

  Private Sub ValidateInputAndRefresh()
    If Prerequisites.IsValidYear(CurrentYear) AndAlso Prerequisites.IsValidClassName(CurrentClass) Then
      RefreshGameTypeFromDatabase()

      GameTypeGroupBox.Enabled = True
    Else
      GameTypeGroupBox.Enabled = False
      TraditionalGameTypeRadioButton.Checked = False
      CompetitionGameTypeRadioButton.Checked = False
    End If
  End Sub

  Private Sub RefreshGameTypeFromDatabase()
    Dim eGameType As Prerequisites.GameType

    eGameType = App.GetGameType(CurrentClass, CurrentYear)

    Select Case eGameType

      Case Prerequisites.GameType.Competition
        CompetitionGameTypeRadioButton.Checked = True

      Case Prerequisites.GameType.Traditional
        TraditionalGameTypeRadioButton.Checked = True

    End Select
  End Sub

  Private Sub RefreshDisciplinesFromDatabase()
  End Sub
End Class