using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NavBlue_PlayingCardLibrary
{
    public class Deck
    {
        public List<Card> cards { get; set; }

        /// <summary>
        /// Created a standard 52 card deck, without jokers
        /// </summary>
        /// <returns></returns>
        public Deck Create52Deck()
        {
            cards = new List<Card>();

            foreach (Suit suit in Enum.GetValues(typeof(Suit)))
            {
                foreach (Rank rank in Enum.GetValues(typeof(Rank)))
                {
                    cards.Add(new Card(suit, rank));
                }
            }

            return this;
        }

        /// <summary>
        /// Shuffles the deck 
        /// </summary>
        /// <returns></returns>
        public List<Card> ShuffleDeck()
        {
            var ran = new Random();
            return cards.OrderBy(card => ran.Next()).ToList();
        }

        /// <summary>
        /// Sorts deck by Suit then Rank
        /// </summary>
        /// <returns></returns>
        public List<Card> SortDeckClassic()
        {
            var sortedDeck = cards.OrderBy(c => c.suit).ThenBy(c => c.rank);
            return sortedDeck.ToList();
        }

        /// <summary>
        /// Draws a card from the top if the deck
        /// </summary>
        /// <returns></returns>
        public Card DrawTop()
        {
            var returnCard = cards[0];
            cards.Remove(returnCard);
            return returnCard;
        }

        /// <summary>
        /// Draws a card from the bottom of the deck
        /// </summary>
        /// <returns></returns>
        public Card DrawBottom()
        {
            var returnCard = cards[cards.Count - 1];
            cards.Remove(returnCard);
            return returnCard;
        }

        /// <summary>
        /// Creates a single hand with given Id and number of cards in the hand
        /// </summary>
        /// <param name="id"></param>
        /// <param name="numberOfCards"></param>
        /// <returns></returns>
        public Hand CreateHand(int id, int numberOfCards)
        {
            Hand hand = new Hand(id);
            for (int i = 0; i < numberOfCards; i++)
            {
                hand.cards.Add(DrawTop());
            }

            return hand;
        }

        /// <summary>
        /// Create X number of hands, containing Y number of cards.
        /// </summary>
        /// <param name="numberOfHands"></param>
        /// <param name="cardsPerHand"></param>
        /// <returns></returns>
        public List<Hand> CreateEqualHands(int numberOfHands, int cardsPerHand)
        {
            List<Hand> hands = new List<Hand>();

            for (int i = 0; i < numberOfHands; i++)
            {
                Hand h = CreateHand(i, cardsPerHand);
                hands.Add(h);
            }

            return hands;

        }

    }
}
