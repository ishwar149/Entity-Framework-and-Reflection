using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess;
using BusinessObjects;
namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {
            Product p = new Product() { Price=17, AdditionalDetails="Aditional Details", Description="Description", Name="Name", ProductTypeID=2 };
            DataAccess.ProductDA.Add(p);
            List<Product> productTypes = DataAccess.ProductDA.GetAll();
        }
    }
}
