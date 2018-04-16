using System;
namespace PokerHand.Model
{
    public class Card
    {
        public CardSuit Suit { get; private set; }
        public CardValue Value { get; private set; }

        public Card(CardSuit suit, CardValue value)
        {
            Suit = suit;
            Value = value;
        }
    }
}
