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
               

            var excelFile = new FileInfo(path);
            using ExcelPackage package = new ExcelPackage(excelFile);
            
            if (package.Workbook.Worksheets.Count(worksheet => worksheet.Name == typeof(StudentAndSummaryMarkInfo).Name ) > 0)
            {
                package.Workbook.Worksheets.Delete(typeof(StudentAndSummaryMarkInfo).Name);
            }
            
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
