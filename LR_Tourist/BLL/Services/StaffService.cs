using AutoMapper;
using BLL.Interfaces;
using BLL.Model;
using BLL.ValidException;
using DA.Data;
using DA.Services.Repository;
using System;
using System.Collections.Generic;

namespace BLL.Services
{
    public class StaffService: IService<StaffDTO>,ICRUDService<StaffDTO>
    {
        IRepository<Staff> repoStaff { get; set; }
        private readonly IMapper _mapper;
        public StaffService(IRepository<Staff> repositoryStaff,IMapper mapper)
        {
            repoStaff = repositoryStaff;
            _mapper = mapper;
        }

        public StaffDTO GetItem(int? id)
        {
            if (id == null)
                throw new ValidationException("Не установлено id пользователь ", "");
            var staff = repoStaff.Get(id.Value);
            if (staff == null)
                throw new ValidationException("Пользователь не найден", "");

            return new StaffDTO
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

        public IEnumerable<StaffDTO> GetItems()
        {
            
            return _mapper.Map<IEnumerable<Staff>, List<StaffDTO>>(repoStaff.GetAll());
        }
        public void Create(StaffDTO item)
        {
            if (item == null)
            {
                throw new ValidationException("Пустой объект ", "");
            }
            else
            {
                repoStaff.Create(_mapper.Map<Staff>(item));
                Save();
            }
        }

        public void Update(StaffDTO item)
        {
            if (item == null)
            {
                throw new ValidationException("Пустой объект ", "");
            }
            else
            {
                repoStaff.Update(_mapper.Map<Staff>(item));
                Save();
            }
        }

        public void Delete(StaffDTO item)
        {

            if (item == null)
            {
                throw new ValidationException("Пустой объект ", "");
            }
            else
            {
                repoStaff.Delete(_mapper.Map<Staff>(item));
                Save();
            }
        }
        public void Save()
        {
            repoStaff.Save();
        }
    }
}
