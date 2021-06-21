using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DataLayer.Models
{
    public class Product
    {
        [Key]
        public int ProductId { get; set; }

        [Required, EnumDataType(typeof(ManufacturerType))]
        public ManufacturerType Manufacturer { get; set; }

        [Required]
        public string Model { get; set; }

        [Required]
        [DisplayName("Manufacturer's ID")]
        public string ManufacturersId { get; set; }

        [Required, EnumDataType(typeof(StoreName))]
        public StoreName Store { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        //[RegularExpression(@"^[1-9]\d{0,8}\.\d{1,2}$", ErrorMessage = "Enter price in the form: 123.95")]
        [RegularExpression(@"^[1-9]{1}[0-9]{0,3}(?:\.[0-9]{1,2})?$", ErrorMessage = "Enter price in the form: 123.95")]
        public decimal Price { get; set; }

        [Required,EnumDataType(typeof(Body))]
        [DisplayName("Body Type")]
        public Body BodyType { get; set; }

        [Required, EnumDataType(typeof(StringType))]
        [DisplayName("Number of strings")]
        public StringType StringNumber { get; set; }

       
        public bool IsLeftHanded { get; set; }
    }

    public enum ManufacturerType
    {
        Gibson=1,
        GibsonCustomShop,
        Fender,
        FenderCustomShop,
        Ibanez,
        Jackson,
        Charvel,
        Suhr,
        Tyler
    }

    public enum Body
    {
        Electric=1,
        Acoustic,
        SemiAcoustic
    }

    public enum StringType
    {
        Six = 6,
        Seven,
        Eight
    }

    public enum StoreName
    {
        Edinburgh=1,
        Glasgow,
        Newcastle,
        Birmingham,
        Epsom,
        Camden
    }
}
