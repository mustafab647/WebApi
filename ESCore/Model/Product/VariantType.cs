using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESCore.Model.Product
{
    public class VariantType:ESBase
    {
        public string Name { get; set; }

        public List<VariantTypeValue> Values { get; set; }
    }
}
