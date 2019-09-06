using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObjects
{
    public class Image
    {
        public int ID { get; set; }
        public string ImageURL { get; set; }
        public int ProductID { get; set; }
        public Nullable<bool> IsMainImage { get; set; }
    }
}
