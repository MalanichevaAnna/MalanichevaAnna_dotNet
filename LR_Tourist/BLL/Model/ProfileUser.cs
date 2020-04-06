﻿
namespace BLL.Model
{
    public class ProfileUser : IProfilePerson
    {
        public int Id { get; set; }
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string MiddleName { get; set; }

        public string Phone { get; set; }

        public string Address { get; set; }

        //public int IdTravelVoucher { get; set; }
    }
}
