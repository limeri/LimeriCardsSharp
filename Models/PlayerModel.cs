using CommunityToolkit.Mvvm.ComponentModel;
using Microsoft.Extensions.Logging;

namespace LimeriCardsSharp.Models
{
    /// <summary>
    /// Represents a player in the Limeri Cards game.
    /// Manages player state, hand, and scoring information.
    /// </summary>
    public partial class PlayerModel : ObservableObject
    {
        /// <summary>
        /// Logger instance for tracking player operations.
        /// </summary>
        private readonly ILogger<PlayerModel> _logger;

        /// <summary>
        /// The player's current hand of cards.
        /// </summary>
        private List<CardModel> _hand;

        /// <summary>
        /// Gets or sets the name of the player.
        /// </summary>
        [ObservableProperty]
        private string name = string.Empty;

        /// <summary>
        /// Gets or sets the table position of the player (e.g., "North", "South", "East", "West").
        /// </summary>
        [ObservableProperty]
        private string tablePosition = string.Empty;

        /// <summary>
        /// Gets or sets the current score of the player.
        /// </summary>
        [ObservableProperty]
        private int score;

        /// <summary>
        /// Initializes a new instance of the PlayerModel class.
        /// </summary>
        /// <param name="logger">The logger for recording player operations.</param>
        public PlayerModel(ILogger<PlayerModel> logger)
        {
            _logger = logger;
            _hand = new List<CardModel>();
        }

        /// <summary>
        /// Gets the player's current hand of cards.
        /// </summary>
        /// <returns>A list of CardModel objects representing the player's hand.</returns>
        public List<CardModel> GetHand()
        {
            return _hand;
        }

        /// <summary>
        /// Adds a card to the player's hand.
        /// </summary>
        /// <param name="card">The card to add to the player's hand.</param>
        /// <exception cref="ArgumentNullException">Thrown when card is null.</exception>
        public void AddCardToHand(CardModel card)
        {
            if (card == null)
            {
                _logger.LogError($"Cannot add null card to player {Name}'s hand");
                throw new ArgumentNullException(nameof(card));
            }
            _hand.Add(card);
            _logger.LogDebug($"Card {card.Name} of {card.Suit} added to {Name}'s hand");
        }

        /// <summary>
        /// Sorts the player's hand by suit and then by card value.
        /// </summary>
        public void SortHand()
        {
            _hand = _hand.OrderBy(c => c.Suit).ThenBy(c => c.Value).ToList();
            _logger.LogDebug($"Sorted hand for player: {Name}");
        }

        /// <summary>
        /// Clears all cards from the player's hand.
        /// </summary>
        public void ClearHand()
        {
            _hand.Clear();
            _logger.LogDebug($"Cleared hand for player: {Name}");
        }
    }
}
