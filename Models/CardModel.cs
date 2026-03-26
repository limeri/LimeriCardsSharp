using CommunityToolkit.Mvvm.ComponentModel;

namespace LimeriCardsSharp.Models
{
    /// <summary>
    /// Represents a single playing card in the Limeri Cards game.
    /// Uses MVVM Observable pattern for property binding in MAUI.
    /// </summary>
    public partial class CardModel : ObservableObject
    {
        /// <summary>
        /// Gets or sets the name of the card (e.g., "Ace", "King", "Queen").
        /// </summary>
        [ObservableProperty]
        private string name = string.Empty;

        /// <summary>
        /// Gets or sets the suit of the card (e.g., "Hearts", "Diamonds", "Clubs", "Spades").
        /// </summary>
        [ObservableProperty]
        private string suit = string.Empty;

        /// <summary>
        /// Gets or sets the numeric value of the card for scoring purposes.
        /// </summary>
        [ObservableProperty]
        private int value;

        /// <summary>
        /// Gets or sets the image path for displaying the card in the UI.
        /// </summary>
        [ObservableProperty]
        private string imagePath = string.Empty;

        /// <summary>
        /// Initializes a new instance of the CardModel class with specified properties.
        /// </summary>
        /// <param name="name">The name of the card.</param>
        /// <param name="suit">The suit of the card.</param>
        /// <param name="value">The numeric value of the card.</param>
        /// <param name="imagePath">The path to the card's image resource.</param>
        public CardModel(string name, string suit, int value, string imagePath)
        {
            Name = name;
            Suit = suit;
            Value = value;
            ImagePath = imagePath;
        }

        /// <summary>
        /// Initializes a new instance of the CardModel class with default values.
        /// </summary>
        public CardModel()
        {
        }

        /// <summary>
        /// Returns a string representation of the card (e.g., "Ace of Hearts").
        /// </summary>
        /// <returns>A formatted string containing the card's name and suit.</returns>
        public override string ToString()
        {
            return $"{Name} of {Suit}";
        }
    }
}
