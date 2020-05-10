using System;
using System.Threading.Tasks;
using BLL.Model;
using BLL.Services;
using Microsoft.AspNetCore.Authorization;
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
       // [Authorize(Roles = "admin")]
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
                _logger.LogInformation($"The {nameof(User)} creation was successful.");
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                _logger.LogError($"The {nameof(User)} creation failed.", ex);
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
                _logger.LogInformation($"The {nameof(User)} editing was successful. Id = {id}.");
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                _logger.LogError($"The {nameof(User)} editing failed.", ex);
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
                _logger.LogInformation($"The {nameof(User)} editing was successful. Id = {id}.");
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                _logger.LogError($"The {nameof(User)} deleting failed.", ex);
                return View();
            }
        }
    }
}