using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQLLite
{
    class Program
    {
        static void Main(string[] args)
        {
            var connectionString = @"Data Source=SQLiteBooks; Version=3";


            GetBooks(connectionString);
            InsertBook(connectionString);
        }

        private static void InsertBook(string connectionString)
        {
            SQLiteConnection dbCon = new SQLiteConnection(connectionString);
            dbCon.Open();

            var command = new SQLiteCommand("INSERT INTO books(Title,Author, PublishDate, ISBN) VALUES (@title,@author,@publishDate,@isbn)", dbCon);
            command.Parameters.AddWithValue("@title", "New Book");
            command.Parameters.AddWithValue("@author", "New Author");
            command.Parameters.AddWithValue("@publishDate", DateTime.Now);
            command.Parameters.AddWithValue("@isbn", "2324-324-34");

            command.ExecuteNonQuery();
        }

        private static void GetBooks(string connectionString)
        {
            SQLiteConnection dbCon = new SQLiteConnection(connectionString);
            dbCon.Open();

            SQLiteCommand command = new SQLiteCommand("SELECT * FROM Books", dbCon);
            var reader = command.ExecuteReader();

            while (reader.Read())
            {
                Console.WriteLine("Title: {0}, Author: {1} ISBN: {2}, published on: {3}",
                       reader["Title"], reader["Author"], reader["ISBN"], ((DateTime)reader["PublishDate"]));
            }
        }
    }
}
