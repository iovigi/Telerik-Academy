namespace StudentOrder
{
    using System;

    public class Fullname : IComparable<Fullname>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public int CompareTo(Fullname other)
        {
            var cmp = this.LastName.CompareTo(other.LastName);

            if (cmp != 0)
            {
                return cmp;
            }

            return this.FirstName.CompareTo(other.FirstName);
        }

        public override string ToString()
        {
            return string.Format("{0} {1}", this.FirstName, this.LastName);
        }
    }
}
