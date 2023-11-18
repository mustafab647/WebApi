using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace WebApi.Models.ProductModels
{
    public class ProductModel
    {
        //[Required, MaxLength(50), MinLength(5)]
        public string Code { get; set; }
        //[Required, MaxLength(100), MinLength(10)]
        public string Name { get; set; }

        //[Required, MaxLength(int.MaxValue), MinLength(10)]
        public string Description { get; set; }
        //[Required]
        public decimal Price { get; set; }
        [Required]
        public decimal ListPrice { get; set; }
        //[Required, MinLength(3), MaxLength(3)]
        public string CurrencyCode { get; set; }
        //[Required]
        public bool IsValid { get; set; }

        //[Required, MinLength(1)]
        public int CategoryId { get; set; }

        public List<SpecificationModel>? Specifications { get; set; }
        public List<VariantModel>? Variants { get; set; }
    }
}
