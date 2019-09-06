using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace BusinessObjects
{
    public class Product : BaseBo
    {
        public string Name { get; set; }
        public double Price { get; set; }
        public string Description { get; set; }
        public string AdditionalDetails { get; set; }
        public int ProductTypeID { get; set; }
        public string MainImageURL { get; set; }

        public List<Image> Images { get; set; }

        public int quantity { get; set; }

    }
}
