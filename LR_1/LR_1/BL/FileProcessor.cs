using LR_1.DL;
using LR_1.DL.ReaderWriter;
using LR_1.Domain;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LR_1.BL
{
    public class FileProcessor
    {
        private readonly IWriter _writer;
        private readonly IReader _reader;

        public FileProcessor(IWriter writer, IReader reader)
        {
            _writer = writer ?? throw new ArgumentNullException(nameof(writer));
            _reader = reader ?? throw new ArgumentNullException(nameof(reader));
        }

        public IEnumerable<Student> Read(string inputFile)
        {
            if (string.IsNullOrEmpty(inputFile))
            {
                throw new ArgumentNullException(nameof(inputFile));
            }

            return _reader.Reader(inputFile);
        }

        public void Write(string outputFile, IEnumerable<Student> studentInfos)
        {
            if (string.IsNullOrEmpty(outputFile))
            {
                throw new ArgumentNullException(nameof(outputFile));
            }

            if (studentInfos == null)
            {
                throw new ArgumentNullException(nameof(studentInfos));
            }

            var studentsInfo = studentInfos.GetStudentsInfo().ToList().AsReadOnly();
            var summaryMarkInfo = studentInfos.GetSummaryMarksInfo();

            var groupReport = new StudentAndSummaryMarkInfo
            {
                SummaryMarkInfo = summaryMarkInfo,
                StudentsInfo = studentsInfo
            };

            _writer.Write(groupReport, outputFile);
        }
    }
}
