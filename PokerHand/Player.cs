using System;
namespace PokerHand
{
    public class Player
    {
        public String Name { get; set; }
        public Hand Hand { get; set; }

        public Player(String name) {
            Name = name;
        }

        public Player() {
            Name = "new Player";
        }

        public int CompareTo(Player other) {
            if (Hand == null && other.Hand == null) throw new Exception("Hands cannot be all empty");

            if (Hand == null && other.Hand != null) return -1;
            if (Hand != null && other.Hand == null) return 1;

            return Hand.CompareTo(other.Hand);
        }
    }
}
