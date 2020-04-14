using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using BLL.Interfaces;
using BLL.Model;
using DA.Data;
using DA.Services.Repository;

namespace BLL.Services
{
    public class ServiceManagementService : IService<Service>, IEntityManagementService<Service>
    {
        private readonly IRepository<ServiceDTO> repoServices;

        private readonly IMapper _mapper;
        public ServiceManagementService(IRepository<ServiceDTO> repositoryServices, IMapper mapper)
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
                Name = services.Name,
            };
        }

        public async Task<IEnumerable<Service>> GetItems()
        {
            return _mapper.Map<IEnumerable<ServiceDTO>, List<Service>>( await repoServices.GetAll());
        }

        public async Task Create(Service item)
        {
            if (item == null)
            {
                throw new ArgumentNullException(nameof(item));
            }
            else
            {
                await repoServices.Create(_mapper.Map<ServiceDTO>(item));
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
                await repoServices.Update(_mapper.Map <ServiceDTO>(item));
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
                await repoServices.Delete(_mapper.Map<ServiceDTO>(item[0]).Id);
            }
        }
    }
}
