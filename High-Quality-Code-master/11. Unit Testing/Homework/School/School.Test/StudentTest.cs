namespace School.Test
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class StudentTest
    {
        [TestMethod]
        public void CreateStudentTest()
        {
            Student student = new Student("Kiro",10000);

            Assert.AreEqual("Kiro", student.Name);
            Assert.AreEqual(10000, student.ID);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void CreateWithNullNameStudentTest()
        {
            Student student = new Student(null, 10000);
        }


        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void CreateWrongIDNameStudentTest()
        {
            Student student = new Student("Kiro", 999);
        }
    }
}
