using System;
namespace PokerHand
{
    public class Card
    {
        public CardSuit Suit { get; private set; }
        public CardValue Value { get; private set; }

        public Card(CardSuit suit, CardValue rank)
        {
            Suit = suit;
            Value = rank;
        }
    }
}
