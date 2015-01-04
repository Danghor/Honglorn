Imports HonglornApp

Public Class SetDisciplinesDialog

  Private _oApp As Honglorn

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
    Dim oOwner As MainWindow = CType(Me.Owner, MainWindow)
    _oApp = oOwner._oApp

    Tools.Center(Me)

    'pre-select a year
    Dim aiValidYears As Integer() = _oApp.GetValidYears()
    If aiValidYears.Count <> 0 Then
      YearComboBox.DataSource = aiValidYears
      YearComboBox.SelectedIndex = 0
    End If
  End Sub

  Private Sub YearComboBox_DropDown(sender As Object, e As EventArgs) Handles YearComboBox.DropDown
    YearComboBox.DataSource = _oApp.GetValidYears()
  End Sub

  Private Sub ClassComboBox_DropDown(sender As Object, e As EventArgs) Handles ClassComboBox.DropDown
    If CurrentYear <> -1 Then
      Dim asNewCourseNames As String() = _oApp.GetValidCourseNames(CurrentYear)
      Dim asOldCourseNames As String() = CType(ClassComboBox.DataSource, String())

      If Not Tools.IsEqual(asNewCourseNames, asOldCourseNames) Then
        ClassComboBox.DataSource = _oApp.GetValidCourseNames(CurrentYear)
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