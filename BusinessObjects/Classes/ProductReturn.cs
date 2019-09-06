using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObjects
{
    public class ProductReturn : BaseBo
    {
        public int OrderProductID { get; set; }
        public string ReturnReason { get; set; }
        public Nullable<bool> IsRefunded { get; set; }
        public Nullable<DateTime> ReturnDateTime { get; set; }
        public Nullable<double> Amount { get; set; }
        public string TransactionReference { get; set; }
        public Nullable<DateTime> RefundDateTime { get; set; }
    }
}
