using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Poker;

namespace PokerTest
{
    [TestClass]
    public class HandToStringTest
    {
        [TestMethod]
        public void TestEmptyHand()
        {
            Hand hand = new Hand(new List<ICard>());

            Assert.AreEqual(string.Empty, hand.ToString(), "ToString() method in class Hand is not working correctly.");
        }

        [TestMethod]
        public void TestValidHand()
        {
            Card cardOne = new Card(CardFace.King, CardSuit.Diamonds);
            Card cardTwo = new Card(CardFace.Jack, CardSuit.Hearts);
            Card cardThree = new Card(CardFace.Five, CardSuit.Spades);
            Card cardFour = new Card(CardFace.Ace, CardSuit.Clubs);
            Card cardFive = new Card(CardFace.Ten, CardSuit.Clubs);

            IList<ICard> cards = new List<ICard>();
            cards.Add(cardOne);
            cards.Add(cardTwo);
            cards.Add(cardThree);
            cards.Add(cardFour);
            cards.Add(cardFive);
            Hand hand = new Hand(cards);

            Assert.AreEqual("King♦Jack♥5♠Ace♣10♣", hand.ToString(), "ToString() method in class Hand is not working correctly.");
        }

        [TestMethod]
        public void TestSameCards()
        {
            Card card = new Card(CardFace.Ten, CardSuit.Hearts);

            IList<ICard> cards = new List<ICard>();
            for (int i = 0; i < 5; i++)
            {
                cards.Add(card);
            }

            Hand hand = new Hand(cards);

            Assert.AreEqual("10♥10♥10♥10♥10♥", hand.ToString(), "ToString() method in class Hand is not working correctly.");
        }
    }
}
