using AutoMapper;
using BLL.Model;
using DA.Data;

namespace BLL
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<User, UserDTO>().ReverseMap();

            CreateMap<Hotel, HotelDTO>().ReverseMap();

            CreateMap<Staff, StaffDTO>().ReverseMap();

            CreateMap<Service, ServiceDTO>().ReverseMap();

            CreateMap<TravelVoucher, TravelVoucherDTO>().ReverseMap();
        }
    }
}
