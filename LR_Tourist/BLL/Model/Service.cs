
using DA.Data;

namespace BLL.Model
{
    public class Service: DA.Data.IEntityBase
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public override string ToString()
        {
            return $"{Id} {Name}";
        }
    }
}
