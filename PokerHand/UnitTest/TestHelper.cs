using System;
using System.Collections.Generic;
using System.Linq;

using PokerHand.Model;

namespace PokerHand
{
    public class TestHelper
    {
        public static Hand GoodFlushHand() {
            List<Card> list = new List<Card> {
                new Card(CardSuit.Clubs, CardValue.Nine),
                new Card(CardSuit.Clubs, CardValue.Ace),
                new Card(CardSuit.Clubs, CardValue.King),
                new Card(CardSuit.Clubs, CardValue.Two),
                new Card(CardSuit.Clubs, CardValue.Ten)
            };
            Hand hand = new Hand(list);

            return hand;
        }

        public static Hand GoodThreeOfAKindHand() {
            List<Card> list = new List<Card> {
                new Card(CardSuit.Hearts, CardValue.Ace),
                new Card(CardSuit.Clubs, CardValue.Ace),
                new Card(CardSuit.Diamonds, CardValue.Ace),
                new Card(CardSuit.Clubs, CardValue.Eight),
                new Card(CardSuit.Clubs, CardValue.Ten)
            };
            Hand hand = new Hand(list);
            return hand;
        }

        public static Hand GoodOnPairHand()
        {
            List<Card> list = new List<Card> {
                new Card(CardSuit.Hearts, CardValue.Ace),
                new Card(CardSuit.Clubs, CardValue.Ace),
                new Card(CardSuit.Diamonds, CardValue.Nine),
                new Card(CardSuit.Clubs, CardValue.Eight),
                new Card(CardSuit.Clubs, CardValue.Ten)
            };
            Hand hand = new Hand(list);
            return hand;
        }

        public static Hand GoodHighCardHand()
        {
            List<Card> list = new List<Card> {
                new Card(CardSuit.Hearts, CardValue.Ace),
                new Card(CardSuit.Clubs, CardValue.Three),
                new Card(CardSuit.Diamonds, CardValue.Nine),
                new Card(CardSuit.Clubs, CardValue.Eight),
                new Card(CardSuit.Clubs, CardValue.Ten)
            };
            Hand hand = new Hand(list);
            return hand;
        }
    }
}
