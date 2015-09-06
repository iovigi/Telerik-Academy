namespace AbstractFactory.Academy
{
    public class AcademyFactory : IFactory
    {
        public IManager CreateManager()
        {
            return new Manager();
        }

        public ITeacher CreateTeacher()
        {
            return new Trainer();
        }
    }
}

