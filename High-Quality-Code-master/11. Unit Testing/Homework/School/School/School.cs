namespace School
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;

    public class School
    {
        private readonly BitArray idMap = new BitArray(Student.MAX_ID - Student.MIN_ID);

        private readonly HashSet<Student> students = new HashSet<Student>();
        private readonly HashSet<Course> courses = new HashSet<Course>();

        private string name;

        public School(string name)
        {
            this.Name = name;
        }

        public string Name
        {
            get
            {
                return this.name;
            }

            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("name can be empty");
                }

                this.name = value;
            }
        }

        public int AllocID()
        {
            int mapLenght = this.idMap.Length;

            for (int i = 0; i < mapLenght; i++)
            {
                if (!this.idMap[i])
                {
                    this.idMap[i] = true;

                    return i + Student.MIN_ID;
                }
            }

            throw new ArgumentException("There isn't free ids");
        }

        public void ReleaseID(int id)
        {
            if (id < Student.MIN_ID || Student.MAX_ID < id)
            {
                throw new ArgumentException("Invalid id");
            }

            this.idMap[id] = false;
        }

        public Student CreateStudent(string name)
        {
            return new Student(name, this.AllocID());
        }

        public void AddStudent(Student student)
        {
            if (student == null)
            {
                throw new ArgumentNullException("student can't be null");
            }

            if (this.students.Any(x => x.ID == student.ID))
            {
                throw new ArgumentException("ID must be unique");
            }

            this.students.Add(student);
        }

        public bool RemoveStudent(Student student)
        {
            if (student == null)
            {
                throw new ArgumentNullException("student can't be null");
            }

            var isRemoved = this.students.Remove(student);

            if (isRemoved)
            {
                ReleaseID(student.ID);
            }

            return isRemoved;
        }

        public bool ContainsStudent(Student student)
        {
            return this.students.Contains(student);
        }

        public IEnumerable<Student> GetStudents()
        {
            return this.students;
        }

        public void AddCourse(Course course)
        {
            if (course == null)
            {
                throw new ArgumentNullException("course");
            }

            if (course.School != this)
            {
                course.School = this;

                return;
            }

            this.courses.Add(course);
        }

        public bool RemoveCourse(Course course)
        {
            if (course == null)
            {
                throw new ArgumentNullException("course");
            }

            if (course.School != this)
            {
                return false;
            }

            return this.courses.Remove(course);
        }

        public bool ContainsCourse(Course course)
        {
            return this.courses.Contains(course);
        }

        public IEnumerable<Course> GetCourses()
        {
            return this.courses;
        }
    }
}
