
namespace BLL.Model
{
    public class Hotel: DA.Data.IEntityBase
    {
        public int Id { get; }

        public string Name { get; set; }

        public int Star { get; set; }

        public string Phone { get; set; }

        public override string ToString()
        {
            return $"{Id} {Name} {Star} {Phone}";
        }

    }
}
