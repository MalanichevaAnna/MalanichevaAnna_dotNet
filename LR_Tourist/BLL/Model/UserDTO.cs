
namespace BLL.Model
{
    public class UserDTO : IPersonDTO, IEntityBaseDTO
    {
        public int Id { get; set; }
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string MiddleName { get; set; }

        public string Phone { get; set; }

        public string Address { get; set; }

        public override string ToString()
        {
            return $"{Id} {FirstName} {LastName} {MiddleName} {Phone} {Address}";
        }
    }
}
