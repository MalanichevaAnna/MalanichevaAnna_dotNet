using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using BLL.Interfaces;
using BLL.Model;
using DA.Services.Repository;

namespace BLL.Services
{
    public class ServiceService : IService<Service>, ICRUDService<Service>
    {
        private readonly IRepository<DA.Data.ServiceDTO> repoServices;

        private readonly IMapper _mapper;
        public ServiceService(IRepository<DA.Data.ServiceDTO> repositoryServices, IMapper mapper)
        {
            repoServices = repositoryServices;
            _mapper = mapper;
        }

        public async Task<Service> GetItem(int id)
        {
            var services = await repoServices.Get(id);
            
            if (services == null)
            {
                throw new ArgumentNullException(nameof(services));
            }

            return new Service
            {
                Id = services.Id,
                NameServices = services.NameServices,
            };
        }

        public async Task<IEnumerable<Service>> GetItems()
        {
            return _mapper.Map<IEnumerable<DA.Data.ServiceDTO>, List<Service>>( await repoServices.GetAll());
        }

        public async Task Create(Service item)
        {

            if (item == null)
            {
                throw new ArgumentNullException(nameof(item));
            }
            else
            {
                await repoServices.Create(_mapper.Map<DA.Data.ServiceDTO>(item));
            }
        }

        public async Task Update(Service item)
        {
            if (item == null)
            {
                throw new ArgumentNullException(nameof(item));
            }
            else
            {
                await repoServices.Update(_mapper.Map <DA.Data.ServiceDTO>(item));
            }
        }

        public async Task Delete(int id)
        {
            var item = GetItems().Result.Where(el => el.Id == id).ToList();
            if (item == null)
            {
                throw new ArgumentNullException(nameof(item));
            }
            else
            {
                await repoServices.Delete(_mapper.Map<DA.Data.ServiceDTO>(item[0]).Id);
            }
        }
    }
}
