using AutoMapper;
using BLL.Interfaces;
using BLL.Model;
using DA.Data;
using DA.Services.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class UserService : IService<User>, ICRUDService<User>
    {
        private readonly IRepository<UserDTO> repoUser;

        private readonly IMapper _mapper;

        public UserService(IRepository<UserDTO> repositoryUser, IMapper mapper)
        {
            repoUser = repositoryUser;
            _mapper = mapper;
        }
      
        public async Task<User> GetItem(int id)
        {
            var user = await repoUser.Get(id);
            if (user == null)
            {
                throw new ArgumentException("User not found");
            }

            return new Model.User
            {
                Id = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                MiddleName = user.MiddleName,
                Phone = user.Phone,
                Address = user.Address,
            };
        }

        public async Task<IEnumerable<User>> GetItems()
        {
            return _mapper.Map<IEnumerable<UserDTO>, List<User>>(await repoUser.GetAll());
        }

        public async Task Create(User item)
        {
            if (item == null)
            {
                throw new ArgumentNullException(nameof(item));
            }
            else
            {
                await repoUser.Create(_mapper.Map<UserDTO>(item));
            }
        }

        public async Task Update(User item)
        {
            if (item == null)
            {
                throw new ArgumentNullException(nameof(item));
            }
            else
            {
                await repoUser.Update(_mapper.Map<DA.Data.UserDTO>(item));
            }
        }

        public async Task Delete(int id)
        {
            var item = GetItems().Result.Where(el =>el.Id == id).ToList();
            if (item == null)
            {
                throw new ArgumentNullException(nameof(item));
            }
            else
            {
                await repoUser.Delete(_mapper.Map<DA.Data.UserDTO>(item[0]).Id);
            }
        }
    }
}
