using OfficeOpenXml;
using System;
using System.IO;
using System.Linq;

namespace LR_1.DL.ReaderWriter.Writer
{
    public class ExcelWriter : IWriter
    {
        private const int rowOffset = 2;

        public void Write(StudentAndSummaryMarkInfo info, string path)
        {
            if (info == null || string.IsNullOrEmpty(path))
            {
                throw new ArgumentNullException();
            }

            using var stream = new FileStream(path, FileMode.Create);
            using var package = new ExcelPackage(stream);

            var worksheet = package.Workbook.Worksheets.Add(typeof(StudentAndSummaryMarkInfo).Name);
 
            var range = worksheet.Cells[1, 1];

            range.LoadFromCollection(info.StudentsInfo, true);

            range.AutoFitColumns();

            var lastRow = worksheet.Dimension.End.Row;

            range = worksheet.Cells[lastRow + rowOffset, 1];

            range.LoadFromCollection(info.SummaryMarkInfo.AverageMarks, true);

            package.Save();
        }
    }
}
