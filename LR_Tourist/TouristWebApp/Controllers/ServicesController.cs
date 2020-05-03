using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BLL.Model;
using BLL.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace TouristWebApp.Controllers
{
    public class ServicesController : Controller
    {
        private readonly ServiceManagementService _serviceManagementService;

        private readonly ILogger<ServicesController> _logger;

        public ServicesController(ILogger<ServicesController> logger,ServiceManagementService serviceManagementService)
        {
            _logger = logger;
            _serviceManagementService = serviceManagementService;
        }

        // GET: Service
        public async Task<IActionResult> Index()
        {
            return View(await _serviceManagementService.GetItems());
        }

        // GET: Service/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Service/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(IFormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here
                var service = new Service
                {
                    Name = collection["Name"],
                };
                await _serviceManagementService.Create(service);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                _logger.LogDebug("User creation is not possible");
                return View();
            }
        }

        // GET: Service/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            await _serviceManagementService.GetItem(id);
            return View();
        }

        // POST: Service/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add update logic here
                var service = new Service
                {   Id = id,
                    Name = collection["Name"],
                };
                await _serviceManagementService.Update(service);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                _logger.LogDebug("User edition is not possible");
                return View();
            }
        }

        // GET: Service/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            await _serviceManagementService.GetItem(id);
            return View();
        }

        // POST: Service/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteById(int id)
        {
            try
            {
                // TODO: Add delete logic here
                await _serviceManagementService.Delete(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                _logger.LogDebug("deleting a user with id data is not possible");
                return View();
            }
        }
    }
}