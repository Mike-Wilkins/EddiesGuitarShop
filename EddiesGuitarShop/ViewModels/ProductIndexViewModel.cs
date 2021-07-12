
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

        //[EnumDataType(typeof(FilterByBrandName))]
        //public FilterByBrandName FilterBrand { get; set; }

        public int FilterBrand { get; set; }


        public enum FilterProduct
        {
            [Display(Name = "Price: Low to High")]
            PriceLowToHigh = 1,
            [Display(Name = "Price: High to Low")]
            PriceHighToLow = 2
        }

        public enum FilterByBrandName
        {
            Gibson = 1,
            GibsonCustomShop,
            Fender,
            FenderCustomShop,
            Ibanez,
            Jackson,
            Charvel,
            Suhr,
            Tyler
        }
    }
}
