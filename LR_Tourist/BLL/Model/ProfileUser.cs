
namespace BLL.Model
{
    public class ProfileUser : IProfilePerson
    {
        public string FirstName { get; set; }

        public string SecondName { get; set; }

        public string MiddleName { get; set; }

        public string Phone { get; set; }

        public string Address { get; set; }

        //public int IdTravelVoucher { get; set; }
    }
}
