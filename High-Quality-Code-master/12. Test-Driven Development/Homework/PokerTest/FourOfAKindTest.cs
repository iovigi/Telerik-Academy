using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Poker;

namespace PokerTest
{
    [TestClass]
    public class FourOfAKindTest
    {
        [TestMethod]
        public void TestIsFourOfAKindValid()
        {
            Card cardOne = new Card(CardFace.Ace, CardSuit.Diamonds);
            Card cardTwo = new Card(CardFace.Ace, CardSuit.Hearts);
            Card cardThree = new Card(CardFace.Ace, CardSuit.Spades);
            Card cardFour = new Card(CardFace.Ace, CardSuit.Clubs);
            Card cardFive = new Card(CardFace.Eight, CardSuit.Clubs);
            IList<ICard> cards = new List<ICard>();
            PokerHandsChecker pokerHandsChecker = new PokerHandsChecker();

            cards.Add(cardOne);
            cards.Add(cardTwo);
            cards.Add(cardThree);
            cards.Add(cardFour);
            cards.Add(cardFive);
            Hand hand = new Hand(cards);

            Assert.AreEqual(true, pokerHandsChecker.IsFourOfAKind(hand), "IsFourOfAKind()  is not working correctly.");
        }

        [TestMethod]
        public void TestIsFourOfAKindLessCards()
        {
            Card cardOne = new Card(CardFace.Two, CardSuit.Diamonds);
            Card cardTwo = new Card(CardFace.Two, CardSuit.Hearts);
            Card cardThree = new Card(CardFace.Two, CardSuit.Spades);
            IList<ICard> cards = new List<ICard>();
            PokerHandsChecker pokerHandsChecker = new PokerHandsChecker();

            cards.Add(cardOne);
            cards.Add(cardTwo);
            cards.Add(cardThree);
            Hand hand = new Hand(cards);

            Assert.AreEqual(false, pokerHandsChecker.IsFourOfAKind(hand), "IsFourOfAKind() is not working correctly.");
        }

        [TestMethod]
        public void TestIsFourOfAKind()
        {
            Card cardOne = new Card(CardFace.Ace, CardSuit.Diamonds);
            Card cardTwo = new Card(CardFace.Ace, CardSuit.Hearts);
            Card cardThree = new Card(CardFace.Ace, CardSuit.Spades);
            Card cardFour = new Card(CardFace.Ten, CardSuit.Clubs);
            Card cardFive = new Card(CardFace.Ten, CardSuit.Spades);
            IList<ICard> cards = new List<ICard>();
            PokerHandsChecker pokerHandsChecker = new PokerHandsChecker();

            cards.Add(cardOne);
            cards.Add(cardTwo);
            cards.Add(cardThree);
            cards.Add(cardFour);
            cards.Add(cardFive);
            Hand hand = new Hand(cards);

            Assert.AreEqual(false, pokerHandsChecker.IsFourOfAKind(hand), "IsFourOfAKind() is not working correctly.");
        }

        [TestMethod]
        public void TestIsFourOfAKindSameCards()
        {
            Card cardOne = new Card(CardFace.Two, CardSuit.Diamonds);
            Card cardTwo = new Card(CardFace.Ace, CardSuit.Hearts);
            Card cardThree = new Card(CardFace.Ace, CardSuit.Spades);
            Card cardFour = new Card(CardFace.Ace, CardSuit.Clubs);
            Card cardFive = new Card(CardFace.Ace, CardSuit.Clubs);
            IList<ICard> cards = new List<ICard>();
            PokerHandsChecker pokerHandsChecker = new PokerHandsChecker();

            cards.Add(cardOne);
            cards.Add(cardTwo);
            cards.Add(cardThree);
            cards.Add(cardFour);
            cards.Add(cardFive);
            Hand hand = new Hand(cards);

            Assert.AreEqual(false, pokerHandsChecker.IsFourOfAKind(hand), "IsFourOfAKind() is not working correctly.");
        }
    }
}
