namespace LimeriCardsSharp
{
    /// <summary>
    /// Global constants for the Limeri Cards application.
    /// Includes game settings, card properties, and table positions.
    /// </summary>
    public static class Constants
    {
        // ===== Pinochle Game Constants =====
        /// <summary>
        /// The initial number of players in a Pinochle game.
        /// </summary>
        public const int PINOCHLE_INITIAL_PLAYERS = 4;

        /// <summary>
        /// The initial hand size for each player in Pinochle.
        /// </summary>
        public const int PINOCHLE_INITIAL_HAND_SIZE = 12;

        /// <summary>
        /// The total size of a Pinochle deck (two 24-card decks).
        /// </summary>
        public const int PINOCHLE_DECK_SIZE = 48;

        // ===== Table Positions =====
        /// <summary>
        /// Table position identifiers.
        /// </summary>
        public enum TABLE_POS {North, South, East, West}

//        public const string TABLE_POS_WEST = "West";

        /// <summary>
        /// Table position identifier for the North position.
        /// </summary>
//        public const string TABLE_POS_NORTH = "North";

        /// <summary>
        /// Table position identifier for the East position.
        /// </summary>
//        public const string TABLE_POS_EAST = "East";

        /// <summary>
        /// Table position identifier for the South position.
        /// </summary>
//        public const string TABLE_POS_SOUTH = "South";

        // ===== Card Suits =====
        /// <summary>
        /// Card suit identifiers.
        /// </summary>
        public enum SUIT {Spades, Hearts, Diamonds, Clubs}

        /// <summary>
        /// Card suit identifier for Clubs.
        /// </summary>
//        public const string SUIT_CLUBS = "Clubs";

        /// <summary>
        /// Card suit identifier for Diamonds.
        /// </summary>
//        public const string SUIT_DIAMONDS = "Diamonds";

        /// <summary>
        /// Card suit identifier for Hearts.
        /// </summary>
//        public const string SUIT_HEARTS = "Hearts";

        /// <summary>
        /// Card suit identifier for Spades.
        /// </summary>
//        public const string SUIT_SPADES = "Spades";

        // ===== Card Ranks =====
        /// <summary>
        /// Card rank identifier for Nine.
        /// </summary>
        public const string RANK_NINE = "9";

        /// <summary>
        /// Card rank identifier for Ten.
        /// </summary>
        public const string RANK_TEN = "10";

        /// <summary>
        /// Card rank identifier for Jack.
        /// </summary>
        public const string RANK_JACK = "J";

        /// <summary>
        /// Card rank identifier for Queen.
        /// </summary>
        public const string RANK_QUEEN = "Q";

        /// <summary>
        /// Card rank identifier for King.
        /// </summary>
        public const string RANK_KING = "K";

        /// <summary>
        /// Card rank identifier for Ace.
        /// </summary>
        public const string RANK_ACE = "A";
    }
}
