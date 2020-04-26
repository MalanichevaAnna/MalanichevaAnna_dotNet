using AutoMapper;
using BLL.Interfaces;
using BLL.Model;
using DA.Data;
using DA.Services.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class StaffManagementService: IEntityManagementService<Staff>
    {
        private readonly IRepository<StaffDTO> repoStaff;

        private readonly IMapper _mapper;

        public StaffManagementService(IRepository<StaffDTO> repositoryStaff,IMapper mapper)
        {
            repoStaff = repositoryStaff;
            _mapper = mapper;
        }

        public async Task<Staff> GetItem(int id)
        {
            var staff = await repoStaff.Get(id);
            if (staff == null)
            {
                throw new ArgumentNullException(nameof(staff));
            }

            return new Staff
            {
                Id = staff.Id,
                FirstName = staff.FirstName,
                LastName = staff.LastName,
                MiddleName = staff.MiddleName,
                Phone = staff.Phone,
                Salary = staff.Salary,
                Role = staff.Role,
                PersonalNumber = staff.PersonalNumber,
            };
        }

        public async Task<IEnumerable<Staff>> GetItems()
        {
            return _mapper.Map<IEnumerable<StaffDTO>, List<Staff>>( await repoStaff.GetAll());
        }
        public async Task Create(Staff item)
        {
            if (item == null)
            {
                throw new ArgumentNullException(nameof(item));
            }
            else
            {
                await repoStaff.Create(_mapper.Map<StaffDTO>(item));
            }
        }

        public async Task Update(Staff item)
        {
            if (item == null)
            {
                throw new ArgumentNullException(nameof(item));
            }
            else
            {
                await repoStaff.Update(_mapper.Map<StaffDTO>(item));
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
               await repoStaff.Delete(_mapper.Map<StaffDTO>(item[0]).Id);
            }
        }
    }
}
