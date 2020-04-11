using BLL.Model;
using BLL.Services;
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
        public void CreateUser(UserDTO profileUser)
        {
            serviceUser.Create(profileUser);
        }
        public void UpdateUser(UserDTO profileUser)
        { 
            serviceUser.Update(profileUser);
        }
        public void DeleteUser(int id)
        {
            serviceUser.Delete(id);
        }
    }
}
