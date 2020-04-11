
using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using BLL.Interfaces;
using BLL.Model;
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
                throw new ArgumentException("Check id");
            }

            var services = repoServices.Get(id.Value);
            
            if (services == null)
            {
                throw new ArgumentNullException(nameof(services));
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
                throw new ArgumentNullException(nameof(item));
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
                throw new ArgumentNullException(nameof(item));
            }
            else
            {
                repoServices.Update(_mapper.Map <DA.Data.Services>(item));
                Save();
            }
        }


        public void Delete(int id)
        {
            var item = GetItems().Where(el => el.Id == id).ToList();
            if (item == null)
            {
                throw new ArgumentNullException(nameof(item));
            }
            else
            {
                repoServices.Delete(_mapper.Map<DA.Data.Services>(item[0]).Id);
                Save();
            }
        }
        public void Save()
        {
            repoServices.Save();
        }
    }
}
