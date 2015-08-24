namespace InheritanceAndPolymorphism
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class LocalCourse : Course
    {
        public LocalCourse(string name)
            : this(name, null, new List<string>())
        {
        }

        public LocalCourse(string name, string teacherName)
            : this(name, teacherName, new List<string>())
        {
        }

        public LocalCourse(string name, string teacherName, IList<string> students)
            : base(name, teacherName, students)
        {
            this.Lab = null;
        }

        public string Lab
        {
            get;
            set;
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();

            result.Append("LocalCourse");
            result.Append(base.ToString());

            if (this.Lab != null)
            {
                result.Append("; Lab = ");
                result.Append(this.Lab);
            }

            result.Append(" }");

            return result.ToString();
        }
    }
}
