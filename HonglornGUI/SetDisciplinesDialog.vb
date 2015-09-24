Imports HonglornBL
Imports HonglornBL.Prerequisites

Public Class SetDisciplinesDialog

#Region "Properties"

  Private ReadOnly Property App As Honglorn
    Get
      App = CType(Owner, MainWindow)._oApp
    End Get
  End Property

  Private ReadOnly Property CurrentYear As Integer
    Get
      Dim sSelectedYearShown As String

      sSelectedYearShown = YearComboBox.Text

      If String.IsNullOrWhiteSpace(sSelectedYearShown) Then
        CurrentYear = - 1
      Else
        CurrentYear = CInt(sSelectedYearShown)
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
    Dim aiValidYears As Integer() = App.GetYearsWithStudentData()
    If aiValidYears.Count <> 0 Then
      YearComboBox.DataSource = aiValidYears
      YearComboBox.SelectedIndex = 0
    End If
  End Sub

  Private Sub YearComboBox_DropDown(sender As Object, e As EventArgs) Handles YearComboBox.DropDown
    YearComboBox.DataSource = App.GetYearsWithStudentData()
  End Sub

  Private Sub ClassComboBox_DropDown(sender As Object, e As EventArgs) Handles ClassComboBox.DropDown
    If CurrentYear <> - 1 Then
      Dim acNewClassNames As Char() = App.GetValidClassNames(CurrentYear)
      Dim acOldClassNames As Char() = CType(ClassComboBox.DataSource, Char())

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
    If IsValidYear(CurrentYear) AndAlso IsValidClassName(CurrentClass) Then
      RefreshGameTypeFromDatabase()

      GameTypeGroupBox.Enabled = True
    Else
      GameTypeGroupBox.Enabled = False
      TraditionalGameTypeRadioButton.Checked = False
      CompetitionGameTypeRadioButton.Checked = False
    End If
  End Sub

  Private Sub RefreshGameTypeFromDatabase()
    Dim eGameType As GameType

    eGameType = App.GetGameType(CurrentClass, CurrentYear)

    Select Case eGameType

      Case GameType.Competition
        CompetitionGameTypeRadioButton.Checked = True

      Case GameType.Traditional
        TraditionalGameTypeRadioButton.Checked = True

      Case GameType.Unknown
        TraditionalGameTypeRadioButton.Checked = False
        CompetitionGameTypeRadioButton.Checked = False

    End Select
  End Sub

  Private Sub RefreshDisciplinesFromDatabase()
  End Sub
End Class