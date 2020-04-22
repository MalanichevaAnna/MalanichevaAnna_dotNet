using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DA;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace TouristWebApp.Controllers
{
    public class HotelController : Controller
    {
        Context db;

        public HotelController(Context context)
        {
            db = context;
        }
        // GET: Hotel
        public ActionResult Index()
        {
            return View(db.Hotels.ToList());
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
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Hotel/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Hotel/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Hotel/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Hotel/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}