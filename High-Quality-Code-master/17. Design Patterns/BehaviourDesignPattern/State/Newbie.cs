using System;

namespace State
{
    public class Newbie : ProgrammerState
    {
        public Newbie(Developer developer)
            :base(developer)
        {
            
        }

        public override void Develop()
        {
            CodeLineCount++;

            Console.WriteLine("Developer is code newbie");

            if (CodeLineCount == 5000)
            {
                Developer.State = new CodeMonkey(Developer);
            }
        }
    }
}
