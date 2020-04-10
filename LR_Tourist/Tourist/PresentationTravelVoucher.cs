using BLL.Model;
using BLL.Services;
using BLL.ValidException;
using System.Collections.Generic;

namespace TouristConsole
{
    public class PresentationTravelVoucher
    {
        private readonly TravelVoucherService serviceTravelVoucher;
        private readonly UserService userService;

        public PresentationTravelVoucher(TravelVoucherService serviceTravelVoucher, UserService userService)
        {
            this.serviceTravelVoucher = serviceTravelVoucher;
            this.userService = userService;
        }

        public string MakeOrder(TravelVoucherDTO profileTravelVoucher, UserDTO profileUser)
        {
            try
            {
                serviceTravelVoucher.MakeOrder(profileTravelVoucher, profileUser);
                return "Успешно";
            }
            catch (ValidationException ex)
            {
                throw new ValidationException(ex.Property, ex.Message);
            }
        }

        public IEnumerable<TravelVoucherDTO> GetCollectionTravelVouchers()
        {
            IEnumerable<TravelVoucherDTO> travelVouchersDTO = serviceTravelVoucher.GetTravelVouchers();
            return travelVouchersDTO;
        }

        public TravelVoucherDTO GetTravelVouher(int? id)
        {
            return serviceTravelVoucher.GetTravelVoucher(id);
        }

        public string CreateTravelVoucher(TravelVoucherDTO profileTravelVoucher)
        {
            try
            {
                serviceTravelVoucher.Create(profileTravelVoucher);
                return "Успешно добваено";
            }
            catch (ValidationException ex)
            {
                throw new ValidationException(ex.Property, ex.Message);
            }
        }

        public string UpdateTravelVoucher(TravelVoucherDTO profileTravelVoucher)
        {
            try
            {
                serviceTravelVoucher.Update(profileTravelVoucher);
                return "Успешно обновлено";
            }
            catch (ValidationException ex)
            {
                throw new ValidationException(ex.Property, ex.Message);
            }
        }

        public string DeleteTravelVoucher(TravelVoucherDTO profileTravelVoucher)
        {
            try
            {
                serviceTravelVoucher.Delete(profileTravelVoucher);
                return "Успешно удалено";
            }
            catch (ValidationException ex)
            {
                throw new ValidationException(ex.Property, ex.Message);
            }
        }

    }
}