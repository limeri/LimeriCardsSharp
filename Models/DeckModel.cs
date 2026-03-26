using CommunityToolkit.Mvvm.ComponentModel;
using Microsoft.Extensions.Logging;

namespace LimeriCardsSharp.Models
{
    /// <summary>
    /// Represents a deck of playing cards.
    /// Manages card storage, initialization, and game assets.
    /// </summary>
    public partial class DeckModel : ObservableObject
    {
        /// <summary>
        /// Logger instance for tracking deck operations.
        /// </summary>
        private readonly ILogger<DeckModel> _logger;

        /// <summary>
        /// Internal collection of cards in the deck.
        /// </summary>
        private List<CardModel> _cards;

        /// <summary>
        /// Gets or sets the name of the deck type (e.g., "Pinochle", "Standard").
        /// </summary>
        [ObservableProperty]
        private string deckName = string.Empty;

        /// <summary>
        /// Initializes a new instance of the DeckModel class.
        /// </summary>
        /// <param name="logger">The logger for recording deck operations.</param>
        public DeckModel(ILogger<DeckModel> logger)
        {
            _logger = logger;
            _cards = new List<CardModel>();
        }

        /// <summary>
        /// Gets the list of cards currently in the deck.
        /// </summary>
        /// <returns>A list of CardModel objects.</returns>
        public List<CardModel> GetCards()
        {
            return _cards;
        }

        /// <summary>
        /// Adds a card to the deck.
        /// </summary>
        /// <param name="card">The card to add to the deck.</param>
        /// <exception cref="ArgumentNullException">Thrown when card is null.</exception>
        public void AddCard(CardModel card)
        {
            if (card == null)
            {
                _logger.LogError("Cannot add null card to deck");
                throw new ArgumentNullException(nameof(card));
            }
            _cards.Add(card);
            _logger.LogDebug($"Card added to deck: {card.Name} of {card.Suit}");
        }

        /// <summary>
        /// Gets the number of cards currently in the deck.
        /// </summary>
        /// <returns>The count of cards in the deck.</returns>
        public int GetNumberOfCardsInDeck()
        {
            return _cards.Count;
        }

        /// <summary>
        /// Initializes the deck with a specific configuration and name.
        /// </summary>
        /// <param name="deckName">The name/type of the deck being initialized.</param>
        public void Initialize(string deckName)
        {
            DeckName = deckName;
            _logger.LogInformation($"Initialized deck: {deckName}");
        }

        /// <summary>
        /// Gets a random card back image path.
        /// </summary>
        /// <returns>The path to a random card back image.</returns>
        public string GetRandomCardBackImage()
        {
            return "images/playing_cards_classic/b1fh.png";
        }

        /// <summary>
        /// Gets a specific card back image path based on the design name.
        /// </summary>
        /// <param name="cardBackName">The name of the card back design.</param>
        /// <returns>The path to the specified card back image.</returns>
        public string GetCardBackImage(string cardBackName)
        {
            return $"images/playing_cards_{cardBackName}/back.png";
        }
    }
}

namespace LimeriCardsSharp.Models
{
    public class DeckModel
    {
        public List<CardModel> Cards { get; set; }
    }
}
