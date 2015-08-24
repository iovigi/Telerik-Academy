namespace School.Test
{
    using System;
    using System.Linq;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class CourseTest
    {
        [TestMethod]
        public void CreateCourseWithValidName()
        {
            Course course = new Course("Test");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void CreateCourseWithNullName()
        {
            Course course = new Course(null);
        }

        [TestMethod]
        public void AttachSchoolToCourse()
        {
            School school = new School("test-school");
            Course course = new Course("Test");

            course.School = school;

            Assert.AreSame(school, course.School);
        }

        [TestMethod]
        public void AddStudentWhenCourseIsntFull()
        {
            School school = new School("test-school");
            Course course = new Course("Test");
            Student student = school.CreateStudent("ivan");

            course.School = school;
            school.AddStudent(student);
            course.AddStudent(student);

            Assert.IsTrue(course.Students.Contains(student), "Student isn't add");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void AddStudentWhenCourseIsFull()
        {
            School school = new School("test-school");
            Course course = new Course("Test");


            course.School = school;

            for (int i = 0; i < 31; i++)
            {
                Student student = school.CreateStudent("ivan");
                school.AddStudent(student);
                course.AddStudent(student);
            }
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void AddStudentFromDifferentSchool()
        {
            School school = new School("test-school");
            Course course = new Course("Test");

            course.School = school;

            Student student = new Student("ivan", 10001);
            course.AddStudent(student);
        }

        [TestMethod]
        public void CourseIsFull()
        {
            School school = new School("test-school");
            Course course = new Course("Test");

            course.School = school;

            for (int i = 0; i < 30; i++)
            {
                Student student = school.CreateStudent("ivan");
                school.AddStudent(student);
                course.AddStudent(student);
            }

            Assert.IsTrue(course.IsFull);
        }

        [TestMethod]
        public void CountOfStudentInCourse()
        {
            School school = new School("test-school");
            Course course = new Course("Test");

            course.School = school;

            for (int i = 0; i < 30; i++)
            {
                Student student = school.CreateStudent("ivan");
                school.AddStudent(student);
                course.AddStudent(student);
            }

            Assert.AreEqual(30, course.CountOfStudents);
        }

        [TestMethod]
        public void RemoveStudentsFromCourse()
        {
            School school = new School("test-school");
            Course course = new Course("Test");

            course.School = school;

            for (int i = 0; i < 30; i++)
            {
                Student student = school.CreateStudent("ivan");
                school.AddStudent(student);
                course.AddStudent(student);
            }

            var students = course.Students.ToList();

            foreach (var student in students)
            {
                Assert.IsTrue(course.RemoveStudent(student));
            }

            Assert.AreEqual(0, course.CountOfStudents);
        }
    }
}
