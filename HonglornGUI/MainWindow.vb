Imports System.IO
Imports HonglornBL

Public Class MainWindow
  Private Const SCALE_FACTOR As Single = 0.8
  Friend _oApp As Honglorn
  Private _oSetDisciplinesDialog As SetDisciplinesDialog

#Region "Properties"

  Private ReadOnly Property CurrentYear As Integer
    Get
      Dim sSelectedYearShown As String

      sSelectedYearShown = SelectEditYearComboBox.Text

      If String.IsNullOrWhiteSpace(sSelectedYearShown) Then
        CurrentYear = - 1
      Else
        CurrentYear = CInt(sSelectedYearShown)
      End If
    End Get
  End Property

  Private ReadOnly Property SetDisciplinesDialog As SetDisciplinesDialog
    Get

      If _oSetDisciplinesDialog Is Nothing Then
        _oSetDisciplinesDialog = New SetDisciplinesDialog()
      End If

      SetDisciplinesDialog = _oSetDisciplinesDialog
    End Get
  End Property

#End Region

  'todo: replace this by login form
  Private Sub SETCREDENTIALS()
    Dim oFile As New StreamReader("C:\Git\Honglorn\CREDEN~1.TXT")
    Dim sServer As String = oFile.ReadLine()
    Dim iPort As UInteger = CUInt(oFile.ReadLine())
    Dim sUsername As String = oFile.ReadLine()
    Dim sPassword As String = oFile.ReadLine()
    Dim sDatabase As String = oFile.ReadLine()

    _oApp = New Honglorn(sServer, iPort, sUsername, sPassword, sDatabase)
  End Sub

  Private Sub MainWindow_Load(sender As Object, e As EventArgs) Handles MyBase.Load
    SETCREDENTIALS()

    ScaleScreenAware(Me, SCALE_FACTOR)

    Center(Me)

    'pre-select a year
    Dim aiValidYears As ICollection(Of UShort) = Honglorn.GetYearsWithStudentData()
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
    SelectEditYearComboBox.DataSource = Honglorn.GetYearsWithStudentData()
  End Sub

  Private Sub SelectEditCourseComboBox_DropDown(sender As Object, e As EventArgs) _
    Handles SelectEditCourseComboBox.DropDown
    If CurrentYear <> - 1 Then
      Dim asNewCourseNames As ICollection(Of String) = _oApp.GetValidCourseNames(CurrentYear)
      Dim asOldCourseNames As New List(Of String)

      For Each item As Object In SelectEditCourseComboBox.Items
        asOldCourseNames.Add(item.ToString())
      Next

      If Not IsEqual(asNewCourseNames, asOldCourseNames) Then
        SelectEditCourseComboBox.DataSource = asNewCourseNames
      End If
    Else
      'todo: display tooltip "please set a year" or so
    End If
  End Sub

  Private Sub ReloadDataGridView(sCourseName As String, iYear As Integer)
    'todo: confirmation dialog, saving changes from old datasource etc
    'todo: change tab order so pressing tab-key at the end of the line skips to next "value" field instead of "Surname"
    If EditDataGridView.DataSource IsNot Nothing Then
      _oApp.SaveRawDataEditTableChanges(CType(EditDataGridView.DataSource, DataTable))
    End If

    EditDataGridView.Visible = False

    EditDataGridView.DataSource = _oApp.GetCompetitionEditDataTable(sCourseName, iYear)

    EditDataGridView.Columns("PKey").Visible = False
    EditDataGridView.Columns("Surname").ReadOnly = True
    EditDataGridView.Columns("Forename").ReadOnly = True
    EditDataGridView.Columns("Sex").ReadOnly = True

    EditDataGridView.Visible = True
  End Sub

  Private Sub SelectEditCourseComboBox_TextChanged(sender As Object, e As EventArgs) _
    Handles SelectEditCourseComboBox.TextChanged
    Dim sSelectedCourseName As String = SelectEditCourseComboBox.Text

    If CurrentYear <> - 1 AndAlso Not String.IsNullOrWhiteSpace(sSelectedCourseName) Then
      ReloadDataGridView(sSelectedCourseName, CurrentYear)
    End If
  End Sub

  Private Sub EditDataGridView_CellEndEdit(sender As Object, e As DataGridViewCellEventArgs) _
    Handles EditDataGridView.CellEndEdit
    'todo: verify content

    _oApp.SaveRawDataEditTableChanges(CType(EditDataGridView.DataSource, DataTable))
  End Sub

  Private Sub SetDisciplinesToolStripMenuItem_Click(sender As Object, e As EventArgs) _
    Handles SetDisciplinesToolStripMenuItem.Click
    SetDisciplinesDialog.ShowDialog(Me)
  End Sub

  Private Sub ImportStudentsMenuItem_Click(sender As Object, e As EventArgs) Handles ImportStudentsMenuItem.Click
    'Dim oOpenFileDialog As New OpenFileDialog()

    'If oOpenFileDialog.ShowDialog() = Windows.Forms.DialogResult.OK Then
    '  _oApp.ImportStudentCourseExcelSheet()
    'End If
  End Sub
End Class