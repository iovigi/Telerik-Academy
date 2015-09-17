namespace Screen
{
    public class Scrollable : Decorator
    {
        public Scrollable(Window window)
            :base(window)
        {
        }

        public override void Show()
        {
            base.Show();

            System.Console.WriteLine("Scrollable");
        }
    }
}
