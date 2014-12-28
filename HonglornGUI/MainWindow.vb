Imports HonglornApp

Public Class MainWindow
  Private Const SCALE_FACTOR As Single = 0.8

  Private ReadOnly Property CurrentYear As Integer
    Get
      Dim sSelectedYearShown As String

      sSelectedYearShown = SelectEditYearComboBox.Text

      If String.IsNullOrWhiteSpace(sSelectedYearShown) Then
        CurrentYear = -1
      Else
        CurrentYear = CInt(sSelectedYearShown)
      End If
    End Get
  End Property

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

    Me.Height = CInt(Math.Round(Screen.PrimaryScreen.Bounds.Height * SCALE_FACTOR))
    Me.Width = CInt(Math.Round(Screen.PrimaryScreen.Bounds.Width * SCALE_FACTOR))

    'pre-select a year
    Dim aiValidYears As Integer() = App.GetValidYears()
    If aiValidYears.Count <> 0 Then
      SelectEditYearComboBox.DataSource = aiValidYears
      SelectEditYearComboBox.SelectedIndex = 0
    End If

    'todo:finish
    ''pre-select a Course
    'Dim asValidCourseNames As String() = App.GetValidCourseNames()
    'If aiValidYears.Count <> 0 Then
    '  SelectEditYearComboBox.DataSource = aiValidYears
    '  SelectEditYearComboBox.SelectedIndex = 0
    'End If
  End Sub

  Private Sub SelectEditYearComboBox_DropDown(sender As Object, e As EventArgs) Handles SelectEditYearComboBox.DropDown
    SelectEditYearComboBox.DataSource = App.GetValidYears()
  End Sub

  Private Sub SelectEditCourseComboBox_DropDown(sender As Object, e As EventArgs) Handles SelectEditCourseComboBox.DropDown
    'If Not String.IsNullOrWhiteSpace(SelectEditCourseComboBox.SelectedText) Then
    If CurrentYear <> -1 Then
      SelectEditCourseComboBox.DataSource = App.GetValidCourseNames(CurrentYear)
    Else
      'todo: display tooltip "please set a year" or so
    End If
  End Sub

  Private Sub ReloadDataGridView(sCourseName As String, iYear As Integer)
    'todo: confirmation dialog, saving changes from old datasource etc
    'todo: change tab order so tab at the end of the line skips to next "value" field instead of "Surname"
    If EditDataGridView.DataSource IsNot Nothing Then
      App.SaveChanges(CType(EditDataGridView.DataSource, DataTable))
    End If

    EditDataGridView.Visible = False

    EditDataGridView.DataSource = App.GetCompetitionEditDataTable(sCourseName, iYear)

    EditDataGridView.Columns("PKey").Visible = False
    EditDataGridView.Columns("Surname").ReadOnly = True
    EditDataGridView.Columns("Forename").ReadOnly = True
    EditDataGridView.Columns("Sex").ReadOnly = True

    EditDataGridView.Visible = True
  End Sub

  Private Sub SelectEditCourseComboBox_SelectedIndexChanged(sender As Object, e As EventArgs) Handles SelectEditCourseComboBox.SelectedIndexChanged
    Dim sSelectedCourseName As String = SelectEditCourseComboBox.Text

    If CurrentYear <> -1 AndAlso Not String.IsNullOrWhiteSpace(sSelectedCourseName) Then
      ReloadDataGridView(sSelectedCourseName, CurrentYear)
    End If
  End Sub

  Private Sub EditDataGridView_CellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles EditDataGridView.CellEndEdit
    'todo: verify content

    App.SaveChanges(CType(EditDataGridView.DataSource, DataTable))
  End Sub
End Class