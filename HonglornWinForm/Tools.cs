using System;
using System.Drawing;
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
  }
}