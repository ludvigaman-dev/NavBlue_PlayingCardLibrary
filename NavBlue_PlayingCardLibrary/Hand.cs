using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NavBlue_PlayingCardLibrary
{
    public class Hand
    {
        public int id { get; set; }
        public List<Card> cards { get; set; }

        public Hand(int id)
        {
            this.id = id;
            cards = new List<Card>();
        }

        /// <summary>
        /// Return the power (int) of the hand's strengh in Ranks
        /// </summary>
        /// <returns></returns>
        public int GetHandRankStrength()
        {
            var strength = 0;
            foreach(Card card in cards)
            {
                strength += (int)card.rank;
            }
            return strength;
        }

        /// <summary>
        /// Return the power (int) of the hand's strengh in Suits
        /// </summary>
        /// <returns></returns>
        public int GetHandSuitStrength()
        {
            var strength = 0;
            foreach (Card card in cards)
            {
                strength += (int)card.suit;
            }
            return strength;
        }
    }
}
