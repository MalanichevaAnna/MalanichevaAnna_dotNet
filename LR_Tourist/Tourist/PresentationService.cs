using BLL.Model;
using BLL.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TouristConsole
{
    public class PresentationService
    {
        private readonly ServiceService service;

        public PresentationService(ServiceService service)
        {
            this.service = service;
        }

        public async Task<IEnumerable<Service>> GetCollectionServices()
        {
            IEnumerable<Service> servicesDTO = await service.GetItems();
            return servicesDTO;
        }
        public async Task<Service> GetService(int id)
        {
            return await service.GetItem(id);
        }
        public async void CreateService(Service serviceDTO)
        {
            await service.Create(serviceDTO);
        }
        public async void UpdateService(Service serviceDTO)
        {
            await service.Update(serviceDTO);
        }
        public async void DeleteService(int id)
        {
            await service.Delete(id);
        }
    }
}
