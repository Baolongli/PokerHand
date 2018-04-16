using NUnit.Framework;
using System;
using System.Collections.Generic;

using PokerHand.Model;
using PokerHand.Utility;

namespace PokerHand
{
    [TestFixture()]
    public class EvaluatorTest
    {
        [Test()]
        public void TestGetWinners()
        {
            Player player1 = new Player("Joe");
            Hand hand1 = new Hand(new List<Card>
            {
                new Card(CardSuit.Hearts, CardValue.Three),
                new Card(CardSuit.Hearts, CardValue.Six),
                new Card(CardSuit.Hearts, CardValue.Eight),
                new Card(CardSuit.Hearts, CardValue.Jack),
                new Card(CardSuit.Hearts, CardValue.King)
            });
            player1.Hand = hand1;

            Player player2 = new Player("Bob");
            Hand hand2 = new Hand(new List<Card>
            {
                new Card(CardSuit.Hearts, CardValue.Ace),
                new Card(CardSuit.Clubs, CardValue.Ace),
                new Card(CardSuit.Diamonds, CardValue.Ace),
                new Card(CardSuit.Clubs, CardValue.Eight),
                new Card(CardSuit.Clubs, CardValue.Ten)
            });
            player2.Hand = hand2;

            Player player3 = new Player("Jen");
            Hand hand3 = new Hand(new List<Card>
            {
                new Card(CardSuit.Clubs, CardValue.Nine),
                new Card(CardSuit.Clubs, CardValue.Ace),
                new Card(CardSuit.Clubs, CardValue.King),
                new Card(CardSuit.Clubs, CardValue.Queen),
                new Card(CardSuit.Clubs, CardValue.Ten)
            });
            player3.Hand = hand3;

            List<Player> players = new List<Player> { player1, player2, player3 };

            List<Player> winners = Evaluator.GetWinners(players);
            Assert.AreEqual(1, winners.Count);
            Assert.AreEqual(winners[0].Name, "Jen");
        }


        [Test()]
        public void TestGetWinners_WithOneNullHandPlayer()
        {
            Player player1 = new Player("Joe");

            Player player2 = new Player("Bob");
            Hand hand2 = new Hand(new List<Card>
            {
                new Card(CardSuit.Hearts, CardValue.Ace),
                new Card(CardSuit.Clubs, CardValue.Ace),
                new Card(CardSuit.Diamonds, CardValue.Ace),
                new Card(CardSuit.Clubs, CardValue.Eight),
                new Card(CardSuit.Clubs, CardValue.Ten)
            });
            player2.Hand = hand2;

            Player player3 = new Player("Jen");
            Hand hand3 = new Hand(new List<Card>
            {
                new Card(CardSuit.Clubs, CardValue.Nine),
                new Card(CardSuit.Clubs, CardValue.Ace),
                new Card(CardSuit.Clubs, CardValue.King),
                new Card(CardSuit.Clubs, CardValue.Queen),
                new Card(CardSuit.Clubs, CardValue.Ten)
            });
            player3.Hand = hand3;

            List<Player> players = new List<Player> { player1, player2, player3 };

            List<Player> winners = Evaluator.GetWinners(players);
            Assert.AreEqual(1, winners.Count);
            Assert.AreEqual(winners[0].Name, "Jen");
        }

        [Test()]
        public void TestGetWinners_AllPlayerHaveNullHand()
        {
            Player player1 = new Player("Joe");
            Player player2 = new Player("Bob");
            Player player3 = new Player("Jen");

            List<Player> players = new List<Player> { player1, player2, player3 };

            List<Player> winners = Evaluator.GetWinners(players);
            Assert.AreEqual(0, winners.Count);
        }

        [Test()]
        public void TestGetWinners_WithEmptyPlayerList()
        {
            List<Player> players = new List<Player> {};
            List<Player> winners = Evaluator.GetWinners(players);
            Assert.AreEqual(0, winners.Count);
        }

        [Test()]
        public void TestGetWinners_TwoWinners()
        {
            Player player1 = new Player("Joe");
            Hand hand1 = new Hand(new List<Card>
            {
                new Card(CardSuit.Hearts, CardValue.Three),
                new Card(CardSuit.Hearts, CardValue.Six),
                new Card(CardSuit.Hearts, CardValue.Eight),
                new Card(CardSuit.Hearts, CardValue.Jack),
                new Card(CardSuit.Hearts, CardValue.King)
            });
            player1.Hand = hand1;

            Player player2 = new Player("Bob");
            Hand hand2 = new Hand(new List<Card>
            {
                new Card(CardSuit.Hearts, CardValue.Ace),
                new Card(CardSuit.Clubs, CardValue.Ace),
                new Card(CardSuit.Diamonds, CardValue.Ace),
                new Card(CardSuit.Clubs, CardValue.Eight),
                new Card(CardSuit.Clubs, CardValue.Ten)
            });
            player2.Hand = hand2;

            Player player3 = new Player("Jen");
            Hand hand3 = new Hand(new List<Card>
            {
                new Card(CardSuit.Clubs, CardValue.Three),
                new Card(CardSuit.Clubs, CardValue.Six),
                new Card(CardSuit.Clubs, CardValue.Eight),
                new Card(CardSuit.Clubs, CardValue.Jack),
                new Card(CardSuit.Clubs, CardValue.King)
            });
            player3.Hand = hand3;

            List<Player> players = new List<Player> { player1, player2, player3 };

            List<Player> winners = Evaluator.GetWinners(players);
            Assert.AreEqual(2, winners.Count);
            Assert.AreEqual(winners[0].Hand.GetHandType(), HandType.Flush);
            Assert.AreEqual(winners[1].Hand.GetHandType(), HandType.Flush);
        }

        [Test()]
        public void TestGetWinners_WithAInvalidPlayer()
        {
            Player player1 = null;

            Player player2 = new Player("Bob");
            Hand hand2 = new Hand(new List<Card>
            {
                new Card(CardSuit.Hearts, CardValue.Ace),
                new Card(CardSuit.Clubs, CardValue.Ace),
                new Card(CardSuit.Diamonds, CardValue.Ace),
                new Card(CardSuit.Clubs, CardValue.Eight),
                new Card(CardSuit.Clubs, CardValue.Ten)
            });
            player2.Hand = hand2;

            Player player3 = new Player("Jen");
            Hand hand3 = new Hand(new List<Card>
            {
                new Card(CardSuit.Clubs, CardValue.Three),
                new Card(CardSuit.Clubs, CardValue.Six),
                new Card(CardSuit.Clubs, CardValue.Eight),
                new Card(CardSuit.Clubs, CardValue.Jack),
                new Card(CardSuit.Clubs, CardValue.King)
            });
            player3.Hand = hand3;

            List<Player> players = new List<Player> { player1, player2, player3 };

            List<Player> winners = Evaluator.GetWinners(players);
            Assert.AreEqual(1, winners.Count);
            Assert.AreEqual(winners[0].Hand.GetHandType(), HandType.Flush);
            Assert.AreEqual(winners[0].Name, "Jen");
        }
    }
}
