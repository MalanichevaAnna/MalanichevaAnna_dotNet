using BLL.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace TouristConsole
{
    public class PreaentationService
    {
        private readonly ServiceService service;

        public PresentationHotel(HotelService serviceHotel)
        {
            this.service = serviceHotel;
        }

        public IEnumerable<HotelDTO> GetCollectionHotels()
        {
            IEnumerable<HotelDTO> usersDTO = service.GetItems();
            return usersDTO;
        }
        public HotelDTO GetHotel(int? id)
        {
            return service.GetItem(id);
        }
        public string CreateHotel(HotelDTO profileHotel)
        {
            try
            {
                service.Create(profileHotel);
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
                service.Update(profileHotel);
                return "Успешно добваено";
            }
            catch (ValidationException ex)
            {
                throw new ValidationException(ex.Property, ex.Message);
            }
        }
        public string DeleteHotel(int id)
        {
            try
            {
                service.Delete(id);
                return "Успешно добваено";
            }
            catch (ValidationException ex)
            {
                throw new ValidationException(ex.Property, ex.Message);
            }
        }
    }
}
