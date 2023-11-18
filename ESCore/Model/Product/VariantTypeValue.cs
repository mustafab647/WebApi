using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESCore.Model.Product
{
    public class VariantTypeValue : ESBase
    {
        public int VariantTypeId { get; set; }
        public VariantType VariantType { get; set; }
        public string VariantName { get; set; }
    }
}
