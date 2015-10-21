using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using School.Data;

namespace School.ConsoleClient
{
    public class Startup
    {
        public static void Main(string[] args)
        {
            var db = new SchoolDbContext();

            var savedStudent = db.Students.First();
            db.Students.Remove(savedStudent);
            db.SaveChanges();
        }
    }
}
