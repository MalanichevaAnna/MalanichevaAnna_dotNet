
using System.ComponentModel.DataAnnotations;

namespace BLL.Model
{
    public class User : IPerson, IEntityBase
    {
        public int Id { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        public string MiddleName { get; set; }

        [Required]
        public string Phone { get; set; }

        [Required]
        public string Address { get; set; }

        public override string ToString()
        {
            return $"{Id} {FirstName} {LastName} {MiddleName} {Phone} {Address}";
        }
    }
}
