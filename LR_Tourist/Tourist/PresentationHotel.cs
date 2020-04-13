using BLL.Model;
using BLL.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TouristConsole
{
    public class PresentationHotel
    {
        private readonly HotelService serviceHotel;

        public PresentationHotel(HotelService serviceHotel)
        {
            this.serviceHotel = serviceHotel;
        }

        public async Task<IEnumerable<Hotel>> GetCollectionHotels()
        {
            IEnumerable<Hotel> hotelsDTO = await serviceHotel.GetItems();
            return hotelsDTO;
        }
        public async Task<Hotel> GetHotel(int id)
        {
            return await serviceHotel.GetItem(id);
        }
        public async void CreateHotel(Hotel hotelDTO)
        {
            await serviceHotel.Create(hotelDTO);
        }
        public async void UpdateHotel(Hotel hotelDTO)
        {
            await serviceHotel.Update(hotelDTO);
        }
        public async void DeleteHotel(int id)
        {
            await serviceHotel.Delete(id);
        }
    }
}
