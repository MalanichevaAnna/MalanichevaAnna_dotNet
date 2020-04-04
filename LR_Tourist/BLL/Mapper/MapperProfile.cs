using AutoMapper;
using BLL.Model;
using DA.Data;

namespace BLL._1Новая_папка
{
    class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<ProfileUser, User>().ReverseMap();

            CreateMap<ProfileOrder, Order>().ReverseMap();
            
            CreateMap<ProfileHotel, Hotel>().ReverseMap();
            
            CreateMap<ProfileStaff, Staff>().ReverseMap();
            
            CreateMap<ProfileServices, DA.Data.Services>().ReverseMap();
            
            CreateMap<ProfileUser, TravelVoucher>().ReverseMap();
        }
    }
}
