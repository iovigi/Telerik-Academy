using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySQL
{
    class Program
    {
        private static void Main()
        {
            // In order to work with your local MySQL Database, you must change username and password in Connection.settings
            try
            {
                using (var mySqlConnection = new MySqlConnection("Server=localhost;Port=3307;Database=Books;Uid=123;Pwd=parola123;"))
                {
                    mySqlConnection.Open();

                    AddBooks(mySqlConnection);
                    FindBooksByName(mySqlConnection);
                    ListingAllBooks(mySqlConnection);
                }
            }
            finally
            {
            }
        }

        private static void AddBooks(MySqlConnection mySqlConnection)
        {
            var mySqlCommand = new MySqlCommand(@"INSERT INTO books (Title, Author, PublishDate, ISBN)
                                                           VALUES (@title, @author, @publishDate, @isbn)",mySqlConnection);

            mySqlCommand.Parameters.AddWithValue("@title", "Kir");
            mySqlCommand.Parameters.AddWithValue("@author", "Kiro");
            mySqlCommand.Parameters.AddWithValue("@publishDate", DateTime.Now);
            mySqlCommand.Parameters.AddWithValue("@isbn", "12312");

            mySqlCommand.ExecuteNonQuery();
        }

        private static void FindBooksByName(MySqlConnection mySqlConnection)
        {
            Console.WriteLine("Input search");
            var substring = Console.ReadLine();

            var mySqlCommand = new MySqlCommand(@"SELECT Title, Author, PublishDate, ISBN
                                                           FROM books
                                                           WHERE LOCATE(@substring, Title)", mySqlConnection);

            mySqlCommand.Parameters.AddWithValue("@substring", substring);

            using (var reader = mySqlCommand.ExecuteReader())
            {
                while (reader.Read())
                {
                    var title = reader["Title"].ToString();
                    var author = reader["Author"].ToString();
                    var publishDate = DateTime.Parse(reader["PublishDate"].ToString());
                    var isbn = reader["ISBN"].ToString();

                    Console.WriteLine(title + " " + author + " " + isbn);
                }
            }
        }

        private static void ListingAllBooks(MySqlConnection mySqlConnection)
        {
            var mySqlCommand = new MySqlCommand(@"SELECT Title, Author, PublishDate, ISBN
                                                           FROM books", mySqlConnection);

            using (var reader = mySqlCommand.ExecuteReader())
            {
                while (reader.Read())
                {
                    var title = reader["Title"].ToString();
                    var author = reader["Author"].ToString();
                    var publishDate = DateTime.Parse(reader["PublishDate"].ToString());
                    var isbn = reader["ISBN"].ToString();

                    Console.WriteLine(title + " " + author + " " + isbn);
                }
            }
        }
    }
}
