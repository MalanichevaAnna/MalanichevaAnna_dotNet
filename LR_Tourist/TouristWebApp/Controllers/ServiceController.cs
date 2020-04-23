using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BLL.Model;
using BLL.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace TouristWebApp.Controllers
{
    public class ServiceController : Controller
    {
        private readonly ServiceManagementService _serviceManagementService;

        public ServiceController(ServiceManagementService serviceManagementService)
        {
            _serviceManagementService = serviceManagementService;
        }

        // GET: Service
        public async Task<IActionResult> Index()
        {
            return View(await _serviceManagementService.GetItems());
        }

        // GET: Service/Details/5
        public ActionResult Details(int id)
        {
            return View();
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
        public async Task<ActionResult> Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                await _serviceManagementService.Delete(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}