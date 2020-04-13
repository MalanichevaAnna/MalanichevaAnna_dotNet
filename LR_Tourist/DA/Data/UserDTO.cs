﻿
namespace DA.Data
{
    public class UserDTO : IPerson, IEntityBase
    {
        public int Id { get; }
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string MiddleName { get; set; }

        public string Phone { get; set; }

        public string Address { get; set; }
    }
}
