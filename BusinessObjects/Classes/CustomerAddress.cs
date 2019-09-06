using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObjects
{
    public class CustomerAddress : BaseBo
    {
        public int CustomerID { get; set; }
        public string House_Street { get; set; }
        public string Name { get; set; }
        public string PostCode { get; set; }
        public string City_Suburb { get; set; }
        public string MobileNumber { get; set; }
        public string State { get; set; }
        public Nullable<bool> IsShippingAddress { get; set; }
        public Nullable<bool> IsDefaultAddress { get; set; }
        public string DeliveryNotes { get; set; }
    }
}
