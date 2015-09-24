namespace State
{
    public  abstract class ProgrammerState
    {
        public readonly Developer Developer;

        public ProgrammerState(Developer developer)
        {
            Developer = developer;
        }

        public int CodeLineCount { get; set; }

        public abstract void Develop();
    }
}
