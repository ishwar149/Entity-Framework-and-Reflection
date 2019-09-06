using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObjects
{
    public class ProductInventory : BaseBo
    {

        public string Name { get; set; }
        public int ProductID { get; set; }
        public int Quantity { get; set; }
    }
}
