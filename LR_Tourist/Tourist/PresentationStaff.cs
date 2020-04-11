using BLL.Model;
using BLL.Services;
using System.Collections.Generic;

namespace TouristConsole
{
    public class PresentationStaff
    {
        private readonly StaffService serviceStaff;

        public PresentationStaff(StaffService serviceStaff)
        {
            this.serviceStaff = serviceStaff;
        }

        public IEnumerable<StaffDTO> GetCollectionStaffs()
        {
            IEnumerable<StaffDTO> staffsDTO = serviceStaff.GetItems();
            return staffsDTO;
        }
        public StaffDTO GetUser(int? id)
        {
            return serviceStaff.GetItem(id);
        }
        public void CreateStaff(StaffDTO staffsDTO)
        {
            serviceStaff.Create(staffsDTO);
        }
        public void UpdateStaff(StaffDTO staffsDTO)
        {
            serviceStaff.Update(staffsDTO);
        }
        public void DeleteStaff(int id)
        {
            serviceStaff.Delete(id);
        }
    }
}
