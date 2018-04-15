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
    }
}
