namespace Methods
{
    using System;

    public class Student
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string OtherInfo { get; set; }

        public bool IsOlderThan(Student other)
        {
            var date = this.ParseOtherInfoToDate(this.OtherInfo);
            var dateOfOther = this.ParseOtherInfoToDate(other.OtherInfo);

            return date > dateOfOther;
        }

        private DateTime ParseOtherInfoToDate(string otherInfo)
        {
            if (otherInfo == null)
            {
                throw new ArgumentNullException("Other info is missing");
            }

            if (otherInfo.Length < 10)
            {
                throw new ArgumentException("The date doesn't present in other info");
            }

            int startIndexOfDate = this.OtherInfo.Length - 10;
            string stringDate = this.OtherInfo.Substring(startIndexOfDate);

            DateTime date;
            if (!DateTime.TryParse(stringDate, out date))
            {
                throw new ArgumentException("Date doesn't set correct in other info");
            }

            return date;
        }
    }
}
