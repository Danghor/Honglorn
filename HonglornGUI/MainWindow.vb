Imports HonglornApp

Public Class MainWindow

  'todo: replace this by login form
  Private Sub SETCREDENTIALS()
    Dim oFile As New System.IO.StreamReader("C:\Git\Honglorn\CREDEN~1.TXT")
    Dim sServer As String = oFile.ReadLine()
    Dim sUser As String = oFile.ReadLine()
    Dim sPassword As String = oFile.ReadLine()
    Dim sDatabase As String = oFile.ReadLine()
    App = New Honglorn(sServer, sUser, sPassword)
  End Sub

  Private App As Honglorn

  Private Sub MainWindow_Load(sender As Object, e As EventArgs) Handles MyBase.Load
    SETCREDENTIALS()
  End Sub

  Private Sub SelectEditYearComboBox_DropDown(sender As Object, e As EventArgs) Handles SelectEditYearComboBox.DropDown
    SelectEditYearComboBox.DataSource = App.GetValidYears()
  End Sub

  Private Sub SelectEditCourseComboBox_DropDown(sender As Object, e As EventArgs) Handles SelectEditCourseComboBox.DropDown
    Dim sSelectedYearShown As String
    Dim iSelectedYear As Integer

    sSelectedYearShown = SelectEditYearComboBox.Text

    If String.IsNullOrWhiteSpace(sSelectedYearShown) Then
      iSelectedYear = 0
    Else
      iSelectedYear = CInt(sSelectedYearShown)
    End If

    SelectEditCourseComboBox.DataSource = App.GetValidCourseNames(iSelectedYear)
  End Sub

  Private Sub ReloadDataGridView(sCourseName As String, iYear As Integer)
    'todo: confirmation dialog, saving changes from old datasource etc
    EditDataGridView.Visible = False
    EditDataGridView.DataSource = App.GetCompetitionEditDataTable(sCourseName, iYear)
    EditDataGridView.Columns("PKey").Visible = False
    EditDataGridView.Columns("Surname").ReadOnly = True
    EditDataGridView.Columns("Forename").ReadOnly = True
    EditDataGridView.Visible = True
  End Sub

  Private Sub SelectEditCourseComboBox_SelectedIndexChanged(sender As Object, e As EventArgs) Handles SelectEditCourseComboBox.SelectedIndexChanged
    Dim sSelectedCourseName As String = SelectEditCourseComboBox.Text
    Dim sSelectedYear As Integer = CInt(SelectEditYearComboBox.Text)

    If Not String.IsNullOrWhiteSpace(sSelectedCourseName) And sSelectedYear <> 0 Then
      ReloadDataGridView(sSelectedCourseName, sSelectedYear)
    End If
  End Sub
End Class