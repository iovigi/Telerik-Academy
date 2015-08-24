namespace ExceptionsHomework
{
    using System;

    public class ExamResult
    {
        public ExamResult(int grade, int minGrade, int maxGrade, string comments)
        {
            if (grade < 0)
            {
                throw new ArgumentException("grade is less than zero");
            }

            if (minGrade < 0)
            {
                throw new ArgumentException("minGrade is less than zero");
            }

            if (grade < minGrade)
            {
                throw new ArgumentException("grade is less than minGrade");
            }

            if (maxGrade <= minGrade)
            {
                throw new ArgumentException("maxGrade is less or equal than minGrade");
            }

            if (grade > maxGrade)
            {
                throw new ArgumentException("grade is bigger than maxGrade");
            }

            if (comments == null)
            {
                throw new ArgumentNullException("comments is null");
            }

            if (comments == string.Empty)
            {
                throw new ArithmeticException("comments is empty string");
            }

            this.Grade = grade;
            this.MinGrade = minGrade;
            this.MaxGrade = maxGrade;
            this.Comments = comments;
        }

        public int Grade { get; private set; }

        public int MinGrade { get; private set; }

        public int MaxGrade { get; private set; }

        public string Comments { get; private set; }
    }
}
