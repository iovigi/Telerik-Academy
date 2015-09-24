using System;

namespace State
{
    public class CodeMonkey : ProgrammerState
    {
        public CodeMonkey(Developer developer)
            :base(developer)
        {

        }

        public override void Develop()
        {
            CodeLineCount += 50;

            Console.WriteLine("Developer is code monkey");

            if (CodeLineCount == 50000)
            {
                Developer.State = new Junior(Developer);
            }
        }
    }
}
