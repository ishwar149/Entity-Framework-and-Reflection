using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObjects
{
    public class CustomerProfile : BaseBo
    {
        public string Name { get; set; }
        public string LoginUserID { get; set; }
        public string UserContact { get; set; }
    }
}
