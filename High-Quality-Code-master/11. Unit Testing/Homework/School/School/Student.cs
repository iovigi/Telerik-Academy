namespace School
{
    using System;

    public class Student
    {
        public const int MIN_ID = 10000;
        public const int MAX_ID = 99999;

        private string name;
        private int id;

        public Student(string name, int id)
        {
            this.Name = name;
            this.ID = id;
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
                    throw new ArgumentException("Name can't be empty");
                }

                this.name = value;
            }
        }

        public int ID
        {
            get
            {
                return this.id;
            }

            set
            {
                if (value < MIN_ID || MAX_ID < value)
                {
                    throw new ArgumentException("Invalid id");
                }

                this.id = value;
            }
        }
    }
}
