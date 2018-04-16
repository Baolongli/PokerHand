using NUnit.Framework;
using System;

using PokerHand.Model;

namespace PokerHand
{
    [TestFixture()]
    public class CardTest
    {
        [Test()]
        public void TestCardValue()
        {
            Card card = new Card(CardSuit.Clubs, CardValue.Ace);
            Assert.AreEqual(card.Value, CardValue.Ace);
        }
        [Test()]
        public void TestCardSuit()
        {
            Card card = new Card(CardSuit.Clubs, CardValue.Ace);
            Assert.AreEqual(card.Suit, CardSuit.Clubs);
        }
    }
}
