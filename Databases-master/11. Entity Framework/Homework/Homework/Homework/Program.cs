using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Homework
{
    public class Program
    {
        public static void Main(string[] args)
        {
            DAO.ManipulateDatabase();
            FindCustormers();
            FindOrder("g", DateTime.MinValue, DateTime.MaxValue);
            FindCustormersSQL();
            StartTasks();
        }

        public static void FindCustormers()
        {
            using (NorthwindEntities context = new NorthwindEntities())
            {
                foreach (var customer in context.Customers.Where(x=> x.Orders.Any(y=> y.OrderDate.HasValue && y.OrderDate.Value.Year == 1997 && y.ShipCountry == "Canada")))
                {
                    Console.WriteLine(customer.ContactName);
                }
            }
        }

        private static void FindCustormersSQL()
        {
            const string nativeSqlQuery =
                "SELECT *" +
                "FROM Customers c " +
                "JOIN Orders o " +
                "ON c.CustomerID = o.CustomerID " +
                "WHERE YEAR(o.OrderDate) = 1997 AND o.ShipCountry = 'Canada'";

            using (var db = new NorthwindEntities())
            {
                var customers = db.Database.SqlQuery<Customer>(nativeSqlQuery);
                foreach (var customer in customers)
                {
                    Console.WriteLine(customer.ContactName);
                }
            }
        }

        public static void FindOrder(string region,DateTime startDate, DateTime endDateTime)
        {
            using (NorthwindEntities context = new NorthwindEntities())
            {
                foreach (var order in context.Orders.Where(x=> x.ShipRegion.ToLower().Contains(region.ToLower()) && x.OrderDate >= startDate && x.OrderDate <= endDateTime))
                {
                    Console.WriteLine(order.OrderID);
                }
            }
        }

        public static void StartTasks()
        {
            var taskOne = Task.Factory.StartNew(WorkTask);
            var taskTwo = Task.Factory.StartNew(WorkTask);
            var taskThree = Task.Factory.StartNew(WorkTask);
            var taskFour = Task.Factory.StartNew(WorkTask);

            Task.WaitAll(taskOne, taskTwo, taskThree, taskFour);
        }

        public static void WorkTask()
        {
            using (NorthwindEntities context = new NorthwindEntities())
            {
                context.Customers.First().City = "Plovdiv";
                Thread.Sleep(1000);
                context.SaveChanges();
            }
        }
    }
}
