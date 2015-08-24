namespace ExceptionsHomework
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Student
    {
        private string firstName;
        private string lastName;

        public Student(string firstName, string lastName, IList<Exam> exams = null)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Exams = exams;
        }

        public string FirstName 
        {
            get
            {
                return this.firstName;
            }

            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("firstName is null");
                }

                if (value == string.Empty)
                {
                    throw new ArgumentException("firstName is string empty");
                }

                this.firstName = value;
            }
        }

        public string LastName
        {
            get
            {
                return this.firstName;
            }

            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("lastName is null");
                }

                if (value == string.Empty)
                {
                    throw new ArgumentException("lastName is string empty");
                }

                this.lastName = value;
            }
        }

        public IList<Exam> Exams { get; set; }

        public IList<ExamResult> CheckExams()
        {
            if (this.Exams == null)
            {
                throw new ArgumentNullException("Exams is null");
            }

            if (this.Exams.Count == 0)
            {
                throw new ArgumentException("Exams is zero");
            }

            IList<ExamResult> results = new List<ExamResult>();

            for (int i = 0; i < this.Exams.Count; i++)
            {
                results.Add(this.Exams[i].Check());
            }

            return results;
        }

        public double CalcAverageExamResultInPercents()
        {
            IList<ExamResult> examResults = this.CheckExams();

            double[] examScore = new double[this.Exams.Count];

            for (int i = 0; i < examResults.Count; i++)
            {
                double calculatedGrade = examResults[i].Grade - examResults[i].MinGrade;
                double calculatedMaxGrade = examResults[i].MaxGrade - examResults[i].MinGrade;

                examScore[i] = calculatedGrade / calculatedMaxGrade;
            }

            return examScore.Average();
        }
    }
}
