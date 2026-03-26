namespace LimeriCardsSharp
{
    /// <summary>
    /// Code-behind for the main application class.
    /// Initializes the application shell for navigation and UI setup.
    /// </summary>
    public partial class App : Application
    {
        /// <summary>
        /// Initializes a new instance of the App class.
        /// Sets up the application shell as the main page.
        /// </summary>
        public App()
        {
            InitializeComponent();
            MainPage = new AppShell();
        }
    }
}
