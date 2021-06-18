using DataLayer.Models;
using DataLayer.Repositories;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreMVC.Controllers
{
    public class ProductController : Controller
    {
        private IProductRepository _db;

        public ProductController(IProductRepository db)
        {
            _db = db;
        }
        public async Task<IActionResult> Index()
        {
            var productList = await _db.GetAllProducts();
            return View(productList);
        }

        //GET: Product/Create
        public IActionResult Create()
        {
            return View();
        }

        //POST: Product/Create
        [HttpPost]
        public async Task<IActionResult> Create(Product product)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            await _db.Add(product);
            var productList = await _db.GetAllProducts();
            return View("Index", productList);

        }

        //GET: Product/Delete
        public async Task<IActionResult> Delete(int id)
        {
            var product = await _db.GetProduct(id);
            return View(product);

        }

        //POST: Product/Delete
        [HttpPost]
        [ActionName("Delete")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            await _db.Delete(id);
            var productList = await _db.GetAllProducts();
            return View("Index",productList);
        }
    }
}
