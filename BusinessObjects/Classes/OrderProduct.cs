using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObjects
{
   public class OrderProduct:BaseBo
    {
        public int ProductID { get; set; }
        public int ProductQuantity { get; set; }
        public int OrderID { get; set; }
    }
}
