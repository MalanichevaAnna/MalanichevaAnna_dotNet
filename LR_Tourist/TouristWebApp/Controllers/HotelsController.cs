using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BLL.Model;
using BLL.Services;
using DA;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace TouristWebApp.Controllers
{
    public class HotelsController : Controller
    {
        private readonly HotelManagementService _hotelManagementService;

        private readonly ILogger<HotelsController> _logger;

        public HotelsController(ILogger<HotelsController> logger,HotelManagementService hotelManagementService)
        {
            _logger = logger;
            _hotelManagementService = hotelManagementService;
        }
        // GET: Hotel
        public async Task<IActionResult> Index()
        {
            return View(await _hotelManagementService.GetItems());
        }
        // GET: Hotel/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Hotel/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(IFormCollection collection)
        {
            try
            {
                var hotel = new Hotel
                {
                    Name = collection["Name"],
                    Phone = collection["Phone"],
                    Star = Convert.ToInt32(collection["Star"]),
                };
                await _hotelManagementService.Create(hotel);
                _logger.LogInformation("Creation was successful");
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                _logger.LogError("User creation is not possible");
                return View();
            }
        }

        // GET: Hotel/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            await _hotelManagementService.GetItem(id);
            return View();
        }

        // POST: Hotel/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, IFormCollection collection)
        {
            try
            {
                var hotel = new Hotel
                {   
                    Id = id,
                    Name = collection["Name"],
                    Phone = collection["Phone"],
                    Star = Convert.ToInt32(collection["Star"]),
                };
                await _hotelManagementService.Update(hotel);
                _logger.LogInformation("Edition was successful");
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                _logger.LogError("User edition is not possible");
                return View();
            }
        }

        public async Task<IActionResult> Delete(int id)
        {
            await _hotelManagementService.GetItem(id);
            return View();
        }

        // POST: Hotel/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteById(int id)
        {
            try
            {
                await _hotelManagementService.Delete(id);
                _logger.LogInformation("Deletion was successful");
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                _logger.LogError("deleting a user with id data is not possible");
                return View();
            }
        }
    }
}