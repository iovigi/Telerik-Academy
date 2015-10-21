namespace School.Data
{
    using Model;
    using Migrations;
    using System.Data.Entity;

    public class SchoolDbContext : DbContext
    {
        public SchoolDbContext() 
            : base("SchoolDb")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<SchoolDbContext, Configuration>());
        }

        public IDbSet<Homework> Homeworks { get; set; }

        public IDbSet<Course> Courses { get; set; }

        public IDbSet<Student> Students { get; set; }
    }
}
