using System;
using System.Collections.Generic;
using System.Text;

namespace DA.Data
{
    public class Staff : EntityBase , IPerson
    {
        public string FirstName { get; set; }
        
        public string SecondName { get; set; }

        public string MiddleName { get; set; }

        public string Role { get; set; }

        public string Phone { get; set; }

        public string PersonalNumber { get; set; }

        public int Salary { get; set; }
    }
}
