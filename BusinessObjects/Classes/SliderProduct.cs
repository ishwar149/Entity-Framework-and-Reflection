using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObjects
{
    public class SliderProduct : BaseBo
    {
        public int ProductID { get; set; }
        public double Price { get; set; }
        public double SalePrice { get; set; }
        public Nullable<System.DateTime> OfferTill { get; set; }
        public Nullable<int> DiscountPercentage { get; set; }


        public string SaleInfoLine { get; set; }
        public Product Product { get; set; }


    }
}
