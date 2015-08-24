namespace School
{
    using System;
    using System.Collections.Generic;

    public class Course
    {
        private readonly HashSet<Student> students = new HashSet<Student>();

        private School school;

        public Course(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                throw new ArgumentException("Name can't be empty");
            }

            this.Name = name;
        }

        public string Name { get; private set; }

        public School School
        {
            get
            {
                return this.school;
            }

            set
            {
                if (this.school == value)
                {
                    return;
                }

                if (this.school != null)
                {
                    this.school.RemoveCourse(this);

                    this.students.Clear();
                }

                this.school = value;

                if (value != null)
                {
                    this.school.AddCourse(this);
                }
            }
        }

        public IEnumerable<Student> Students
        {
            get
            {
                return this.students;
            }
        }

        public int CountOfStudents
        {
            get
            {
                return this.students.Count;
            }
        }

        public bool IsFull
        {
            get
            {
                return this.CountOfStudents == 30;
            }
        }

        public void AddStudent(Student student)
        {
            if (this.IsFull)
            {
                throw new ArgumentException("Course is full");
            }

            if (!this.School.ContainsStudent(student))
            {
                throw new ArgumentException("This student isn't from same school");
            }

            this.students.Add(student);
        }

        public bool RemoveStudent(Student student)
        {
            return this.students.Remove(student);
        }
    }
}
