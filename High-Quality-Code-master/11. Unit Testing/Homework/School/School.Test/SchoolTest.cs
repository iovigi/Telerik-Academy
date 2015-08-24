namespace School.Test
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System;

    [TestClass]
    public class SchoolTest
    {
        [TestMethod]
        public void CreateSchool()
        {
            School school = new School("test");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void CreateSchoolWithNullName()
        {
            School school = new School(null);
        }

        [TestMethod]
        public void AddStudent()
        {
            School school = new School("test");

            var student = school.CreateStudent("Kiro");
            school.AddStudent(student);

            Assert.IsTrue(school.ContainsStudent(student));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void AddNullStudent()
        {
            School school = new School("test");

            school.AddStudent(null);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void AddWithSameIDStudent()
        {
            School school = new School("test");

            var student = new Student("Ivan",10001);
            var studentTwo = new Student("Kiro", 10001);

            school.AddStudent(student);
            school.AddStudent(studentTwo);
        }

        [TestMethod]
        public void RemoveStudent()
        {
            School school = new School("test");

            var student = school.CreateStudent("Kiro");
            school.AddStudent(student);


            Assert.IsTrue(school.RemoveStudent(student));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void RemoveNullStudent()
        {
            School school = new School("test");

            var course = new Course("testCourse");

            Assert.IsFalse(school.RemoveStudent(null));
        }

        [TestMethod]
        public void AddCourse()
        {
            School school = new School("test");

            var course = new Course("testCourse");
            school.AddCourse(course);

            Assert.IsTrue(school.ContainsCourse(course));
        }


        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void AddNullCourse()
        {
            School school = new School("test");

            school.AddCourse(null);
        }

        [TestMethod]
        public void AddCourseWithSetSchool()
        {
            School school = new School("test");

            var course = new Course("testCourse");
            course.School = school;
            school.AddCourse(course);

            Assert.IsTrue(school.ContainsCourse(course));
        }

        [TestMethod]
        public void RemoveCourse()
        {
            School school = new School("test");

            var course = new Course("testCourse");
            school.AddCourse(course);

            Assert.IsTrue(school.RemoveCourse(course));
        }

        [TestMethod]
        public void RemoveCourseWithOtherSchool()
        {
            School school = new School("test");

            var course = new Course("testCourse");
            
            Assert.IsFalse(school.RemoveCourse(course));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void RemoveNullCourse()
        {
            School school = new School("test");

            var course = new Course("testCourse");

            Assert.IsFalse(school.RemoveCourse(null));
        }
    }
}
