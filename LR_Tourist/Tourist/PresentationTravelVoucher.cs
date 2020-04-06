using BLL.Interfaces;
using BLL.Model;
using BLL.ValidException;
using System.Collections.Generic;

namespace TouristConsole
{
    class PresentationTravelVoucher
    {
     
        public string MakeOrder(ITravelVoucher serviceTravelVoucher, ProfileTravelVoucher profileTravelVoucher, ProfileUser profileUser)
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

        public IEnumerable<ProfileTravelVoucher> GetCollectionTravelVouchers(ITravelVoucher travelVoucherService)
        {
            IEnumerable<ProfileTravelVoucher> travelVouchersDTO = travelVoucherService.GetTravelVouchers();
            return travelVouchersDTO;
        }

        public ProfileTravelVoucher GetTravelVouher(ITravelVoucher travelVoucherService, int? id)
        {
            return travelVoucherService.GetTravelVoucher(id);
        }

        public string CreateTravelVoucher(ICRUDService<ProfileTravelVoucher> serviceTravelVoucher, ProfileTravelVoucher profileTravelVoucher)
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

        public string UpdateTravelVoucher(ICRUDService<ProfileTravelVoucher> serviceTravelVoucher, ProfileTravelVoucher profileTravelVoucher)
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

        public string DeleteTravelVoucher(ICRUDService<ProfileTravelVoucher> serviceTravelVoucher, ProfileTravelVoucher profileTravelVoucher)
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