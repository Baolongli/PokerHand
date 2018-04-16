using NUnit.Framework;
using System;

using PokerHand.Model;
using PokerHand.Exceptions;

namespace PokerHand
{
    [TestFixture()]
    public class PlayerTest
    {
        [Test()]
        public void TestPlayerName()
        {
            Player player = new Player("Bob");
            Assert.AreEqual(player.Name, "Bob");
        }
        public void TestPlayerHand_nullHand()
        {
            Player player = new Player("Bob");
            Assert.AreEqual(player.Hand,null);
        }
        public void TestPlayerHand_ValidHand()
        {
            Player player = new Player("Bob");
            Hand hand = TestHelper.GoodFlushHand();
            player.Hand = hand;
            Assert.AreEqual(player.Hand, hand);
        }
        //---------------CompareTo----------
        public void TestCompareTo()
        {
            Player player1 = new Player("Bob");
            Hand hand = TestHelper.GoodFlushHand();
            player1.Hand = hand;

            Player player2 = new Player("Jen");
            Hand hand2 = TestHelper.GoodHighCardHand();
            player2.Hand = hand2;

            int result = player1.CompareTo(player2);
            Assert.AreEqual(result, 1);
        }

        public void TestCompareTo_BothHaveInvalidHands()
        {
            Player player1 = new Player("Bob");
            Player player2 = new Player("Jen");

            int result;
            Assert.Throws(typeof(InvalidHandException),
                          delegate { result = player1.CompareTo( player2); }
                         );
        }
        public void TestCompareTo_Player1HasNullHand()
        {
            Player player1 = new Player("Bob");

            Player player2 = new Player("Jen");
            Hand hand2 = TestHelper.GoodHighCardHand();
            player2.Hand = hand2;

            int result = player1.CompareTo(player2);
            Assert.AreEqual(result, -1);
        }
        public void TestCompareTo_Player2HasNullHand()
        {
            Player player1 = new Player("Bob");
            Hand hand = TestHelper.GoodFlushHand();
            player1.Hand = hand;

            Player player2 = new Player("Jen");

            int result = player1.CompareTo(player2);
            Assert.AreEqual(result, 1);
        }
    }
}
