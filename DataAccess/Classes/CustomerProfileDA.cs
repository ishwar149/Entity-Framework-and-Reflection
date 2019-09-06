using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessObjects;
namespace DataAccess
{
    public class CustomerProfileDA : BaseDA<CustomerProfile>
    {
        public static CustomerProfile GetByUser(string UserContact)
        {
            return GetCustomQuery($"Select * From CustomerProfile where UserContact = '{UserContact}'").FirstOrDefault();
        }
    }
}
