namespace State
{
    public class Developer
    {
        public ProgrammerState State;

        public Developer()
        {
            State = new Newbie(this);
        }

        public void Develop()
        {
            State.Develop();
        }
    }
}
