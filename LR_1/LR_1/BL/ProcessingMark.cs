using LR_1.DL.Model;
using System.Collections.Generic;
using System.Linq;

namespace LR_1.Domain
{
    public static class ProcessingMark
    {
        public static IEnumerable<StudentInfo> GetStudentsInfo(this IEnumerable<Student> students)
        {
           return students.Select(student => new StudentInfo
            {
                FirstName = student.FirstName,
                Surname = student.Surname,
                MiddleName = student.MiddleName,
                Average = student.ListSubjects.GetAverageMark()
            });
        }

        public static SummaryMarkInfo GetSummaryMarksInfo(this IEnumerable<Student> students)
        {
            var averageMarks = students
                .SelectMany(student => student.ListSubjects)
                .GroupBy(mark => mark.Name)
                .Select(subject => new Subject
                {
                    Name = subject.Key,
                    Mark = subject.Average(subject => subject.Mark) 
                    
                }).ToList();

            averageMarks.Add(new Subject()
            {
                Name = "TotalAverageMark",
                Mark = averageMarks.Average(item => item.Mark)
            });

            var summaryMarkInfo = new SummaryMarkInfo()
            {
                AverageMarks = averageMarks.AsReadOnly()
            };

            return summaryMarkInfo;
        }
        private static double GetAverageMark(this IEnumerable<Subject> subjects)
            => subjects.Sum(subject => subject.Mark) / subjects.Count();

    }
}
