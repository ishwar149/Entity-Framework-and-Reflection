using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    /* This class is Common to implement CRUD operations for each class in the Dataaccess */
    public class BaseDA<T> where T : class
    {

        #region Global Variables
        // Create new Instance of Entity Framework to query data
        public static Linq.GroceryDB database = new Linq.GroceryDB();

        #endregion

        // This function is to add item in the database 
        #region Insert
        public static T Add(T item)
        {
            try
            {
                //Get the name of the Table to to save item
                var dbentity = database.Set(item.GetType());
                //Add item
                dbentity.Add(item);
                //Update the Changes in the Database
                database.SaveChanges();
                //Return item with newly generated ID for further working if needed
                return item;
            }
            catch (Exception e)
            {
                //TO save the error in the Log we can use this message
                string error = e.Message;
                return null;
            }
        }
        #endregion

        //These functions are to retrive the items from the Database
        #region Get
        //This function returns all items in the given dataset
        public static List<T> GetAll() => (database.Set<T>().ToList());

        //This Function gets an Input Int ID and returns the Specific Record for that ID
        public static T GetSingle(int ID) => (database.Set<T>().Find(ID));

        #endregion

        //This is to update an Item in the Database
        #region Update
        //This function takes two inputs ID and Item. There are more than tow lines to read an ID of Item T so we are 
        //Sending the int Id variable with every call
        public static void Update(int Id, T item)
        {
            //Gets the Dataset of items from EF or we can say Gets the Table from database in which we need to update the Item
            var dbentity = database.Set(item.GetType());
            //Gets the item from database which needs to be updated
            var entity = dbentity.Find(Id);
            //If Item is not present then it returns 
            if (entity == null)
            {
                return;
            }
            //Updates the Item Values
            database.Entry(entity).CurrentValues.SetValues(item);
            //Saves the Changes in the dataset
            database.SaveChanges();
        }

        #endregion

        //This function is to delete items from the database
        #region Delete
        public static void Delete(int Id)
        {
            //Get the dataset from which we need to delete an item
            var dbentity = database.Set<T>();
            //Find the item or get the item
            var entity = dbentity.Find(Id);
            //remove item from the dataset
            dbentity.Remove(entity);
            //Update the dataset
            database.SaveChanges();
        }

        #endregion

        //This function is to run custom queries to retrive data 
        //As we know that we need to use different variables to filter data this function works there
        #region Custom Query
        public static List<T> GetCustomQuery(string Query)
        {
            //Run custom query and return a list of objects
            return database.Set<T>().SqlQuery(Query).ToList();
        }
        #endregion

    }
}
