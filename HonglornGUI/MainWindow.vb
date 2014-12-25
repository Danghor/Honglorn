Imports HonglornApp

Public Class MainWindow

  Private Sub SETCREDENTIALS()
    Dim oFile As New System.IO.StreamReader("C:\Git\Honglorn\CREDEN~1.TXT")
    Dim sServer As String = oFile.ReadLine()
    Dim sUser As String = oFile.ReadLine()
    Dim sPassword As String = oFile.ReadLine()
    Dim sDatabase As String = oFile.ReadLine()
    App = Honglorn.Instance(sServer, sUser, sPassword)
  End Sub

  Private App As Honglorn

  Private Sub MainWindow_Load(sender As Object, e As EventArgs) Handles MyBase.Load
    SETCREDENTIALS()
  End Sub
End Class