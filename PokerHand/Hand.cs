using System;
using System.Collections.Generic;
using System.Linq;

namespace CardGame
{
    public class Hand
    {
        public List<Card> Cards { get; private set; }

        public Hand(List<Card> cards)
        {
            if (cards.Count != 5) throw new Exception();
            Cards = cards;
            Sort();
        }
        /**
         * 1. Sort all the card in descending order.
         * 2. Sort cards with count of the cards with same rank in descending order.
         * 3. If cards are A,5,4,3,2, the oder should be 5,4,3,2,1
         */
        private void Sort() {
            Cards = Cards.OrderByDescending(c => c.Rank)
                .OrderByDescending(c => Cards.Where(c1 => c1.Rank == c.Rank).Count())
                .ToList();
            if( Cards[0].Rank == CardRank.Ace && Cards[1].Rank == CardRank.Five && Cards[2].Rank == CardRank.Four
               && Cards[3].Rank == CardRank.Three && Cards[4].Rank == CardRank.Two) {
                Cards = new List<Card> {
                    Cards[1],Cards[2],Cards[3],Cards[4],Cards[0]
                };
            }
        }

        public HandType GetHandType() {
            
            if (IsFlush()) return HandType.Flush;
            if (IsThreeOfAKind()) return HandType.ThreeOfKind;
            if (IsOnePair()) return HandType.OnePair;

            return HandType.HighCard;
        }
        /**
         * Check if it is a Flush.
         * 
         * @return   If it is Flush, then return true, otherwise return false.
         */
        public bool IsFlush() {
            return Cards.GroupBy(card => card.Suit).Count() == 1;
        }

        /**
         * Check if it is a three-of-a-kind.
         * 
         * @return   If it is three-of-a-kind or four-of-a-kind, then return true, otherwise return false.
         * TODO: add four-of-a-kind
         */
        public bool IsThreeOfAKind() {
            return Cards.GroupBy(card => card.Rank).Any(group => group.Count() >= 3);
        }

        /**
         * Check if it is a pair.
         * 
         * @return   If it is a pair or two pairs, then return true, otherwise return false.
         * TODO: add tow pairs
         */
        public bool IsOnePair() {
            //return Cards.GroupBy(card => card.Rank)
                                            //.Count(group => group.Count() == 2) == 1;
            return Cards.GroupBy(card => card.Rank)
                                            .Any(group => group.Count() == 2);
        }


        /**
         * Get the value of the card (2-10, J, Q, K, A).
         * 
         * @param    other   The Hand to compare to.
         * @return           An integer. If 0, then they are equal, -1 if the current hard (the one calling the method) is weaker than the other, and 1 if the hand calling the method is better.
         */
        public int CompareTo(Hand other){

            if (other == null) return 1;

            HandType thisHandType = this.GetHandType();
            HandType otherHandType = other.GetHandType();

            if (thisHandType > otherHandType) return 1; //this win
            if (thisHandType < otherHandType) return -1; //other win

            //If they are same hand type, compare these two hands in detail
            for (int i = 0; i < this.Cards.Count; i++)
            {
                CardRank thisRank = this.Cards[i].Rank;
                CardRank otherRank = other.Cards[i].Rank;
                if (thisRank > otherRank) return 1;
                if (thisRank < otherRank) return -1;
            }
            return 0;
        }
    }
}
