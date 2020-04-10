
namespace BLL.Model
{
    public class HotelDTO
    {
        public int Id { get; set; }
        public string NameHotel { get; set; }

        public int Star { get; set; }

        public string Phone { get; set; }

        public override string ToString()
        {
            return $"{Id} {NameHotel} {Star} {Phone}";
        }

    }
}
