using BLL.Model;
using BLL.Services;
using System.Collections.Generic;

namespace TouristConsole
{
    public class PresentationService
    {
        private readonly ServiceService service;

        public PresentationService(ServiceService service)
        {
            this.service = service;
        }

        public IEnumerable<ServicesDTO> GetCollectionServices()
        {
            IEnumerable<ServicesDTO> servicesDTO = service.GetItems();
            return servicesDTO;
        }
        public ServicesDTO GetService(int? id)
        {
            return service.GetItem(id);
        }
        public void CreateService(ServicesDTO serviceDTO)
        {
            service.Create(serviceDTO);
        }
        public void UpdateService(ServicesDTO serviceDTO)
        {
            service.Update(serviceDTO);
        }
        public void DeleteService(int id)
        {

            service.Delete(id);
        }
    }
}
