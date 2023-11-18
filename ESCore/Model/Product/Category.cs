using Microsoft.EntityFrameworkCore.Infrastructure;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESCore.Model.Product
{
    [Table("Category")]
    public class Category: ESBase
    {
        [Column("Name")]
        [DataType(DataType.Text)]
        public string Name { get; set; }
        [Column("IsValid")]
        [DataType("boolean")]
        public bool IsValid { get; set; }
        [Column("IsDeleted")]
        [DataType("boolean")]
        public bool IsDeleted { get; set; }
        [Column("CategoryId")]
        public int? CategoryId { get; set; }
        public virtual Category? ParentCategory { protected get; set; }
        public virtual ICollection<Category>? ChildCategories { get; set; }
    }
}
