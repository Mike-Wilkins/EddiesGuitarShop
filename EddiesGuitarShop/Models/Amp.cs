using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DataLayer.Models
{
    public class Amp
    {
        [Key]
        public int ProductId { get; set; }

        public string Category { get; set; } = "Amp";

        [Required, EnumDataType(typeof(AmpManufacturerType))]
        public AmpManufacturerType Manufacturer { get; set; }

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
        [RegularExpression(@"^[1-9]{1}[0-9]{0,3}(?:\.[0-9]{1,2})?$", ErrorMessage = "Enter price in the form: 123.95")]
        public decimal Price { get; set; }

        [Required, EnumDataType(typeof(SubCategory))]
        [DisplayName("Sub Category")]
        public SubCategory BodyType { get; set; }
    }

    public enum AmpManufacturerType
    {
        Marshall = 1,
        MasaBoogie,
        Soldano,
        Bogner,
        Friedman,
        Suhr
    }

    public enum SubCategory
    {
        Valve = 1,
        Cabinet,
        PracticeAmp,
        SolidStateAmp
    }
}
