namespace NavBlue_PlayingCardLibrary
{
    /// <summary>
    /// Card class that holds a card with a dedicated Suit and Rank
    /// </summary>
    public class Card
    {

        public Rank rank { get; }
        public Suit suit { get; }

        public Card(Suit suit, Rank rank)
        {
            this.rank = rank;
            this.suit = suit;
        }

        /// <summary>
        /// Compare playedCard's rank to compareCard's rank.
        /// </summary>
        /// <returns>
        /// Returns 1 if playedCard beats compareCard, 0 if cards match, -1 if compareCard is stronger than playedCard.
        /// </returns>
        public int DoesCardBeatRank(Card playedCard, Card compareCard)
        {

            if (playedCard.rank > compareCard.rank)
            {
                return 1;
            } else if (playedCard.rank == compareCard.rank)
            {
                return 0;
            } else
            {
                return -1;
            }
        }

        /// <summary>
        /// Compare playedCard's suit to compareCard's suit.
        /// </summary>
        /// <returns>
        /// Returns 1 if playedCard beats compareCard, 0 if cards match, -1 if compareCard is stronger than playedCard.
        /// </returns>
        public int DoesCardBeatSuit(Card playedCard, Card compareCard)
        {
            if (playedCard.suit > compareCard.suit)
            {
                return 1;
            }
            else if (playedCard.suit == compareCard.suit)
            {
                return 0;
            }
            else
            {
                return -1;
            }
        }

    }
}
