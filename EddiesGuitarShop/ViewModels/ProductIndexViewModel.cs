using DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataLayer.ViewModels
{
    public class ProductIndexViewModel
    {
        public IEnumerable<Product> Product { get; set; }
        public string ProductFilter { get; set; }
    }
}
