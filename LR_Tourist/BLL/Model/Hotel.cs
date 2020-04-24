using System.ComponentModel.DataAnnotations;

namespace BLL.Model
{
    public class Hotel: IEntityBase
    {
        [Required]
        public int Id { get; set; }
        
        [Required]
        public string Name { get; set; }

        [Required]
        public int Star { get; set; }

        [Required]
        public string Phone { get; set; }

        public override string ToString()
        {
            return $"{Id} {Name} {Star} {Phone}";
        }

    }
}
