using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ESCore.Model.Product
{
    public class ProductVariant : ESBase
    {
        //[ForeignKey("VariantTypeId")]
        public int? VariantTypeId { get; set; }
        public string Name { get; set; }
        public string Barcode { get; set; }
        public int Quantity { get; set; }
        public int UnitPrice { get; set; }

        //[ForeignKey("FK_ProductVariant_Product_ProductId")]
        public int ProductId { get; set; }
        public virtual VariantType? Type { get; set; }

        public virtual ICollection<ProductVariantMap>? VariantMap { get; set; }
        [JsonIgnore]
        public virtual Product Product { get; set; }
    }
}
