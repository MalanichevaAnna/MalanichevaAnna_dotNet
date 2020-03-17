using System.Collections.Generic;

namespace LR_1.Domain
{
    public class Student
    {
        public string Surname { get; set; }

        public string MiddleName { get; set; }

        public string FirstName { get; set; }
        
        public IReadOnlyCollection<Subject> ListSubjects { get; set; }
    }
}
