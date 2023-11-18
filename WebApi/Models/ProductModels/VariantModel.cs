using System.ComponentModel.DataAnnotations;

namespace WebApi.Models.ProductModels
{
    public class VariantModel
    {
        [Required, MaxLength(20), MinLength(1)]
        public string Name { get; set; }

        [Required, MinLength(1), MaxLength(50)]
        public string Barcode { get; set; }
        public int Quantity { get; set; }
        public List<VariantValue> VariantValues { get; set; }
        public decimal Price { get; set; }
        public decimal ListPrice { get; set; }
    }
}
