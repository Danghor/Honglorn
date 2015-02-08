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
      Dim asNewClassNames As String() = App.GetValidClassNames(CurrentYear)
      Dim asOldClassNames As String() = CType(ClassComboBox.DataSource, String())

      If Not Tools.IsEqual(asNewClassNames, asOldClassNames) Then
        ClassComboBox.DataSource = asNewClassNames
      End If
    Else
      'todo: display tooltip "please set a year" or so
    End If
  End Sub

  Private Sub ClassComboBox_TextChanged(sender As Object, e As EventArgs) Handles ClassComboBox.TextChanged
    If Not String.IsNullOrWhiteSpace(ClassComboBox.Text) Then
      DisciplineSetTypeGroupBox.Enabled = True
    End If

  End Sub
End Class