using System;
using HonglornBL.Models.Entities;
using static HonglornBL.Prerequisites;

namespace HonglornBL {
  static class TraditionalCalculator {
    /// <summary>
    ///   Calculates the score based on the given discipline and value.
    /// </summary>
    /// <param name="discipline">The traditional discipline that was performed.</param>
    /// <param name="value">The raw value of the performance achieved.</param>
    /// <returns>The score calculated by designated formulas.</returns>
    internal static ushort CalculateScore(TraditionalDiscipline discipline, float? value) {
      ValidateDiscipline(discipline);

      ushort score = 0;

      if (value != null) {
        switch (discipline.Type) {
          case DisciplineType.Sprint:
            if (discipline.Measurement == Measurement.Manual) {
              score = CalculateRunningScoreManual((float) value, (ushort) discipline.Distance, (float) discipline.Overhead, discipline.ConstantA, discipline.ConstantC);
            } else if (discipline.Measurement == Measurement.Electronic) {
              score = CalculateRunningScoreElectronic((float) value, (ushort) discipline.Distance, discipline.ConstantA, discipline.ConstantC);
            }

            break;
          case DisciplineType.Jump:
          case DisciplineType.Throw:
            score = CalculateJumpThrowScore((float) value, discipline.ConstantA, discipline.ConstantC);
            break;
          case DisciplineType.MiddleDistance:
            score = CalculateRunningScoreElectronic((float) value, (ushort) discipline.Distance, discipline.ConstantA, discipline.ConstantC);
            break;
        }
      }

      return score;
    }


    static void ValidateDiscipline(TraditionalDiscipline discipline) {
      //discipline null
      if (discipline == null) {
        throw new ArgumentNullException(nameof(discipline));
      }

      //Constant C is 0
      if (Math.Abs(discipline.ConstantC) < float.Epsilon) {
        throw new ArgumentOutOfRangeException(nameof(discipline.ConstantC), "Invalid value for constant would result in a division by 0.");
      }

      if (discipline.Type == DisciplineType.Sprint) {
        //Sprint
        if (discipline.Measurement == Measurement.Manual && discipline.Overhead == null) {
          throw new ArgumentNullException(nameof(discipline.Overhead), $"{nameof(discipline.Overhead)} must not be null for {nameof(Measurement)} {nameof(Measurement.Manual)}");
        }

        VerifyDistanceIsNotNull(discipline);
      } else if (discipline.Type == DisciplineType.MiddleDistance) {
        //MiddleDistance
        VerifyDistanceIsNotNull(discipline);
      }
    }

    static void VerifyDistanceIsNotNull(TraditionalDiscipline discipline) {
      if (discipline.Distance == null) {
        throw new ArgumentNullException(nameof(discipline.Distance), $"{nameof(discipline.Distance)} must not be null for a {discipline.Type} discipline.");
      }
    }

    static ushort CalculateRunningScoreManual(float seconds, ushort distance, float overhead, float constantA, float constantC) {
      return (ushort) Math.Floor((distance / (seconds + overhead) - constantA) / constantC);
    }

    static ushort CalculateRunningScoreElectronic(float seconds, ushort distance, float constantA, float constantC) {
      return (ushort) Math.Floor((distance / seconds - constantA) / constantC);
    }

    static ushort CalculateJumpThrowScore(float meters, float constantA, float constantC) {
      return (ushort) Math.Floor((Math.Sqrt(meters) - constantA) / constantC);
    }
  }
}