using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using CsvHelper;

namespace LR_1.Domain
{
    public class CsvReader : DL.ReaderWriter.IReader
    {
        public IEnumerable<Student> Reader(string path)
        {
            if (string.IsNullOrEmpty(path))
            {
                throw new ArgumentNullException();
            }

            var students = new List<Student>();

            using var reader = new StreamReader(path);
            using var csv = new CsvHelper.CsvReader(reader, CultureInfo.InvariantCulture);

            csv.Read();
            csv.ReadHeader();

            var subjectNames = csv.Context.HeaderRecord.Skip(3).ToList();
            while (csv.Read())
            {
                if (csv.Context.Record.Length != csv.Context.HeaderRecord.Length)
                {
                    throw new InvalidDataException("The number of items and ratings does not match");
                }

                var student = new Student
                {
                    FirstName = csv.GetField<string>(0),
                    Surname = csv.GetField<string>(1),
                    MiddleName = csv.GetField<string>(2),
                    ListSubjects = subjectNames.Select(sn => new Subject
                    {
                        Name = sn,
                        Mark = csv.GetField<int>(sn)
                    }).ToList()
                };
               
                students.Add(student);
            }

            return students;
        }
    }
}
