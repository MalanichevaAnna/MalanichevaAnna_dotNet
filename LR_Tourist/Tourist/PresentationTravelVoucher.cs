using BLL.Model;
using BLL.Services;
using System.Collections.Generic;

namespace TouristConsole
{
    public class PresentationTravelVoucher
    {
        private readonly TravelVoucherService serviceTravelVoucher;
     
        public PresentationTravelVoucher(TravelVoucherService serviceTravelVoucher, UserService userService)
        {
            this.serviceTravelVoucher = serviceTravelVoucher;
        }

        public void MakeOrder(int idTravelVoucher, int idUser)
        {

            serviceTravelVoucher.MakeOrder(idTravelVoucher, idUser);
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

        public void CreateTravelVoucher(TravelVoucherDTO profileTravelVoucher)
        {
            serviceTravelVoucher.Create(profileTravelVoucher);
        }

        public void UpdateTravelVoucher(TravelVoucherDTO profileTravelVoucher)
        {
            serviceTravelVoucher.Update(profileTravelVoucher);
        }

        public void DeleteTravelVoucher(int id)
        {
            serviceTravelVoucher.Delete(id);
        }
    }
}