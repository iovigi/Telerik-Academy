namespace AbstractFactory.School
{
    public class SchoolFactory : IFactory
    {
        public IManager CreateManager()
        {
            return new Manager();
        }

        public ITeacher CreateTeacher()
        {
           return  new Teacher();
        }
    }
}
