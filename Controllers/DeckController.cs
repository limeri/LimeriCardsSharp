using Microsoft.Extensions.Logging;
using LimeriCardsSharp.Models;

namespace LimeriCardsSharp.Controllers
{
    /// <summary>
    /// Controller for managing deck operations including initialization, shuffling, and dealing.
    /// Uses dependency injection for logging and improved error handling.
    /// </summary>
    public class DeckController
    {
        /// <summary>
        /// Logger instance for tracking deck controller operations.
        /// </summary>
        private readonly ILogger<DeckController> _logger;

        /// <summary>
        /// The deck model being managed by this controller.
        /// </summary>
        private DeckModel? _deck;

        /// <summary>
        /// Initializes a new instance of the DeckController class.
        /// </summary>
        /// <param name="logger">The logger for recording operations.</param>
        public DeckController(ILogger<DeckController> logger)
        {
            _logger = logger;
        }

        /// <summary>
        /// Gets the current deck model.
        /// </summary>
        /// <returns>The DeckModel instance or null if not initialized.</returns>
        public DeckModel? GetDeck() => _deck;

        /// <summary>
        /// Sets the deck model.
        /// </summary>
        /// <param name="deck">The deck model to set.</param>
        public void SetDeck(DeckModel deck) => _deck = deck;

        /// <summary>
        /// Deals a specified number of cards to each player.
        /// Shuffles the deck and distributes cards in order.
        /// </summary>
        /// <param name="players">The list of players to deal cards to.</param>
        /// <param name="cardsPerHand">The number of cards each player should receive.</param>
        /// <exception cref="InvalidOperationException">Thrown when deck is not initialized.</exception>
        /// <exception cref="ArgumentException">Thrown when players list is empty or cards per hand is invalid.</exception>
        public void Deal(List<PlayerModel> players, int cardsPerHand)
        {
            if (_deck == null)
            {
                _logger.LogError("Cannot deal cards - deck not initialized");
                throw new InvalidOperationException("Deck not initialized");
            }

            if (players == null || players.Count == 0)
            {
                _logger.LogError("Cannot deal cards - no players provided");
                throw new ArgumentException("No players provided");
            }

            if (cardsPerHand <= 0)
            {
                _logger.LogError($"Cannot deal cards - invalid cards per hand: {cardsPerHand}");
                throw new ArgumentException("Cards per hand must be positive");
            }

            int totalCardsNeeded = players.Count * cardsPerHand;
            if (totalCardsNeeded > _deck.GetNumberOfCardsInDeck())
            {
                _logger.LogError($"Cannot deal {cardsPerHand} cards to {players.Count} players - only {_deck.GetNumberOfCardsInDeck()} cards available");
                throw new ArgumentException("Insufficient cards in deck");
            }

            _logger.LogInformation($"Dealing {cardsPerHand} cards to {players.Count} players");

            // Shuffle the deck
            var cards = new Stack<CardModel>(_deck.GetCards());
            var random = new Random();
            var shuffled = cards.OrderBy(x => random.Next()).ToList();

            _logger.LogDebug($"Shuffled {shuffled.Count} cards for dealing");

            // Deal cards to each player
            foreach (var player in players)
            {
                _logger.LogDebug($"Dealing {cardsPerHand} cards to player: {player.Name}");

                for (int i = 0; i < cardsPerHand; i++)
                {
                    try
                    {
                        var card = shuffled[shuffled.Count - 1];
                        shuffled.RemoveAt(shuffled.Count - 1);
                        player.AddCardToHand(card);
                        _logger.LogTrace($"Dealt card {card.ToString()} to {player.Name}");
                    }
                    catch (Exception e)
                    {
                        _logger.LogError($"Ran out of cards while dealing to player: {player.Name}");
                        throw new InvalidOperationException("Insufficient cards during dealing", e);
                    }
                }
                player.SortHand();
                _logger.LogDebug($"Completed dealing to player: {player.Name} (hand size: {player.GetHand().Count})");
            }

            _logger.LogInformation($"Successfully dealt {totalCardsNeeded} cards to {players.Count} players");
        }

        /// <summary>
        /// Gets the total number of cards in the deck.
        /// </summary>
        /// <returns>The number of cards available.</returns>
        public int GetNumberOfCardsInDeck()
        {
            return _deck?.GetNumberOfCardsInDeck() ?? 0;
        }

        /// <summary>
        /// Initializes the deck controller with a specific deck type.
        /// </summary>
        /// <param name="deckName">The name/type of deck to initialize.</param>
        /// <exception cref="InvalidOperationException">Thrown if initialization fails.</exception>
        public void Initialize(string deckName)
        {
            _logger.LogInformation($"Initializing deck controller with deck type: {deckName}");
            try
            {
                InitializeDeckModel(deckName);
                _logger.LogInformation($"Deck controller initialized successfully - {GetNumberOfCardsInDeck()} cards available");
            }
            catch (Exception e)
            {
                _logger.LogError(e, "Failed to initialize deck controller");
                throw new InvalidOperationException("Deck initialization failed", e);
            }
        }

        /// <summary>
        /// Internal method to create and initialize the deck model.
        /// </summary>
        /// <param name="deckName">The name/type of the deck.</param>
        private void InitializeDeckModel(string deckName)
        {
            _logger.LogDebug($"Creating new DeckModel for deck type: {deckName}");
            _deck = new DeckModel(_logger);
            _deck.Initialize(deckName);
            _logger.LogDebug($"DeckModel created with {_deck.GetNumberOfCardsInDeck()} cards");
        }

        /// <summary>
        /// Gets a random card back image path from the deck.
        /// </summary>
        /// <returns>The path to a random card back image.</returns>
        public string GetRandomCardBackImage()
        {
            if (_deck == null)
            {
                _logger.LogWarning("Deck not initialized, cannot get card back image");
                return "images/playing_cards_classic/b1fh.png";
            }
            return _deck.GetRandomCardBackImage();
        }

        /// <summary>
        /// Gets a specific card back image path based on design name.
        /// </summary>
        /// <param name="cardBackName">The name of the card back design.</param>
        /// <returns>The path to the specified card back image.</returns>
        public string GetCardBackImage(string cardBackName)
        {
            if (_deck == null)
            {
                _logger.LogWarning("Deck not initialized, cannot get card back image");
                return "images/playing_cards_classic/b1fh.png";
            }
            return _deck.GetCardBackImage(cardBackName);
        }
    }
}

namespace LimeriCardsSharp.Controllers
{
    public class DeckController
    {
        // Methods to manage the deck
    }
}
