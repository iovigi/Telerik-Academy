namespace Screen
{
    using System;

    public class Decorator : Window
    {
        protected readonly Window window;

        public Decorator(Window window)
        {
            if (window == null)
            {
                throw new ArgumentNullException();
            }

            this.window = window;
        }

        public override void Show()
        {
            window.Show();
        }
    }
}
