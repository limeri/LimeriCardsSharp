using LimeriCardsSharp.Controllers;

namespace LimeriCardsSharp
{
    /// <summary>
    /// Code-behind for the main page of the Limeri Cards application.
    /// Handles game initialization and user interactions.
    /// </summary>
    public partial class MainPage : ContentPage
    {
        /// <summary>
        /// The game controller managing game logic.
        /// </summary>
        private readonly GameController _gameController;

        /// <summary>
        /// The deck controller managing card operations.
        /// </summary>
        private readonly DeckController _deckController;

        /// <summary>
        /// Initializes a new instance of the MainPage.
        /// Uses dependency injection to receive controller instances.
        /// </summary>
        /// <param name="gameController">The game controller instance.</param>
        /// <param name="deckController">The deck controller instance.</param>
        public MainPage(GameController gameController, DeckController deckController)
        {
            InitializeComponent();
            _gameController = gameController;
            _deckController = deckController;
        }

        /// <summary>
        /// Handles the "Start New Game" button click event.
        /// Initializes the deck and game, then updates the UI status.
        /// </summary>
        /// <param name="sender">The control that triggered the event.</param>
        /// <param name="e">The event arguments.</param>
        private void OnStartGameClicked(object sender, EventArgs e)
        {
            try
            {
                // Initialize the deck
                _deckController.Initialize("Pinochle");
                
                // Initialize the game
                _gameController.Initialize(_deckController);
                
                // Update UI with game status
                StatusLabel.Text = $"Game started with {_gameController.GetNumberOfPlayers()} players!";
            }
            catch (Exception ex)
            {
                DisplayAlert("Error", $"Failed to start game: {ex.Message}", "OK");
            }
        }

        /// <summary>
        /// Handles the "Settings" button click event.
        /// Displays a settings dialog (placeholder implementation).
        /// </summary>
        /// <param name="sender">The control that triggered the event.</param>
        /// <param name="e">The event arguments.</param>
        private async void OnSettingsClicked(object sender, EventArgs e)
        {
            await DisplayAlert("Settings", "Settings page coming soon!", "OK");
        }
    }
}
