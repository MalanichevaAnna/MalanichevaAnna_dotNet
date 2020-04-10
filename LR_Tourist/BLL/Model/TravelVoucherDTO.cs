using System;

namespace BLL.Model
{
    public class TravelVoucherDTO
    {
        public int Id { get; set; }
        public string Country { get; set; }

        public DateTime Arrival { get; set; }

        public DateTime Departure { get; set; }

        public int Price { get; set; }

        public int ServicesId { get; set; }

        public int HotelId { get; set; }

        public int StaffId { get; set; }

        public int UserId { get; set; }

        public override string ToString()
        {
            return $"{Id} {Country} {Arrival} {Departure} {Price} ";
        }

    }
}
