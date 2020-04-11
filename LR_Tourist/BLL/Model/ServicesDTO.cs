
using DA.Data;

namespace BLL.Model
{
    public class ServicesDTO: IEntityBase
    {
        public int Id { get; set; }

        public string NameServices { get; set; }

        public override string ToString()
        {
            return $"{Id} {NameServices}";
        }
    }
}
