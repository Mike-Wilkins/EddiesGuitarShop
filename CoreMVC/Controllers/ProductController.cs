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
    }
}
