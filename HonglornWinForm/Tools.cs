using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace HonglornWinForm {
  static class Tools {
    /// <summary>
    ///   Positions the given control at the center of the screen.
    /// </summary>
    /// <param name="form">The control to be centered.</param>
    public static void Center(Control form) {
      form.Location = new Point {
        X = (Screen.PrimaryScreen.Bounds.Width - form.Width) / 2,
        Y = (Screen.PrimaryScreen.Bounds.Height - form.Height) / 2
      };
    }

    /// <summary>
    ///   Scales the given control dependent on the screen-measurements.
    /// </summary>
    /// <param name="form">The control to be scaled.</param>
    /// <param name="scalingFactor">The scale factor to be used. 1 will make the control just as big as the screen.</param>
    public static void ScaleScreenAware(Control form, float scalingFactor) {
      form.Height = Convert.ToInt32(Screen.PrimaryScreen.Bounds.Height * scalingFactor);
      form.Width = Convert.ToInt32(Screen.PrimaryScreen.Bounds.Width * scalingFactor);
    }

    /// <summary>
    ///   Compares two String arrays. Returns true if their content is identical and false otherwise.
    /// </summary>
    /// <param name="asFirst"></param>
    /// <param name="asSecond"></param>
    /// <returns></returns>
    /// <remarks>Uses Exit For.</remarks>
    public static bool IsEqual(string[] asFirst, string[] asSecond) {
      bool functionReturnValue = false;
      functionReturnValue = true;

      if (asFirst != null && asSecond != null && asFirst.Count() == asSecond.Count()) {
        for (int i = 0; i <= asFirst.Count() - 1; i++) {
          if (asFirst[i] != asSecond[i]) {
            functionReturnValue = false;
            break; // TODO: might not be correct. Was : Exit For
          }
        }
      } else {
        functionReturnValue = false;
      }
      return functionReturnValue;
    }

    //todo: write third method that just compares two objects and checks their type beforehand
    //reference this method by the above and below methods

    /// <summary>
    ///   Compares two Char arrays. Returns true if their content is identical and false otherwise.
    /// </summary>
    /// <param name="acFirst"></param>
    /// <param name="acSecond"></param>
    /// <returns></returns>
    /// <remarks>Uses Exit For.</remarks>
    public static bool IsEqual(char[] acFirst, char[] acSecond) {
      bool functionReturnValue = false;
      functionReturnValue = true;

      if (acFirst != null && acSecond != null && acFirst.Count() == acSecond.Count()) {
        for (int i = 0; i <= acFirst.Count() - 1; i++) {
          if (acFirst[i] != acSecond[i]) {
            functionReturnValue = false;
            break; // TODO: might not be correct. Was : Exit For
          }
        }
      } else {
        functionReturnValue = false;
      }
      return functionReturnValue;
    }
  }
}