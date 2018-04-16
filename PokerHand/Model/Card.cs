using System;
namespace PokerHand.Model
{
    /**
     * A playing card.
     *
     *  Value is a number from 2-10, 11(J), 12(Q), 13(K), or 14(A). Suit is hearts, spades, clubs, or diamonds
     */
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
