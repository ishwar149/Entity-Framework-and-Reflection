using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessObjects;
namespace DataAccess
{
    //This class implements all the functions of BaseClass with reflection so we do not need to write those functions
    public class ProductDA : BaseDA<Product>
    {
        // Get Prooducts by their Type
        public static List<Product> GetAllByType(int ID)
        {
            //Create a query String
            string Query = $"Select * from Product Where ProductTypeID ={ID}";
            //Call custom query function and Return the results
            return GetCustomQuery(Query);
        }

        //Get Cheap Product for the selected Type
        public static Product GetCheapProductbyType(int ID)
        {
            //Create a query String
            string Query = $"select top(1) * from Product where ProductTypeID ={ID} ORDER BY Price";
            //Call custom query function and Return the results
            return GetCustomQuery(Query).FirstOrDefault();
        }

        //Get Recommended Products
        public static List<Product> GetRecommended(List<int> IDs)
        {
            //Create a query String
            string Query = $"Select * from Product Where ID IN({string.Join(",", IDs.Select(n => n.ToString()).ToArray())})";
            //Call custom query function and Return the results
            return GetCustomQuery(Query);
        }
    }
}
