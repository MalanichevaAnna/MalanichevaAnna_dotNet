using AutoMapper;
using BLL.Model;
using DA.Data;

namespace BLL
{
    class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<UserDTO, User>().ReverseMap();

            CreateMap<HotelDTO, Hotel>().ReverseMap();

            CreateMap<StaffDTO, Staff>().ReverseMap();

            CreateMap<ServicesDTO, DA.Data.Services>().ReverseMap();

            CreateMap<TravelVoucherDTO, TravelVoucher>().ReverseMap();
        }
    }
}
