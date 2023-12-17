using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESCore.Model.Product
{
    public class Specification:ESBase
    {
        public int SpecificationTypeId { get; set; }
        [DataType(DataType.Text)]
        public string Name { get; set; }
        [DataType(DataType.Text)]
        public string Value { get; set; }

        public virtual ICollection<ProductSpecificationMap> SpecificationMap { get; set; }
    }
}
