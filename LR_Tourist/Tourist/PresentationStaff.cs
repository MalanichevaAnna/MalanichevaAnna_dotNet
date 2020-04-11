using BLL.Model;
using BLL.Services;
using BLL.ValidException;
using System;
using System.Collections.Generic;
using System.Text;

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
        public string CreateStaff(StaffDTO staffsDTO)
        {
            try
            {
                serviceStaff.Create(staffsDTO);
                return "Успешно добваено";
            }
            catch (ValidationException ex)
            {
                throw new ValidationException(ex.Property, ex.Message);
            }
        }
        public string UpdateStaff(StaffDTO staffsDTO)
        {
            try
            {
                serviceStaff.Update(staffsDTO);
                return "Успешно добваено";
            }
            catch (ValidationException ex)
            {
                throw new ValidationException(ex.Property, ex.Message);
            }
        }
        public string DeleteStaff(int id)
        {
            try
            {
                serviceStaff.Delete(id);
                return "Успешно добваено";
            }
            catch (ValidationException ex)
            {
                throw new ValidationException(ex.Property, ex.Message);
            }
        }
    }
}
