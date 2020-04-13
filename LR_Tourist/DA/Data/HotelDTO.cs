
namespace DA.Data
{
    public class HotelDTO : IEntityBase
    {
        public int Id { get; set; }

        public string NameHotel { get; set; }

        public int Star { get; set; }

        public string Phone { get; set; }
        
    }
}
