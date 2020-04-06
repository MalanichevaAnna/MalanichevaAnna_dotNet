using BLL.Interfaces;
using BLL.Model;
using BLL.ValidException;
using System.Collections.Generic;

namespace TouristConsole
{
    class PresentationHotel
    {
        public IEnumerable<ProfileHotel> GetCollectionHotels(IService<ProfileHotel> serviceHotel)
        {
            IEnumerable<ProfileHotel> usersDTO = serviceHotel.GetItems();
            return usersDTO;
        }
        public ProfileHotel GetHotel(IService<ProfileHotel> serviceHotel, int? id)
        {
            return serviceUser.GetItem(id);
        }
        public string CreateHotel(ICRUDService<ProfileHotel> serviceUser, ProfileHotel profileUser)
        {
            try
            {
                serviceUser.Create(profileUser);
                return "Успешно добваено";
            }
            catch (ValidationException ex)
            {
                throw new ValidationException(ex.Property, ex.Message);
            }
        }
    }
}
