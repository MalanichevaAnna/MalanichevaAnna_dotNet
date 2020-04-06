
using System.Collections.Generic;
using AutoMapper;
using BLL.Interfaces;
using BLL.Model;
using BLL.ValidException;
using DA.Data;
using DA.Repository;

namespace BLL.Services
{
    public class ServiceService : IService<ProfileServices>, ICRUDService<DA.Data.Services>
    {
        IRepository<DA.Data.Services> repoServices { get; set; }

        ServiceService(IRepository<DA.Data.Services> repositoryServices)
        {
            repoServices = repositoryServices;
        }

        public ProfileServices GetItem(int? id)
        {
            if (id == null)
            {
                throw new ValidationException("Не установлено id услуг ", "");
            }

            var services = repoServices.Get(id.Value);
            
            if (services == null)
            {
                throw new ValidationException("Услуга не найден", "");
            }

            return new ProfileServices
            {
                Id = services.Id,
                NameServices = services.NameServices,
            };
        }

        public IEnumerable<ProfileServices> GetItems()
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<DA.Data.Services, ProfileServices>()).CreateMapper();
            return mapper.Map<IEnumerable<DA.Data.Services>, List<ProfileServices>>(repoServices.GetAll());
        }

        public void Create(DA.Data.Services item)
        {

            if (item == null)
            {
                throw new ValidationException("Пустой объект ", "");
            }
            else
            {
                repoServices.Create(item);
                Save();
            }
        }

        public void Update(DA.Data.Services item)
        {
            if (item == null)
            {
                throw new ValidationException("Пустой объект ", "");
            }
            else
            {
                repoServices.Update(item);
                Save();
            }
        }

        public void Delete(DA.Data.Services item)
        {
            if (item == null)
            {
                throw new ValidationException("Пустой объект ", "");
            }
            else
            {
                repoServices.Delete(item);
                Save();
            }
        }

        public void Save()
        {
            repoServices.Save();
        }
    }
}
