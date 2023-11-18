using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESCore.Model.Product
{
    [Table("CategoryProductMap")]
    public class CategoryProductMap : ESBase
    {
        [ForeignKey("FK_CategoryProductMap_Category_CategoryId")]
        [Column("CategoryId")]
        public int CategoryId { get; set; }
        [ForeignKey("FK_CategoryProductMap_Product_ProductId")]
        [Column("ProductId")]
        public int ProductId { get; set; }
        //public virtual Category Category { get; set; }
        //public virtual Product Product { get; set; }

    }
}
