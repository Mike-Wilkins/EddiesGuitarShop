using DataLayer.Models;
using DataLayer.Repositories;
using DataLayer.ViewModels;
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
        public async Task<IActionResult> Index(ProductIndexViewModel filterProduct)
        {

            ProductIndexViewModel productIndexViewModel = new ProductIndexViewModel()
            {
                Product = await _db.GetAllProducts(filterProduct),          
            };

            return View(productIndexViewModel);
        }

        //GET: Product/Create
        public IActionResult Create()
        {
            return View();
        }

        //POST: Product/Create
        [HttpPost]
        public async Task<IActionResult> Create(Product product, ProductIndexViewModel filterProduct)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            await _db.Add(product);
            var productList = await _db.GetAllProducts(filterProduct);
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
        public async Task<IActionResult> DeleteProduct(int id, ProductIndexViewModel filterProduct)
        {
            await _db.Delete(id);
            var productList = await _db.GetAllProducts(filterProduct);
            return View("Index",productList);
        }
        //GET: Product/Edit
        public async Task<IActionResult> Edit(int id)
        {
            var product = await _db.GetProduct(id);
            return View(product);
        }

        //POST: Product/Edit
        [HttpPost]
        public async Task<IActionResult> Edit(Product product, ProductIndexViewModel filterProduct)
        {
            _db.Update(product);
            var productList = await _db.GetAllProducts(filterProduct);
            return View("Index", productList);
        }

        //GET: Product/Details
        public async Task<IActionResult> Details(int id)
        {
            var product = await _db.GetProduct(id);
            return View(product);
        }
    }
}
