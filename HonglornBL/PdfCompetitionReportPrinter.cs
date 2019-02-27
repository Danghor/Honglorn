using MigraDoc.DocumentObjectModel;
using MigraDoc.DocumentObjectModel.Tables;
using MigraDoc.Rendering;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace HonglornBL
{
    class PdfCompetitionReportPrinter
    {
        internal string SchoolName { get; set; }
        internal string ClassName { get; set; }
        internal string SexName { get; set; }
        internal DateTime Date { get; set; }
        internal sbyte FirstPercentile { get; set; }
        internal sbyte SecondPercentile { get; set; }
        internal sbyte ThirdPercentile { get; set; }
        internal int FirstPercentileCount { get; set; }
        internal int SecondPercentileCount { get; set; }
        internal int ThirdPercentileCount { get; set; }

        readonly string path;

        internal PdfCompetitionReportPrinter(string filePath)
        {
            path = filePath;

            if (!Path.HasExtension(path))
            {
                path = Path.Combine(filePath, ".pdf");
            }
        }

        public void PrintReport()
        {
            var numberOfParticipants = 16;
            var date = DateTime.Today.ToShortDateString();
            var firstPercentage = 20;
            var secondPercentage = 50;
            var thirdPercentage = 30;
            var firstPercentageCount = 4;
            var secondPercentageCount = 8;
            var thirdPercentageCount = 4;
            var place1 = 1;
            var place2 = 4;
            var place3 = 5;
            var place4 = 12;
            var place5 = 13;
            var place6 = 16;

            var document = new Document();
            Section section = document.AddSection();
            section.PageSetup.Orientation = Orientation.Landscape;
            section.PageSetup.MirrorMargins = true;
            section.PageSetup.LeftMargin = "1.27cm";
            section.PageSetup.TopMargin = "1.27cm";

            var myStyle = document.Styles["Heading1"];
            myStyle.Font.Size = 14;

            document.Styles["Normal"].Font.Size = 8;
            document.Styles["Normal"].Font.Name = "Arial";

            Paragraph para = section.AddParagraph("Wettbewerb");
            para.Style = "Heading1";

            var headlineTable = section.AddTable();
            headlineTable.AddColumn(new Unit(5, UnitType.Centimeter));
            headlineTable.AddColumn(new Unit(8, UnitType.Centimeter));
            headlineTable.AddColumn(new Unit(5, UnitType.Centimeter));
            headlineTable.AddColumn(new Unit(5, UnitType.Centimeter));
            headlineTable.AddColumn(new Unit(5, UnitType.Centimeter));

            var headlineRow = headlineTable.AddRow();

            headlineRow.Cells[0].AddParagraph("Auswertung Leichtathletik:");
            headlineRow.Cells[0].Style = "Heading1";

            headlineRow.Cells[1].Style = "Normal";
            headlineRow.Cells[1].AddParagraph($"Schule: {SchoolName}");
            headlineRow.Cells[1].AddParagraph($"Klassenstufe: {ClassName} - {SexName}");
            headlineRow.Cells[1].AddParagraph($"Teilnehmerzahl: {numberOfParticipants}");

            headlineRow.Cells[2].AddParagraph($"Datum: {date}");

            headlineRow.Cells[3].AddParagraph($"{firstPercentage}% = {firstPercentageCount} Schüler/Schülerinnen");
            headlineRow.Cells[3].AddParagraph($"{secondPercentage}% = {secondPercentageCount} Schüler/Schülerinnen");
            headlineRow.Cells[3].AddParagraph($"{thirdPercentage}% = {thirdPercentageCount} Schüler/Schülerinnen");

            headlineRow.Cells[4].AddParagraph($"Platz {place1} - {place2}");
            headlineRow.Cells[4].AddParagraph($"Platz {place3} - {place4}");
            headlineRow.Cells[4].AddParagraph($"Platz {place5} - {place6}");

            var table = section.AddTable();
            table.Borders.Width = 0.25;

            for (int i = 0; i < 21; i++)
            {
                var col = table.AddColumn();
                col.Width = new Unit(1.3, UnitType.Centimeter);
            }

            Row row = table.AddRow();
            row.HeadingFormat = true;

            row.Cells[1].AddParagraph("Name, Vorname");
            row.Cells[2].AddParagraph("Sprint");
            row.Cells[2].MergeRight = 1;
            row.Cells[4].AddParagraph("Sprung");
            row.Cells[4].MergeRight = 1;
            row.Cells[6].AddParagraph("Wurf");
            row.Cells[6].MergeRight = 1;
            row.Cells[8].AddParagraph("Ausdauer");
            row.Cells[8].MergeRight = 1;
            row.Cells[11].AddParagraph("Punkte");
            row.Cells[11].MergeRight = 5;
            row.Cells[18].AddParagraph("Urkunde");
            row.Cells[18].MergeRight = 2;


            Row secondHeader = table.AddRow();
            secondHeader.Cells[2].AddParagraph("Zeit");
            secondHeader.Cells[3].AddParagraph("Platz");
            secondHeader.Cells[4].AddParagraph("Bestl.");
            secondHeader.Cells[5].AddParagraph("Platz");
            secondHeader.Cells[6].AddParagraph("Summe");
            secondHeader.Cells[7].AddParagraph("Platz");
            secondHeader.Cells[8].AddParagraph("Leistung");
            secondHeader.Cells[9].AddParagraph("Platz");
            secondHeader.Cells[11].AddParagraph("Sprint");
            secondHeader.Cells[12].AddParagraph("Sprung");
            secondHeader.Cells[13].AddParagraph("Wurf");
            secondHeader.Cells[14].AddParagraph("Ausd.");
            secondHeader.Cells[15].AddParagraph("gesamt");
            secondHeader.Cells[16].AddParagraph("Platz");
            secondHeader.Cells[18].AddParagraph("Ehren");
            secondHeader.Cells[19].AddParagraph("Sieger");
            secondHeader.Cells[20].AddParagraph("Teiln.");

            var values = new[] { "1.", "Campo, Pia", "11,5", "1", "8", "1", "19", "1", "7", "3", "", "1", "1", "1", "3", "6", "1", "", "x", "", "" };

            Row row1 = table.AddRow();
            for (int i = 0; i < values.Length; i++)
            {
                row1.Cells[i].AddParagraph(values[i]);
            }

            var pdfRenderer = new PdfDocumentRenderer(true) { Document = document };
            pdfRenderer.Language = "de-DE";
            pdfRenderer.RenderDocument();

            pdfRenderer.PdfDocument.Save(path);
        }
    }
}