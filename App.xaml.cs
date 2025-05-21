namespace color
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
        }

        protected override Window CreateWindow(IActivationState? activationState)
        {
            var window = new Window(new AppShell());
            //window.Width = 400;
            //window.Height = 720;
            window.MinimumWidth = 400;
            window.MinimumHeight = 720;
            return window;
        }
    }
}