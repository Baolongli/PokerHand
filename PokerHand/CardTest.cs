using NUnit.Framework;
using System;
namespace PokerHand
{
    [TestFixture()]
    public class CardTest
    {
        [Test()]
        public void TestCardRank()
        {
            Card card = new Card(CardSuit.Clubs, CardRank.Ace);
            Assert.AreEqual(card.Rank, CardRank.Ace);
        }
        [Test()]
        public void TestCardSuit()
        {
            Card card = new Card(CardSuit.Clubs, CardRank.Ace);
            Assert.AreEqual(card.Suit, CardSuit.Clubs);
        }
    }
}
