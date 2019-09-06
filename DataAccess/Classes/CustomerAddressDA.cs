using DataAccess.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessObjects;
namespace DataAccess
{
    public class CustomerAddressDA : BaseDA<CustomerAddress>
    {
        public static CustomerAddress GetCustomerAddress(int CustomerID)
        {
            return GetCustomQuery($"select * from CustomerAddress where CustomerID = {CustomerID}").FirstOrDefault();
        }
    }
}
