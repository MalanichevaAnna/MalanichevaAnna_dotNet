using BLL.Model;
using BLL.Services;
using BLL.ValidException;
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
            IEnumerable<HotelDTO> usersDTO = serviceHotel.GetItems();
            return usersDTO;
        }
        public HotelDTO GetHotel(int? id)
        {
            return serviceHotel.GetItem(id);
        }
        public string CreateHotel(HotelDTO profileHotel)
        {
            try
            {
                serviceHotel.Create(profileHotel);
                return "Успешно добваено";
            }
            catch (ValidationException ex)
            {
                throw new ValidationException(ex.Property, ex.Message);
            }
        }
        public string UpdateHotel(HotelDTO profileHotel)
        {
            try
            {
                serviceHotel.Update(profileHotel);
                return "Успешно добваено";
            }
            catch (ValidationException ex)
            {
                throw new ValidationException(ex.Property, ex.Message);
            }
        }
        public string DeleteHaotel(HotelDTO profileHotel)
        {
            try
            {
                serviceHotel.Delete(profileHotel);
                return "Успешно добваено";
            }
            catch (ValidationException ex)
            {
                throw new ValidationException(ex.Property, ex.Message);
            }
        }
    }
}
