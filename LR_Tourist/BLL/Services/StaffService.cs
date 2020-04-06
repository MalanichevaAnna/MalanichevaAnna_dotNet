using AutoMapper;
using BLL.Interfaces;
using BLL.Model;
using BLL.ValidException;
using DA.Data;
using DA.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Services
{
    public class StaffService/*: IService<ProfileStaff>*/
    {
        //IRepository<ProfileStaff> repoStaff { get; set; }

        //StaffService(IRepository<ProfileStaff> repositoryStaff)
        //{
        //    repoStaff = repositoryStaff;
        //}

        //ProfileStaff IService<ProfileStaff>.GetItem(int? id)
        //{
        //    if (id == null)
        //        throw new ValidationException("Не установлено id пользователь ", "");
        //    var staff = repoStaff.Get(id.Value);
        //    if (staff == null)
        //        throw new ValidationException("Пользователь не найден", "");

        //    return new ProfileStaff
        //    {
        //        Id = staff.Id,
        //        FirstName = staff.FirstName,
        //        LastName = staff.LastName,
        //        MiddleName = staff.MiddleName,
        //        Phone = staff.Phone,
        //        Salary = staff.Salary,
        //        Role = staff.Role,
        //        PersonalNumber = staff.PersonalNumber,
        //    };
        //}

        //IEnumerable<ProfileStaff> IService<ProfileStaff>.GetItems()
        //{
        //    var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Staff, ProfileStaff>()).CreateMapper();
        //    return mapper.Map<IEnumerable<Staff>, List<ProfileStaff>>(repoStaff.GetAll());
        //}

        //public void Create(Staff item)
        //{
        //    if (item == null)
        //    {
        //        throw new ValidationException("Пустой объект ", "");
        //    }
        //    else
        //    {
        //        repoStaff.Create();
        //        Save();
        //    }
        //}

        //public void Update(Staff item)
        //{
        //    throw new NotImplementedException();
        //}

        //public void Delete(Staff item)
        //{
        //    throw new NotImplementedException();
        //}

        //public void Save()
        //{
        //    throw new NotImplementedException();
        //}
    }
}
