using AutoMapper;
using BLL.Interfaces;
using BLL.Model;
using BLL.ValidException;
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
                throw new ValidationException("Не установлено id пользователь ", "");
            var user = repoUser.Get(id.Value);
            if (user == null)
                throw new ValidationException("Пользователь не найден", "");

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
                throw new ValidationException("Пустой объект ", "");
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
                throw new ValidationException("Пустой объект ", "");
            }
            else
            {
                repoUser.Update(_mapper.Map<User>(item));
                Save();
            }
        }

        public void Delete(UserDTO item)
        {
            if (item == null)
            {
                throw new ValidationException("Пустой объект ", "");
            }
            else
            {
                repoUser.Delete(_mapper.Map<User>(item));
                Save();
            }
        }

        public void Save()
        {
            repoUser.Save();
        }

        //public void Delete(int id)
        //{
        //    var collection = GetItems();
        //    var item = collection.Where();
        //    if (item != null)
        //    {
        //        repoUser.Remove(item);
        //    }
        //}

        public IEnumerable<UserDTO> Find(Func<UserDTO, bool> predicate)
        {
            var collection = GetItems();
            return collection.Where(predicate).ToList();
        }
    }
}
