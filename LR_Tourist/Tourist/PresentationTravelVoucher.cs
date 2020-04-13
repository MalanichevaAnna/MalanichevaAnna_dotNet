using BLL.Model;
using BLL.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TouristConsole
{
    public class PresentationTravelVoucher
    {
        private readonly TravelVoucherService serviceTravelVoucher;
     
        public PresentationTravelVoucher(TravelVoucherService serviceTravelVoucher, UserService userService)
        {
            this.serviceTravelVoucher = serviceTravelVoucher;
        }

        public async void MakeOrder(int idTravelVoucher, int idUser)
        {
            await serviceTravelVoucher.MakeOrder(idTravelVoucher, idUser);
        }

        public async Task<IEnumerable<TravelVoucher>> GetCollectionTravelVouchers()
        {
            IEnumerable<TravelVoucher> travelVouchersDTO = await serviceTravelVoucher.GetTravelVouchers();
            return travelVouchersDTO;
        }

        public async Task<TravelVoucher> GetTravelVouher(int id)
        {
            return await serviceTravelVoucher.GetTravelVoucher(id);
        }

        public async void CreateTravelVoucher(TravelVoucher profileTravelVoucher)
        {
            await serviceTravelVoucher.Create(profileTravelVoucher);
        }

        public async void UpdateTravelVoucher(TravelVoucher profileTravelVoucher)
        {
            await serviceTravelVoucher.Update(profileTravelVoucher);
        }

        public async void DeleteTravelVoucher(int id)
        {
            await serviceTravelVoucher.Delete(id);
        }
    }
}