using BLL.Interfaces;
using BLL.Model;
using BLL.ValidException;
using System.Collections.Generic;

namespace TouristConsole
{
    class PresentationUser
    {
        public IEnumerable<ProfileUser> GetCollectionUsers(IService<ProfileUser> serviceUser)
        {
            IEnumerable<ProfileUser> usersDTO = serviceUser.GetItems();
            return usersDTO;
        }
        public ProfileUser GetUser(IService<ProfileUser> serviceUser,int? id)
        {
            return serviceUser.GetItem(id);
        }
        public string CreateUser(ICRUDService<ProfileUser> serviceUser, ProfileUser profileUser)
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
        public string UpdataUser(ICRUDService<ProfileUser> serviceUser, ProfileUser profileUser)
        {
            try
            {
                serviceUser.Update(profileUser);
                return "Успешно добваено";
            }
            catch (ValidationException ex)
            {
                throw new ValidationException(ex.Property, ex.Message);
            }
        }
        public string DeleteUser(ICRUDService<ProfileUser> serviceUser, ProfileUser profileUser)
        {
            try
            {
                serviceUser.Delete(profileUser);
                return "Успешно добваено";
            }
            catch (ValidationException ex)
            {
                throw new ValidationException(ex.Property, ex.Message);
            }
        }

    }
}
