
using DataLayer.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DataLayer.ViewModels
{
    public class ProductIndexViewModel
    {
        public IEnumerable<Product> Product { get; set; }

        [EnumDataType(typeof(FilterProduct))]
        public FilterProduct FilterType { get; set; }

        public ManufacturerType FilterBrand { get; set; }

        public enum FilterProduct
        {
            [Display(Name = "Price: Low to High")]
            PriceLowToHigh = 1,
            [Display(Name = "Price: High to Low")]
            PriceHighToLow = 2
        }

    }
}
