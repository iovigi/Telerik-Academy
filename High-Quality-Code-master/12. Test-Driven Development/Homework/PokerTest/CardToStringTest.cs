using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Poker;

namespace PokerTest
{
    [TestClass]
    public class CardToStringTest
    {
        [TestMethod]
        public void TestAceHearts()
        {
            Card card = new Card(CardFace.Ace, CardSuit.Hearts);

            Assert.AreEqual("Ace♥", card.ToString(), "ToString() is not working correctly.");
        }

        [TestMethod]
        public void TestKingClubs()
        {
            Card card = new Card(CardFace.King, CardSuit.Clubs);

            Assert.AreEqual("King♣", card.ToString(), "ToString() is not working correctly.");
        }

        [TestMethod]
        public void TestAceDiamonds()
        {
            Card card = new Card(CardFace.Ace, CardSuit.Diamonds);

            Assert.AreEqual("Ace♦", card.ToString(), "ToString() is not working correctly.");
        }

        [TestMethod]
        public void TestJackHearts()
        {
            Card card = new Card(CardFace.Jack, CardSuit.Hearts);

            Assert.AreEqual("Jack♥", card.ToString(), "ToString() is not working correctly.");
        }

        [TestMethod]
        public void TestTenSpades()
        {
            Card card = new Card(CardFace.Ten, CardSuit.Spades);

            Assert.AreEqual("10♠", card.ToString(), "ToString() is not working correctly.");
        }
    }
}
