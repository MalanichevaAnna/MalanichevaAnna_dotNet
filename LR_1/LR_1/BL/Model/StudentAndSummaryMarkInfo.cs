using LR_1.DL.Model;
using LR_1.Domain;
using System.Collections.Generic;

namespace LR_1.DL
{
    public class StudentAndSummaryMarkInfo
    {
        public IReadOnlyCollection<StudentInfo> StudentsInfo { get; set; }

        public SummaryMarkInfo SummaryMarkInfo { get; set; }
    }
}
