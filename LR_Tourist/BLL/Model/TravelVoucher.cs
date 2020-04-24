using System;
using System.ComponentModel.DataAnnotations;

namespace BLL.Model
{
    public class TravelVoucher: IEntityBase
    {
        public int Id { get; set; }

        [Required]
        public string Country { get; set; }

        [Required]
        public DateTime Arrival { get; set; }

        [Required]
        public DateTime Departure { get; set; }

        [Required]
        public int Price { get; set; }

        [Required]
        public int ServicesId { get; set; }

        [Required]
        public int HotelId { get; set; }

        [Required]
        public int StaffId { get; set; }

        [Required]
        public int UserId { get; set; }

        public override string ToString()
        {
            return $"{Id} {Country} {Arrival} {Departure} {Price} {HotelId} {StaffId} {UserId} ";
        }

    }
}
