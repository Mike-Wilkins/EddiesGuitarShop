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
        public string Description { get; set; }

        [Required]
        public double Price { get; set; }

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
        Gibson,
        Fender,
        Ibanez,
        Jackson,
        Charvel,
        Suhr
    }

    public enum Body
    {
        Electric,
        Acoustic,
        SemiAcoustic
    }

    public enum StringType
    {
        Six,
        Seven,
        Eight
    }
}
