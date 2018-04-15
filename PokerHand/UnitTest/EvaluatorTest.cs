using NUnit.Framework;
using System;
using System.Collections.Generic;

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
                new Card(CardSuit.Hearts, CardRank.Three),
                new Card(CardSuit.Hearts, CardRank.Six),
                new Card(CardSuit.Hearts, CardRank.Eight),
                new Card(CardSuit.Hearts, CardRank.Jack),
                new Card(CardSuit.Hearts, CardRank.King)
            });
            player1.Hand = hand1;

            Player player2 = new Player("Bob");
            Hand hand2 = new Hand(new List<Card>
            {
                new Card(CardSuit.Hearts, CardRank.Ace),
                new Card(CardSuit.Clubs, CardRank.Ace),
                new Card(CardSuit.Diamonds, CardRank.Ace),
                new Card(CardSuit.Clubs, CardRank.Eight),
                new Card(CardSuit.Clubs, CardRank.Ten)
            });
            player2.Hand = hand2;

            Player player3 = new Player("Jen");
            Hand hand3 = new Hand(new List<Card>
            {
                new Card(CardSuit.Clubs, CardRank.Nine),
                new Card(CardSuit.Clubs, CardRank.Ace),
                new Card(CardSuit.Clubs, CardRank.King),
                new Card(CardSuit.Clubs, CardRank.Queen),
                new Card(CardSuit.Clubs, CardRank.Ten)
            });
            player3.Hand = hand3;

            List<Player> players = new List<Player> { player1, player2, player3 };

            List<Player> winners = Evaluator.GetWinners(players);
            Assert.AreEqual(1, winners.Count);
            Assert.AreEqual(winners[0].Name, "Jen");
        }
    }
}
