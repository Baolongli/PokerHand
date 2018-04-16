using System;

using PokerHand.Exceptions;

namespace PokerHand.Model
{
    public class Player : IComparable<Player>
    {
        public String Name { get; set; }
        public Hand Hand { get; set; }

        public Player(String name) {
            Name = name;
        }

        public Player() {
            Name = "new Player";
        }

        /**
         * Compare the Hand of two players
         * 
         * @param    other   The Player to compare to.
         * @return           An integer. If 0, then they are equal, -1 if the current player (the one calling the method) is weaker than the other, and 1 if the player calling the method is better.
         */
        public int CompareTo(Player other) {
            if (other == null) return 1;

            if (Hand == null && other.Hand == null) throw new InvalidHandException("Cannot compare players all have empty hands");

            if (Hand == null && other.Hand != null) return -1;
            if (Hand != null && other.Hand == null) return 1;

            return Hand.CompareTo(other.Hand);
        }
    }
}
