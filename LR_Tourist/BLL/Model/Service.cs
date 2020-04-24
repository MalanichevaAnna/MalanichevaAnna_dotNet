
using System.ComponentModel.DataAnnotations;

namespace BLL.Model
{
    public class Service: IEntityBase
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public override string ToString()
        {
            return $"{Id} {Name}";
        }
    }
}
