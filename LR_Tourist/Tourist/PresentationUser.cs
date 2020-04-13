using BLL.Model;
using BLL.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TouristConsole
{
    public class PresentationUser
    {
        private readonly UserService serviceUser;

        public PresentationUser(UserService serviceUser)
        {
            this.serviceUser = serviceUser;
        }

        public async Task<IEnumerable<User>> GetCollectionUsers()
        {
            IEnumerable<User> usersDTO = await serviceUser.GetItems();
            return usersDTO;
        }
        public async Task<User> GetUser(int id)
        {
            return await serviceUser.GetItem(id);
        }
        public async void CreateUser(User profileUser)
        {
            await serviceUser.Create(profileUser);
        }
        public async void UpdateUser(User profileUser)
        { 
            await serviceUser.Update(profileUser);
        }
        public async void DeleteUser(int id)
        {
            await serviceUser.Delete(id);
        }
    }
}
