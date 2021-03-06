﻿using System;
using System.Threading.Tasks;
using BLL.Model;
using BLL.Services;
using Microsoft.AspNetCore.Authorization;
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
        [Authorize(Roles = Constants.Admin)]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Staff/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = Constants.Admin)]
        public async Task<IActionResult> Create(IFormCollection collection)
        {
            try
            {
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
                _logger.LogInformation($"The {nameof(Staff)} creation was successful.");
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                _logger.LogError($"The {nameof(Staff)} creation failed.", ex);
                return View();
            }
        }

        // GET: Staff/Edit/5
        [Authorize(Roles = Constants.Admin)]
        public async Task<IActionResult> Edit(int id)
        {
            await _staffManagementService.GetItem(id);
            return View();
        }

        // POST: Staff/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = Constants.Admin)]
        public async Task<IActionResult> Edit(int id, IFormCollection collection)
        {
            try
            {
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
                _logger.LogInformation($"The {nameof(Staff)} editing was successful. Id = {id}.");
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                _logger.LogError($"The {nameof(Staff)} editing failed.", ex);
                return View();
            }
        }

        // GET: Staff/Delete/5
        [Authorize(Roles = Constants.Admin)]
        public async Task<IActionResult> Delete(int id)
        {
            await _staffManagementService.GetItem(id);
            return View();
        }

        // POST: Staff/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = Constants.Admin)]
        public async Task<IActionResult> DeleteById(int id)
        {
            try
            {
                await _staffManagementService.Delete(id);
                _logger.LogInformation($"The {nameof(Staff)} editing was successful. Id = {id}.");
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                _logger.LogError($"The {nameof(Staff)} deleting failed.", ex);
                return View();
            }
        }
    }
}