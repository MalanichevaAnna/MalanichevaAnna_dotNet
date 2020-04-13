using BLL.Model;
using BLL.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TouristConsole
{
    public class PresentationStaff
    {
        private readonly StaffService serviceStaff;

        public PresentationStaff(StaffService serviceStaff)
        {
            this.serviceStaff = serviceStaff;
        }

        public async Task<IEnumerable<Staff>> GetCollectionStaffs()
        {
            IEnumerable<Staff> staffsDTO = await serviceStaff.GetItems();
            return staffsDTO;
        }
        public async Task<Staff> GetUser(int id)
        {
            return await serviceStaff.GetItem(id);
        }
        public async void CreateStaff(Staff staffsDTO)
        {
            await serviceStaff.Create(staffsDTO);
        }
        public async void UpdateStaff(Staff staffsDTO)
        {
            await serviceStaff.Update(staffsDTO);
        }
        public async void DeleteStaff(int id)
        {
            await serviceStaff.Delete(id);
        }
    }
}
