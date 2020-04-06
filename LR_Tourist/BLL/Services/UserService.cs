using AutoMapper;
using BLL.Interfaces;
using BLL.Model;
using BLL.ValidException;
using DA.Data;
using DA.Repository;
using System.Collections.Generic;

namespace BLL.Services
{
    public class UserService : IService<ProfileUser>, ICRUDService<User>
    {
        IRepository<User> repoUser { get; set; }

        UserService(IRepository<User> repositoryUser)
        {
            repoUser = repositoryUser;
        }

        ProfileUser IService<ProfileUser>.GetItem(int? id)
        {
            if (id == null)
                throw new ValidationException("Не установлено id пользователь ", "");
            var user = repoUser.Get(id.Value);
            if (user == null)
                throw new ValidationException("Пользователь не найден", "");

            return new ProfileUser
            {
                Id = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                MiddleName = user.MiddleName,
                Phone = user.Phone,
                Address = user.Address,
            };
        }

        IEnumerable<ProfileUser> IService<ProfileUser>.GetItems()
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<User, ProfileUser>()).CreateMapper();
            return mapper.Map<IEnumerable<User>, List<ProfileUser>>(repoUser.GetAll());
        }

        public void Create(User item)
        {
            if (item == null)
            {
                throw new ValidationException("Пустой объект ", "");
            }
            else
            {
                repoUser.Create(item);
                Save();
            }
        }

        public void Update(User item)
        {
            if (item == null)
            {
                throw new ValidationException("Пустой объект ", "");
            }
            else
            {
                repoUser.Update(item);
                Save();
            }
        }

        public void Delete(User item)
        {
            if (item == null)
            {
                throw new ValidationException("Пустой объект ", "");
            }
            else
            {
                repoUser.Delete(item);
                Save();
            }
        }

        public void Save()
        {
            repoUser.Save();
        }
    }
}
