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
End Class