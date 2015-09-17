namespace Screen
{
    public class Window
    {
        public Window()
        {

        }

        public int Width { get; set; }
        public int Height { get; set; }

        public virtual void Show()
        {
            System.Console.WriteLine("Window");
        }
    }
}
