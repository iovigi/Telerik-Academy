namespace Santase.Test
{
    using NUnit.Framework;
    using Santase.Logic.Cards;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    [TestFixture]
    public class DeckTest
    {
        [Test]
        public void TestDeck()
        {
            Deck cards = new Deck();
            Assert.AreEqual(24, cards.CardsLeft);
        }

        [Test]
        public void TestDeckCountLeft()
        {
            Deck deck = new Deck();
            Card nextCard;

            for (int i = 0; i < 15; i++)
            {
                nextCard = deck.GetNextCard();
            }

            Assert.AreEqual(9, deck.CardsLeft);
        }

        [Test]
        public void TestChangeDeckTrump()
        {
            Card trumpCard = new Card(CardSuit.Heart, CardType.King);
            Deck deck = new Deck();

            deck.ChangeTrumpCard(trumpCard);

            Assert.AreEqual(trumpCard, deck.GetTrumpCard);
            Assert.AreEqual(true, deck.GetTrumpCard.Equals(trumpCard));
        }

        [TestCase(1)]
        [TestCase(15)]
        [TestCase(16)]
        [TestCase(17)]
        [TestCase(21)]
        public void TestCountParameterizedMethods(int drawCards)
        {
            Deck deck = new Deck();
            IList<Card> cards = new List<Card>();
            const int DECK_MAX_LENGTH = 24;

            for (int i = 0; i < drawCards; i++)
            {
                Card nextCand = deck.GetNextCard();
                cards.Add(nextCand);
            }

            Assert.AreEqual(DECK_MAX_LENGTH - drawCards, deck.CardsLeft);
            Assert.AreEqual(drawCards, cards.Count);
        }
    }
}
