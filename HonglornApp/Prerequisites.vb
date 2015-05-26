Imports System.Text.RegularExpressions

Public Module Prerequisites
  Public Const ALPHABET As String = "ABCDEFGHIJKLMNOPQRSTUVWXYZ"

  Private ReadOnly VALID_CLASSNAMES As Char() = {"5"c, "6"c, "7"c, "8"c, "9"c, "E"c}

  Enum Discipline
    Sprint
    Jump
    [Throw]
    MiddleDistance
  End Enum

  Enum GameType
    Competition
    Traditional
    Unknown
  End Enum

  Enum Sex
    Male
    Female
  End Enum

  ''' <summary>
  '''   Returns true iff the given input year is a value between (including) 1900 and 2099.
  ''' </summary>
  ''' <param name="iYear">The year to be validated.</param>
  ''' <returns>True iff the given year is a valid year.</returns>
  ''' <remarks>Valid Years: 1900 - 2099</remarks>
  Function IsValidYear(iYear As Integer) As Boolean
    If Regex.IsMatch(CStr(iYear), "(19|20)[0-9]{2}") Then
      IsValidYear = True
    Else
      IsValidYear = False
    End If
  End Function

  ''' <summary>
  '''   Returns true iff the given character is a valid class name that can be used at all in the application.
  ''' </summary>
  ''' <param name="cClassName">The class name to be validated.</param>
  ''' <returns>True iff the given class name is a valid class name.</returns>
  ''' <remarks>Valid classnames: 5, 6, 7, 8, 9, E</remarks>
  Function IsValidClassName(cClassName As Char) As Boolean
    IsValidClassName = VALID_CLASSNAMES.Contains(cClassName)
  End Function
End Module
