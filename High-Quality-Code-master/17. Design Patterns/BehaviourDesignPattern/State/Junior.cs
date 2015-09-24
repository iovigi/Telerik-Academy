using System;

namespace State
{
    public class Junior : ProgrammerState
    {
        public Junior(Developer developer)
            :base(developer)
        {

        }

        public override void Develop()
        {
            CodeLineCount += 500;

            Console.WriteLine("Developer is junior");
        }
    }
}
