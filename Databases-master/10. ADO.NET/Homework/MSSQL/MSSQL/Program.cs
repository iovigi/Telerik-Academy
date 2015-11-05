using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSSQL
{
    public class Program
    {
        private static void WriteBinaryFile(string fileName,
            byte[] fileContents)
        {
            FileStream stream = File.OpenWrite(fileName);
            using (stream)
            {
                stream.Write(fileContents, 78, fileContents.Length - 78);
            }
        }

        public static void Main(string[] args)
        {
            var connectionString = @"Data Source=.;Initial Catalog=Northwind;Integrated Security=True;";
            var connectionStringForExcel = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=file.xlsx;Extended Properties='Excel 12.0 Xml;HDR=YES';";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand("SELECT COUNT(*) FROM Categories", connection);
                int rows = (int)command.ExecuteScalar();
                Console.WriteLine("All rows in table Categories are: {0}", rows);
            }

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand("SELECT * FROM Categories", connection);
                var rows = command.ExecuteReader();
                while (rows.Read())
                {
                    Console.WriteLine(rows["CategoryName"] + " " + rows["Description"]);
                }
            }

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand("SELECT p.ProductName as Product, c.CategoryName as Category FROM Categories c JOIN Products p ON c.CategoryID = p.CategoryID", connection);
                var rows = command.ExecuteReader();
                while (rows.Read())
                {
                    Console.WriteLine("Product:" + rows["Product"] + "; Category:" + rows["Category"]);
                }
            }

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand(
                    @"INSERT INTO Products 
                    (ProductName, SupplierID, CategoryID, Discontinued)
                    VALUES
                    (@productName,@supplierId,@categoryId,@discontinued)", connection);

                command.Parameters.AddWithValue("@productName", "test");
                command.Parameters.AddWithValue("@supplierId", 2);
                command.Parameters.AddWithValue("@categoryId", 2);
                command.Parameters.AddWithValue("@discontinued", 0);

                command.ExecuteNonQuery();
            }

            using (SqlConnection dbConn = new SqlConnection(connectionString))
            {
                dbConn.Open();

                SqlCommand cmd = new SqlCommand(
                    "SELECT CategoryID, Picture FROM Categories", dbConn);
                SqlDataReader reader = cmd.ExecuteReader();
                using (reader)
                {
                    while (reader.Read())
                    {
                        var categoryName = (int)reader["CategoryID"];
                        var image = (byte[])reader["Picture"];

                        WriteBinaryFile(categoryName + ".jpg", image);
                    }
                }
            }

            using (OleDbConnection dbCon = new OleDbConnection(connectionStringForExcel))
            {
                dbCon.Open();

                OleDbCommand command = new OleDbCommand("SELECT * FROM [Sheet1$]", dbCon);
                var reader = command.ExecuteReader();


                while (reader.Read())
                {
                    var name = reader["Name"];
                    var score = reader["Score"];

                    Console.WriteLine("Name: {0}, Score: {1}", name, score);
                }

                OleDbCommand com = new OleDbCommand("INSERT INTO [Sheet1$] VALUES(@Name, @Score)", dbCon);

                com.Parameters.AddWithValue("@Name", "test");
                com.Parameters.AddWithValue("@Score", 2);

                com.ExecuteNonQueryAsync();
            }

            Find(connectionString);
        }

        private static void Find(string connectionString)
        {
            var searchWord = Console.ReadLine();

            using (var connetion = new SqlConnection(connectionString))
            {
                connetion.Open();

                var cmd = new SqlCommand(@"SELECT ProductName
                                                     FROM Products
                                                     WHERE CHARINDEX(@pattern, ProductName) > 0", connetion);
                cmd.Parameters.AddWithValue("@pattern", searchWord);
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var productName = reader["ProductName"];
                        Console.WriteLine(" - " + productName);
                    }
                }
            }
        }
    }
}
