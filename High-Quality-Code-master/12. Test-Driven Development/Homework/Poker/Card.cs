using System;

// Implement ICard interface to class Card
// Create method ToString based on class CardToStringTest
namespace Poker
{
    public class Card : ICard
    {
        public CardFace Face { get; private set; }

        public CardSuit Suit { get; private set; }

        public Card(CardFace face, CardSuit suit)
        {
            this.Face = face;
            this.Suit = suit;
        }

        public override string ToString()
        { 
            string cardToString = "";
            if ((int)this.Face <= 10)
            {
                cardToString += (int)this.Face;
            }
            else
            {
                cardToString += this.Face.ToString();
            }

            switch (this.Suit)
            {
                case CardSuit.Clubs:
                    cardToString += "♣";
                    break;
                case CardSuit.Diamonds:
                    cardToString += "♦";
                    break;
                case CardSuit.Hearts:
                    cardToString += "♥";
                    break;
                case CardSuit.Spades:
                    cardToString += "♠";
                    break;
            }

            return cardToString;
        }

        public override bool Equals(object obj)
        {
            var card = obj as Card;

            if (card == null)
            {
                return false;
            }

            var face = Face.Equals(card.Face);

            return face && Suit.Equals(card.Suit);
        }
    }
}
