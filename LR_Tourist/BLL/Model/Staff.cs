
namespace BLL.Model
{
    public class Staff : IPerson, IEntityBase
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string MiddleName { get; set; }

        public string Role { get; set; }

        public string Phone { get; set; }

        public string PersonalNumber { get; set; }

        public int Salary { get; set; }

        public override string ToString()
        {
            return $"{Id} {FirstName} {LastName} {MiddleName} {Role} {Phone} {PersonalNumber} {Salary}";
        }
    }
}
