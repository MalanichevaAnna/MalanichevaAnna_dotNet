using BLL.Model;
using BLL.Services;
using System.Collections.Generic;

namespace TouristConsole
{
    public class PresentationHotel
    {
        private readonly HotelService serviceHotel;

        public PresentationHotel(HotelService serviceHotel)
        {
            this.serviceHotel = serviceHotel;
        }

        public IEnumerable<HotelDTO> GetCollectionHotels()
        {
            IEnumerable<HotelDTO> hotelsDTO = serviceHotel.GetItems();
            return hotelsDTO;
        }
        public HotelDTO GetHotel(int? id)
        {
            return serviceHotel.GetItem(id);
        }
        public void CreateHotel(HotelDTO hotelDTO)
        {
            serviceHotel.Create(hotelDTO);
        }
        public void UpdateHotel(HotelDTO hotelDTO)
        {
            serviceHotel.Update(hotelDTO);
        }
        public void DeleteHotel(int id)
        {
            serviceHotel.Delete(id);
        }
    }
}
