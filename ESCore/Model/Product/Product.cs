﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESCore.Model.Product
{
    [Table("Product")]
    public class Product : ESBase
    {
        [Column("Code")]
        [DataType(DataType.Text)]
        [MaxLength(50)]
        public string Code { get; set; }
        [DataType(DataType.Text)]
        [MaxLength(100), MinLength(5)]
        public string Name { get; set; }
        [DataType(DataType.MultilineText)]
        [StringLength(int.MaxValue,MinimumLength =10)]
        public string Description { get; set; }
        [DataType("decimal(20,2)")]
        public decimal Price { get; set; }
        [DataType("decimal(20,2)")]
        public decimal ListPrice { get; set; }
        [DataType(DataType.Currency)]
        public string CurrencyCode {  get; set; }
        [DataType("integer")]
        public int CurrencyId { get; set; }
        [DataType("boolean")]
        public bool IsValid { get; set; }
        [DataType("boolean")]
        public bool IsDeleted { get; set; }
        
        public List<ProductImage>? Images { get; set; }
        public virtual List<ProductVariant>? Variants { get; set; }
        public virtual Currency? Currency { get; set; }
        public virtual List<ProductSpecificationMap>? Specifications { get; set; }
        public virtual List<CategoryProductMap>? Categories { get; set; }

    }
}
