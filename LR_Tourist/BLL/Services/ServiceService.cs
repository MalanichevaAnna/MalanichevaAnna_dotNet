
using System.Collections.Generic;
using AutoMapper;
using BLL.Interfaces;
using BLL.Model;
using BLL.ValidException;
using DA.Services.Repository;

namespace BLL.Services
{
    public class ServiceService : IService<ServicesDTO>, ICRUDService<ServicesDTO>
    {
        IRepository<DA.Data.Services> repoServices { get; set; }
        private readonly IMapper _mapper;
        public ServiceService(IRepository<DA.Data.Services> repositoryServices, IMapper mapper)
        {
            repoServices = repositoryServices;
            _mapper = mapper;
        }

        public ServicesDTO GetItem(int? id)
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

            return new ServicesDTO
            {
                Id = services.Id,
                NameServices = services.NameServices,
            };
        }

        public IEnumerable<ServicesDTO> GetItems()
        {
            return _mapper.Map<IEnumerable<DA.Data.Services>, List<ServicesDTO>>(repoServices.GetAll());
        }

        public void Create(ServicesDTO item)
        {

            if (item == null)
            {
                throw new ValidationException("Пустой объект ", "");
            }
            else
            {
                repoServices.Create(_mapper.Map<DA.Data.Services>(item));
                Save();
            }
        }

        public void Update(ServicesDTO item)
        {
            if (item == null)
            {
                throw new ValidationException("Пустой объект ", "");
            }
            else
            {
                repoServices.Update(_mapper.Map <DA.Data.Services>(item));
                Save();
            }
        }

        public void Delete(ServicesDTO item)
        {
            if (item == null)
            {
                throw new ValidationException("Пустой объект ", "");
            }
            else
            {
                repoServices.Delete(_mapper.Map<DA.Data.Services>(item));
                Save();
            }
        }

        public void Save()
        {
            repoServices.Save();
        }
    }
}
