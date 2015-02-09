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

End Module
