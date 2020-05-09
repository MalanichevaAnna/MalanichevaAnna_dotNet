using System;
using System.Threading.Tasks;
using BLL.Model;
using BLL.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace TouristWebApp.Controllers
{
    public class TravelVouchersController : Controller
    {
        private readonly TravelVoucherManagementService _travelVoucherManagementService;

        private readonly ILogger<TravelVouchersController> _logger;

        public TravelVouchersController(ILogger<TravelVouchersController> logger,TravelVoucherManagementService travelVoucherManagementService)
        {
            _logger = logger;
            _travelVoucherManagementService = travelVoucherManagementService;
        }

        // GET: TravelVoucher
        public async Task<IActionResult> Index()
        {
           
            return View(await _travelVoucherManagementService.GetItems());
        }

        // GET: TravelVoucher/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TravelVoucher/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(IFormCollection collection)
        {
            try
            {
                var travelVoucher = new TravelVoucher
                {
                    Departure = Convert.ToDateTime(collection["Departure"]),
                    Arrival = Convert.ToDateTime(collection["Arrival"]),
                    Country = collection["Country"],
                    HotelId = Convert.ToInt32(collection["HotelId"]),
                    Price = Convert.ToInt32(collection["Price"]),
                    ServicesId = Convert.ToInt32(collection["ServicesId"]),
                    StaffId = Convert.ToInt32(collection["StaffId"]),
                    UserId = Convert.ToInt32(collection["UserId"]),
                };
                await _travelVoucherManagementService.Create(travelVoucher);
                _logger.LogInformation($"The {nameof(TravelVoucher)} creation was successful.");
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                _logger.LogError($"The {nameof(TravelVoucher)} creation failed.", ex);
                return View();
            }
        }

        // GET: TravelVoucher/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            await _travelVoucherManagementService.GetItem(id);
            return View();
        }

        // POST: TravelVoucher/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, IFormCollection collection)
        {
            try
            {
                var travelVoucher = new TravelVoucher
                {
                    Id = id,
                    Departure = Convert.ToDateTime(collection["Departure"]),
                    Arrival = Convert.ToDateTime(collection["Arrival"]),
                    Country = collection["Country"],
                    HotelId = Convert.ToInt32(collection["HotelId"]),
                    Price = Convert.ToInt32(collection["Price"]),
                    ServicesId = Convert.ToInt32(collection["ServicesId"]),
                    StaffId = Convert.ToInt32(collection["StaffId"]),
                    UserId = Convert.ToInt32(collection["UserId"]),
                };
                await _travelVoucherManagementService.Update(travelVoucher);
                _logger.LogInformation($"The {nameof(TravelVoucher)} editing was successful. Id = {id}.");
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                _logger.LogError($"The {nameof(TravelVoucher)} editing failed.", ex);
                return View();
            }
        }

        // GET: TravelVoucher/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            await _travelVoucherManagementService.GetItem(id);
            return View();
        }

        // POST: TravelVoucher/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteById(int id)
        {
            try
            {
                await _travelVoucherManagementService.Delete(id);
                _logger.LogInformation($"The {nameof(TravelVoucher)} editing was successful. Id = {id}.");
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                _logger.LogError($"The {nameof(TravelVoucher)} deleting failed.", ex);
                return View();
            }
        }
    }
}