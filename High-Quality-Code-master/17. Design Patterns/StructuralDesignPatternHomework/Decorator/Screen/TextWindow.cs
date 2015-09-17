namespace Screen
{
    public class TextWindow :Decorator
    {
        public TextWindow(Window window)
            :base(window)
        {
        }

        public string Text { get; set; }

        public override void Show()
        {
            base.Show();

            System.Console.WriteLine(Text);
        }
    }
}
