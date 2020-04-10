using BLL.Model;
using BLL.Services;
using BLL.ValidException;
using System.Collections.Generic;

namespace TouristConsole
{
    public class PresentationUser
    {
        private readonly UserService serviceUser;

        public PresentationUser(UserService serviceUser)
        {
            this.serviceUser = serviceUser;
        }

        public  IEnumerable<UserDTO> GetCollectionUsers()
        {
            IEnumerable<UserDTO> usersDTO = serviceUser.GetItems();
            return usersDTO;
        }
        public UserDTO GetUser(int? id)
        {
            return serviceUser.GetItem(id);
        }
        public string CreateUser(UserDTO profileUser)
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
        public string UpdateUser(UserDTO profileUser)
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
        public string DeleteUser(UserDTO profileUser)
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
