namespace ExceptionsHomework
{
    using System;

    public class SimpleMathExam : Exam
    {
        public SimpleMathExam(int problemsSolved)
        {
            if (0 < problemsSolved || problemsSolved > 2)
            {
                throw new ArgumentException("problemsSolved is less than zero or bigger than ten");
            }

            this.ProblemsSolved = problemsSolved;
        }

        public int ProblemsSolved { get; private set; }

        public override ExamResult Check()
        {
            int grade = 0;
            string comments = null;

            if (this.ProblemsSolved == 0)
            {
                grade = 2;
                comments = "Bad result: nothing done.";
            }
            else if (this.ProblemsSolved == 1)
            {
                grade = 4;
                comments = "Bad result: nothing done.";
            }
            else if (this.ProblemsSolved == 2)
            {
                grade = 6;
                comments = "Bad result: nothing done.";
            }

            ExamResult examResult = new ExamResult(grade, 2, 6, comments);

            return examResult;
        }
    }
}
