Imports System.Text.RegularExpressions

Public Module Prerequisites

  Public Const DATABASE_NAME As String = "bjs"

  Public ReadOnly VALID_CLASSNAMES As Char() = {"5"c, "6"c, "7"c, "8"c, "9"c, "E"c}

  Enum Discipline
    Sprint
    Jump
    [Throw]
    MiddleDistance
  End Enum

  Enum GameType
    Competition
    Traditional
  End Enum

  Enum Sex
    Male
    Female
  End Enum

  ''' <summary>
  ''' Returns true if the given input year is a value between (including) 1900 and 2099
  ''' </summary>
  ''' <param name="iYear">The year to be validated.</param>
  ''' <returns>True if the given year is a valid year.</returns>
  ''' <remarks></remarks>
  Function IsValidYear(iYear As Integer) As Boolean
    If Regex.IsMatch(CStr(iYear), "(19|20)[0-9]{2}") Then
      IsValidYear = True
    Else
      IsValidYear = False
    End If
  End Function

End Module
