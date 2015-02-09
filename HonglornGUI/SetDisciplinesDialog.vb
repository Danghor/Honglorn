Imports HonglornApp

Public Class SetDisciplinesDialog

  Private ReadOnly Property App As Honglorn
    Get
      App = CType(Me.Owner, MainWindow)._oApp
    End Get
  End Property

  Private ReadOnly Property CurrentYear As Integer
    Get
      Dim sSelectedYearShown As String

      sSelectedYearShown = YearComboBox.Text

      If String.IsNullOrWhiteSpace(sSelectedYearShown) Then
        CurrentYear = -1
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

  Private Sub SetDisciplinesDialog_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    Tools.Center(Me)

    'pre-select a year
    Dim aiValidYears As Integer() = App.GetValidYears()
    If aiValidYears.Count <> 0 Then
      YearComboBox.DataSource = aiValidYears
      YearComboBox.SelectedIndex = 0
    End If
  End Sub

  Private Sub YearComboBox_DropDown(sender As Object, e As EventArgs) Handles YearComboBox.DropDown
    YearComboBox.DataSource = App.GetValidYears()
  End Sub

  Private Sub ClassComboBox_DropDown(sender As Object, e As EventArgs) Handles ClassComboBox.DropDown
    If CurrentYear <> -1 Then
      Dim acNewClassNames As Char() = App.GetValidClassNames(CurrentYear)
      Dim acOldClassNames As Char() = CType(ClassComboBox.DataSource, Char())

      If Not Tools.IsEqual(acNewClassNames, acOldClassNames) Then
        ClassComboBox.DataSource = acNewClassNames
      End If
    Else
      'todo: display tooltip "please set a year" or so
    End If
  End Sub

  Private Sub ClassComboBox_TextChanged(sender As Object, e As EventArgs) Handles ClassComboBox.TextChanged

    If Not String.IsNullOrWhiteSpace(ClassComboBox.Text) Then

      'App.GetGameType()
      'TraditionalDisciplineSetRadioButton.Checked = True
      'CompetitionDisciplineSetRadioButton.Checked = True
      'DisciplineSetTypeGroupBox.Enabled = True

    End If

  End Sub
End Class