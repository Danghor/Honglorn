Friend Class Tools

  ''' <summary>
  ''' Positions the given control in the center of the screen.
  ''' </summary>
  ''' <param name="oControl">The control to be centered.</param>
  ''' <remarks></remarks>
  Public Shared Sub Center(oControl As Control)
    oControl.Location = New Point(CInt(Math.Round((Screen.PrimaryScreen.Bounds.Width - oControl.Width) / 2)), CInt(Math.Round((Screen.PrimaryScreen.Bounds.Height - oControl.Height) / 2)))
  End Sub

  ''' <summary>
  ''' Scales the given control dependent on the screen-measurements.
  ''' </summary>
  ''' <param name="oControl">The control to be scaled.</param>
  ''' <param name="siScaleFactor">The scale factor to be used. 1 will make the control just as big as the screen.</param>
  ''' <remarks></remarks>
  Public Shared Sub ScaleScreenAware(oControl As Control, siScaleFactor As Single)
    oControl.Height = CInt(Math.Round(Screen.PrimaryScreen.Bounds.Height * siScaleFactor))
    oControl.Width = CInt(Math.Round(Screen.PrimaryScreen.Bounds.Width * siScaleFactor))
  End Sub

  ''' <summary>
  ''' Compares two String arrays. Returns true if their content is identical and false otherwise.
  ''' </summary>
  ''' <param name="asFirst"></param>
  ''' <param name="asSecond"></param>
  ''' <returns></returns>
  ''' <remarks>Uses Exit For.</remarks>
  Public Shared Function IsEqual(asFirst As String(), asSecond As String()) As Boolean
    IsEqual = True

    If asFirst IsNot Nothing AndAlso asSecond IsNot Nothing AndAlso asFirst.Count = asSecond.Count Then
      For i As Integer = 0 To asFirst.Count - 1
        If asFirst(i) <> asSecond(i) Then
          IsEqual = False
          Exit For
        End If
      Next
    Else
      IsEqual = False
    End If
  End Function

End Class