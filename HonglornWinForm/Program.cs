using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Serialization;
using HonglornBL.Models.Entities;
using HonglornBL.Models.Framework;
using static HonglornBL.Prerequisites;

namespace HonglornWinForm {
  static class Program {
    /// <summary>
    ///   The main entry point for the application.
    /// </summary>
    [STAThread]
    static void Main() {
      Application.EnableVisualStyles();
      Application.SetCompatibleTextRenderingDefault(false);
      Application.Run(new MainForm());
    }
  }
}