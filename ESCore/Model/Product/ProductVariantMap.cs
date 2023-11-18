using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESCore.Model.Product
{
    public class ProductVariantMap : ESBase
    {
        public int ProductId { get; set; }
        public int ProductVariantId { get; set; }
        public int VariantTypeId { get; set; }
        public int VariantTypeValueId { get; set; }
        public VariantType? VariantType { get; set; }
        public VariantTypeValue? VariantTypeValue { get; set; }
    }
}
