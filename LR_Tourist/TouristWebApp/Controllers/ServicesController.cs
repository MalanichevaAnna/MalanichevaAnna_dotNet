using System;
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
                var service = new Service
                {
                    Name = collection["Name"],
                };
                await _serviceManagementService.Create(service);
                _logger.LogInformation($"The {nameof(Service)} creation was successful.");
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                _logger.LogError($"The {nameof(Service)} creation failed.", ex);
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
                var service = new Service
                {   Id = id,
                    Name = collection["Name"],
                };
                await _serviceManagementService.Update(service);
                _logger.LogInformation($"The {nameof(Service)} editing was successful. Id = {id}.");
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                _logger.LogError($"The {nameof(Service)} editing failed.", ex);
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
                await _serviceManagementService.Delete(id);
                _logger.LogInformation($"The {nameof(Service)} editing was successful. Id = {id}.");
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                _logger.LogError($"The {nameof(Service)} deleting failed.", ex);
                return View();
            }
        }
    }
}