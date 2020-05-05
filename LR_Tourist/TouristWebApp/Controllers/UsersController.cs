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
                var user = new User
                {
                    Address = collection["Address"],
                    FirstName = collection["FirstName"],
                    LastName = collection["LastName"],
                    MiddleName = collection["MiddleName"],
                    Phone = collection["Phone"],
                };

                await _userManagementService.Create(user);
                _logger.LogInformation("Creation was successful");
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                _logger.LogError("User creation is not possible");
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
                _logger.LogInformation("Edition was successful");
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                _logger.LogError("User edition is not possible");
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
                await _userManagementService.Delete(id);
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