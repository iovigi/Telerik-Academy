namespace AbstractFactory
{
    public interface IFactory
    {
        ITeacher CreateTeacher();
        IManager CreateManager();
    }
}
