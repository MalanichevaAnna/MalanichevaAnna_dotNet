using AutoMapper;
using BLL.Interfaces;
using BLL.Model;

using DA.Data;
using DA.Services.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
namespace BLL.Services
{
    public class UserService : IService<UserDTO>, ICRUDService<UserDTO>
    {
        IRepository<User> repoUser { get; set; }
        private readonly IMapper _mapper;
        public UserService(IRepository<User> repositoryUser, IMapper mapper)
        {
            repoUser = repositoryUser;
            _mapper = mapper;
        }
      
        public UserDTO GetItem(int? id)
        {
            if (id == null)
                throw new ArgumentException("Check id");
            var user = repoUser.Get(id.Value);
            if (user == null)
                throw new ArgumentException("User not found");

            return new UserDTO
            {
                Id = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                MiddleName = user.MiddleName,
                Phone = user.Phone,
                Address = user.Address,
            };
        }

        public IEnumerable<UserDTO> GetItems()
        {
            return _mapper.Map<IEnumerable<User>, List<UserDTO>>(repoUser.GetAll());
        }

        public void Create(UserDTO item)
        {
            if (item == null)
            {
                throw new ArgumentNullException(nameof(item));
            }
            else
            {
                repoUser.Create(_mapper.Map<User>(item));
                Save();
            }
        }

        public void Update(UserDTO item)
        {
            if (item == null)
            {
                throw new ArgumentNullException(nameof(item));
            }
            else
            {
                repoUser.Update(_mapper.Map<User>(item));
                Save();
            }
        }

        public void Save()
        {
            repoUser.Save();
        }

        public void Delete(int id)
        {
            var item = GetItems().Where(el =>el.Id == id).ToList();
            if (item == null)
            {
                throw new ArgumentNullException(nameof(item));
            }
            else
            {
                repoUser.Delete(_mapper.Map<User>(item[0]).Id);
                Save();
            }
        }
    }
}
