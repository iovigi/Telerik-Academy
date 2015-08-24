using System;
using System.Collections.Generic;

// Implement IHand interface to class Hand
// Create method ToString and OrderHand based on classes HandToStringTest and HandOrderHandTest
namespace Poker
{
    public class Hand : IHand
    {
        public IList<ICard> Cards { get; private set; }

        public Hand(IList<ICard> cards)
        {
            this.Cards = cards;
        }

        public override string ToString()
        {
            string handToString = string.Empty;

            foreach (var card in this.Cards)
            {
                handToString += card.ToString();
            }

            return handToString;
        }
    }
}
