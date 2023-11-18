using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESCore.Model.Product
{
    public class ProductSpecificationMap :ESBase
    {
        [ForeignKey("FK_ProductSpecificationMap_Specification_SpecificationId")]
        public int SpecificationId { get; set; }
        //public Specification Specification { get; set; }
        [ForeignKey("FK_ProductSpecificationMap_Product_ProductId")]
        public int ProductId { get; set; }
        //public Product Product { get; set; }
    }
}
