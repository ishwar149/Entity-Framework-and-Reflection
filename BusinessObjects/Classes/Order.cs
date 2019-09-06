using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObjects
{
   public class Order :BaseBo
    {
        public int CustomerID { get; set; }
        public DateTime OrderDateTime { get; set; }
        public double OrderPrice { get; set; }
        public double DeliveryPrice { get; set; }
        public double TotalPrice { get; set; }
        public Nullable<bool> IsDelivered { get; set; }
        public Nullable<DateTime> DeliveryDateTime { get; set; }
        public Nullable<bool> IsOrderPlaced { get; set; }
        public string TransactionReference { get; set; }

    }
}
