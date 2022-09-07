namespace TicTacToe.MAUI
{
    public partial class App : Application
    {
        public App(AppShell appShell)
        {
            InitializeComponent();

            MainPage = appShell;
        }

        protected override Window CreateWindow(IActivationState activationState)
        {
            var window = base.CreateWindow(activationState);

            if (window != null)
            {
                window.Title = "Tic Tac Toe";
            }

            return window;
        }
    }
}