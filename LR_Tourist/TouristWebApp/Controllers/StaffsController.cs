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
    public class StaffsController : Controller
    {
        private readonly StaffManagementService _staffManagementService;

        private readonly ILogger<StaffsController> _logger;

        public StaffsController(ILogger<StaffsController> logger,StaffManagementService staffManagementService)
        {
            _logger = logger;
            _staffManagementService = staffManagementService;
        }

        // GET: Staff
        public async Task<IActionResult> Index()
        {
            return View(await _staffManagementService.GetItems());
        }

        // GET: Staff/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Staff/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(IFormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here
                var staff = new Staff
                {
                    FirstName = collection["FirstName"],
                    LastName = collection["LastName"],
                    MiddleName = collection["MiddleName"],
                    PersonalNumber = collection["PersonalNumber"],
                    Phone = collection["Phone"],
                    Role = collection["Role"],
                    Salary = Convert.ToInt32(collection["Salary"]),
                };
                await _staffManagementService.Create(staff);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                _logger.LogInformation("User creation is not possible");
                return View();
            }
        }

        // GET: Staff/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            await _staffManagementService.GetItem(id);
            return View();
        }

        // POST: Staff/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add update logic here
                var staff = new Staff
                {
                    Id = id,
                    FirstName = collection["FirstName"],
                    LastName = collection["LastName"],
                    MiddleName = collection["MiddleName"],
                    PersonalNumber = collection["PersonalNumber"],
                    Phone = collection["Phone"],
                    Role = collection["Role"],
                    Salary = Convert.ToInt32(collection["Salary"]),
                };
                await _staffManagementService.Update(staff);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                _logger.LogInformation("User edition is not possible");
                return View();
            }
        }

        // GET: Staff/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            await _staffManagementService.GetItem(id);
            return View();
        }

        // POST: Staff/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteById(int id)
        {
            try
            {
                // TODO: Add delete logic here
                await _staffManagementService.Delete(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                _logger.LogInformation("deleting a user with id data is not possible");
                return View();
            }
        }
    }
}