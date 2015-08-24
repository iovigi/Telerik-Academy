namespace InheritanceAndPolymorphism
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class OffsiteCourse : Course
    {
        public OffsiteCourse(string name)
            : this(name, null, new List<string>())
        {
        }

        public OffsiteCourse(string name, string teacherName)
            : this(name, teacherName, new List<string>())
        {
        }

        public OffsiteCourse(string name, string teacherName, IList<string> students)
            : base(name, teacherName, students)
        {
            this.Town = null;
        }

        public string Town
        {
            get;
            set;
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();

            result.Append("OffsiteCourse");
            result.Append(base.ToString());

            if (this.Town != null)
            {
                result.Append("; Town = ");
                result.Append(this.Town);
            }

            result.Append(" }");

            return result.ToString();
        }
    }
}
