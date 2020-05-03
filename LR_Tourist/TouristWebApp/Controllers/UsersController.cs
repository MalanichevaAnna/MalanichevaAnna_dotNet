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
    public class UsersController : Controller
    {
        private readonly UserManagementService _userManagementService;

        private readonly ILogger<UsersController> _logger;

        public UsersController(ILogger<UsersController> logger,UserManagementService userManagementService)
        {
            _logger = logger;
            _userManagementService = userManagementService;
        }


        // GET: User
        public async Task<IActionResult> Index()
        {
            return View(await _userManagementService.GetItems());
        }

        // GET: User/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: User/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(IFormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here
                var user = new User
                {
                    Address = collection["Address"],
                    FirstName = collection["FirstName"],
                    LastName = collection["LastName"],
                    MiddleName = collection["MiddleName"],
                    Phone = collection["Phone"],
                };

                await _userManagementService.Create(user);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                _logger.LogInformation("User creation is not possible");
                return View();
            }
        }

        // GET: User/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            return View(await _userManagementService.GetItem(id));
        }

        // POST: User/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add update logic here
                var user = new User
                {
                    Id = id,
                    Address = collection["Address"],
                    FirstName = collection["FirstName"],
                    LastName = collection["LastName"],
                    MiddleName = collection["MiddleName"],
                    Phone = collection["Phone"],
                };

                await _userManagementService.Update(user);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                _logger.LogInformation("User edition is not possible");
                return View();
            }
        }

        // GET: User/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            return View(await _userManagementService.GetItem(id));
        }

        // POST: User/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteById(int id)
        {
            try
            {
                // TODO: Add delete logic here
                await _userManagementService.Delete(id);
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