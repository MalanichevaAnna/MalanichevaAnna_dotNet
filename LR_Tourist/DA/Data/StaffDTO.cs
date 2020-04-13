
namespace DA.Data
{
    public class StaffDTO : IEntityBase, IPerson
    {
        public int Id { get; }
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string MiddleName { get; set; }

        public string Role { get; set; }

        public string Phone { get; set; }

        public string PersonalNumber { get; set; }

        public int Salary { get; set; }
    }
}
