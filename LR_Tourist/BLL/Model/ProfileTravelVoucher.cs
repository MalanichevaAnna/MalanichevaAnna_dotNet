using System;

namespace BLL.Model
{
    public class ProfileTravelVoucher : ProfileEntityBase
    { 
        public string Country { get; set; }

        public DateTime Arrival { get; set; }

        public DateTime Departure { get; set; }

        public int Price { get; set; }

        public int IdServices { get; set; }

        public int IdHotel { get; set; }

        public int IdStaff { get; set; }



    }
}
