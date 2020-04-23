﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BLL.Model;
using BLL.Services;
using DA;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace TouristWebApp.Controllers
{
    public class HotelController : Controller
    {
        private readonly HotelManagementService _hotelManagementService;
        public HotelController(HotelManagementService hotelManagementService)
        {
            _hotelManagementService = hotelManagementService;
        }
        // GET: Hotel
        public async Task<IActionResult> Index()
        {
            return View(await _hotelManagementService.GetItems());
        }

        // GET: Hotel/Details/5
        public ActionResult Details(int id)
        {
            return View();
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
                // TODO: Add insert logic here
                var hotel = new Hotel
                {
                    Name = collection["Name"],
                    Phone = collection["Phone"],
                    Star = Convert.ToInt32(collection["Star"]),
                };
                await _hotelManagementService.Create(hotel);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
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
                // TODO: Add update logic here
                var hotel = new Hotel
                {   
                    Id = id,
                    Name = collection["Name"],
                    Phone = collection["Phone"],
                    Star = Convert.ToInt32(collection["Star"]),
                };
                await _hotelManagementService.Update(hotel);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Hotel/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            await _hotelManagementService.GetItem(id);
            return View();
        }

        // POST: Hotel/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                await _hotelManagementService.Delete(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}