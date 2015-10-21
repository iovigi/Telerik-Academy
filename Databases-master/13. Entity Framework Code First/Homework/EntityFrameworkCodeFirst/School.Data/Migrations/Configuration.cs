namespace School.Data.Migrations
{
    using Model;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<School.Data.SchoolDbContext>
    {
        public Configuration()
        {
            this.AutomaticMigrationsEnabled = true;
            this.AutomaticMigrationDataLossAllowed = false;
        }

        protected override void Seed(SchoolDbContext context)
        {
            this.SeedCourses(context);
            this.SeedStudents(context);
        }

        private void SeedStudents(SchoolDbContext context)
        {
            context.Students.AddOrUpdate(new Student
            {
                Name = "Evlogi",
                Number = 35
            });

            context.Students.AddOrUpdate(new Student
            {
                Name = "Pesho",
                Number = 123
            });

            context.Students.AddOrUpdate(new Student
            {
                Name = "Pesho",
                Number = 2575
            });

            context.Students.AddOrUpdate(new Student
            {
                Name = "Pesho",
                Number = 65765
            });
        }

        private void SeedCourses(SchoolDbContext context)
        {
            context.Courses.AddOrUpdate(new Course
            {
                Name = "Dance",
                Description = "dance"
            });

            context.Courses.AddOrUpdate(new Course
            {
                Name = "Hip hop",
                Description = "hip hop"
            });
        }
    }
}
