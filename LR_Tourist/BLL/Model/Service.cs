
namespace BLL.Model
{
    public class Service: IEntityBase
    {
        public int Id { get;}

        public string Name { get; set; }

        public override string ToString()
        {
            return $"{Id} {Name}";
        }
    }
}
