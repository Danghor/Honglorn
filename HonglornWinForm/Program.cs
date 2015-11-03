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

    static void foo() {
      //Honglorn.ImportStudentCourseExcelSheet(@"C:\Git\Honglorn\IMPORT~1.XLS", 2015);
      Dictionary<string, DisciplineType> disciplineMap = new Dictionary<string, DisciplineType> {
        {"Sprint", DisciplineType.Sprint},
        {"Jump", DisciplineType.Jump},
        {"Throw", DisciplineType.Throw},
        {"MiddleDistance", DisciplineType.MiddleDistance}
      };

      Dictionary<string, Sex> sexMap = new Dictionary<string, Sex> {
        {"Male", Sex.Male},
        {"Female", Sex.Female}
      };

      Dictionary<string, Measurement> measurementMap = new Dictionary<string, Measurement> {
        {"Manual", Measurement.Manual},
        {"Electronic", Measurement.Electronic}
      };

      List<TraditionalDiscipline> list = new List<TraditionalDiscipline>();

      using (HonglornDB db = new HonglornDB()) {
        XmlDocument doc = new XmlDocument();
        doc.Load(@"C:\Git\Honglorn\HonglornBL\Models\Seeds\TraditionalDisciplines.xml");

        foreach (XmlNode row in doc.DocumentElement.ChildNodes) {
          TraditionalDiscipline t = new TraditionalDiscipline();

          string rawType = row.SelectNodes("field[@name='Type']").Item(0).InnerText;
          string rawSex = row.SelectNodes("field[@name='Sex']").Item(0).InnerText;
          t.Name = row.SelectNodes("field[@name='Name']").Item(0).InnerText;
          t.Unit = row.SelectNodes("field[@name='Unit']").Item(0).InnerText;
          string rawDistance = row.SelectNodes("field[@name='Distance']").Item(0).InnerText;
          string rawOverhead = row.SelectNodes("field[@name='Overhead']").Item(0).InnerText;
          string rawConstA = row.SelectNodes("field[@name='ConstantA']").Item(0).InnerText;
          string rawConstC = row.SelectNodes("field[@name='ConstantC']").Item(0).InnerText;
          string rawMeasurement = row.SelectNodes("field[@name='Measurement']").Item(0).InnerText;

          t.Type = disciplineMap[rawType];
          t.Sex = sexMap[rawSex];

          if (!string.IsNullOrEmpty(rawDistance)) {
            t.Distance = Convert.ToInt16(rawDistance);
          }

          if (!string.IsNullOrEmpty(rawOverhead)) {
            t.Overhead = Convert.ToSingle(rawOverhead, CultureInfo.InvariantCulture);
          }

          if (!string.IsNullOrEmpty(rawConstA)) {
            t.ConstantA = Convert.ToSingle(rawConstA, CultureInfo.InvariantCulture);
          }

          if (!string.IsNullOrEmpty(rawConstC)) {
            t.ConstantC = Convert.ToSingle(rawConstC, CultureInfo.InvariantCulture);
          }

          if (!string.IsNullOrEmpty(rawMeasurement)) {
            t.Measurement = measurementMap[rawMeasurement];
          }

          list.Add(t);
        }

        XmlWriterSettings xmlWriterSettings = new XmlWriterSettings {
          Encoding = Encoding.UTF8
        };

        string path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "//SerializationOverview.xml";
        FileStream file = File.Create(path);

        XmlSerializer serializer = new XmlSerializer(list.GetType());
        serializer.Serialize(file, list);
      }
    }

    static void bar() {
      XmlSerializer serializer = new XmlSerializer(typeof(TraditionalDiscipline[]));

      XmlReader reader = XmlReader.Create(@"C:\Git\Honglorn\HonglornBL\Models\Seeds\ArrayOfTraditionalDiscipline.xml");

      TraditionalDiscipline[] array = serializer.Deserialize(reader) as TraditionalDiscipline[];
    }
  }
}