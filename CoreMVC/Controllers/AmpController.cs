using DataLayer.Models;
using DataLayer.Repositories;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreMVC.Controllers
{
    public class AmpController : Controller
    {
        private IAmpRepository _db;

        public AmpController(IAmpRepository db)
        {
            _db = db;
        }

        public async Task<IActionResult> Index()
        {
            var productList = await _db.GetAllProducts();

            return View(productList);
        }

        //GET: Amp/Create
        public IActionResult Create()
        {
            return View();
        }

        //POST: Amp/Create
        [HttpPost]
        public async Task<IActionResult> Create(Amp amp)
        {
            if (!ModelState.IsValid)
            {
                return View(amp);
            }
            await _db.Add(amp);
            var productList = await _db.GetAllProducts();
            return View("Index",productList);
        }

        //GET: Amp/Delete
        public async Task<IActionResult> Delete(int id)
        {
            var amp = await _db.GetProduct(id);
            return View(amp);
        }

        //POST: Amp/Delete
        [HttpPost]
        [ActionName("Delete")]
        public async Task<IActionResult> DeleteAmp(int id)
        {
            await _db.Delete(id);
            var productList = await _db.GetAllProducts();
            return View("Index", productList);
        }

        //GET: Amp/Edit
        public async Task<IActionResult> Edit(int id)
        {
            var amp = await _db.GetProduct(id);
            return View(amp);
        }

        //POST: Amp/Edit
        [HttpPost]
        public async Task<IActionResult> Edit(Amp amp)
        {
            _db.Update(amp);
            var productList = await _db.GetAllProducts();
            return View("Index", productList);
        }

        //GET: amp/Details
        public async Task<IActionResult> Details(int id)
        {
            var amp = await _db.GetProduct(id);
            return View(amp);
        }

    }
}
