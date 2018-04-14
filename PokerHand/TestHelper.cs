using System;
using System.Collections.Generic;
using System.Linq;
namespace CardGame
{
    public class TestHelper
    {
        public static Hand GoodFlushHand() {
            List<Card> list = new List<Card> {
                new Card(CardSuit.Clubs, CardRank.Nine),
                new Card(CardSuit.Clubs, CardRank.Ace),
                new Card(CardSuit.Clubs, CardRank.King),
                new Card(CardSuit.Clubs, CardRank.Two),
                new Card(CardSuit.Clubs, CardRank.Ten)
            };
            Hand hand = new Hand(list);

            return hand;
        }

        public static Hand GoodThreeOfAKindHand() {
            List<Card> list = new List<Card> {
                new Card(CardSuit.Hearts, CardRank.Ace),
                new Card(CardSuit.Clubs, CardRank.Ace),
                new Card(CardSuit.Diamonds, CardRank.Ace),
                new Card(CardSuit.Clubs, CardRank.Eight),
                new Card(CardSuit.Clubs, CardRank.Ten)
            };
            Hand hand = new Hand(list);
            return hand;
        }

        public static Hand GoodOnPairHand()
        {
            List<Card> list = new List<Card> {
                new Card(CardSuit.Hearts, CardRank.Ace),
                new Card(CardSuit.Clubs, CardRank.Ace),
                new Card(CardSuit.Diamonds, CardRank.Nine),
                new Card(CardSuit.Clubs, CardRank.Eight),
                new Card(CardSuit.Clubs, CardRank.Ten)
            };
            Hand hand = new Hand(list);
            return hand;
        }

        public static Hand GoodHighCardHand()
        {
            List<Card> list = new List<Card> {
                new Card(CardSuit.Hearts, CardRank.Ace),
                new Card(CardSuit.Clubs, CardRank.Three),
                new Card(CardSuit.Diamonds, CardRank.Nine),
                new Card(CardSuit.Clubs, CardRank.Eight),
                new Card(CardSuit.Clubs, CardRank.Ten)
            };
            Hand hand = new Hand(list);
            return hand;
        }
    }
}
