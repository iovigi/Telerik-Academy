using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework
{
    public class DAO
    {
        public static void ManipulateDatabase()
        {
            using (NorthwindEntities context = new NorthwindEntities())
            {
                InsertNewCustomersToDb(context);
                ModifyNewInsertedCustomer(context);
                DeleteNewInsertedCustomer(context);
            }
        }

        private static void DeleteNewInsertedCustomer(NorthwindEntities context)
        {
            var customer = context.Customers.First();
            context.Customers.Remove(customer);
            context.SaveChanges();
        }

        private static void ModifyNewInsertedCustomer(NorthwindEntities context)
        {
            var customer = context.Customers.First();
            customer.City = "Sofia";
            customer.Region = "Sofia";
            context.SaveChanges();
        }

        private static void InsertNewCustomersToDb(NorthwindEntities context)
        {
            var newCustomer = new Customer
            {
                CustomerID = "1",
                CompanyName = "Lethdasdsaal Corporation",
                ContactName = "das Salvarez",
                ContactTitle = "dsa",
                Address = "33 Pedro Almodovar Sq.",
                City = "Ciudad dsa",
                PostalCode = "11223",
                Country = "Spain",
                Phone = "030-0023002",
                Fax = "030-0023003"
            };

            context.Customers.Add(newCustomer);
            context.SaveChanges();
        }
    }
}
