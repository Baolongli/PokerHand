using System;

using System.Collections.Generic;

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
    }

    public class PlayerComparer : IComparer<Player> {

        /**
         * Compare Two Player
         * 
         * @param    player1, player2   Two players that will be compared
         * @return           An integer. If 0, then they are equal, -1 if the player1 is weaker than the other, and 1 if the player1 is better.
         */
        public int Compare(Player player1, Player player2){
            if (player1.Hand == null && player2.Hand == null) throw new Exception("Hands cannot be all empty");

            if (player1.Hand == null && player2.Hand != null) return -1;
            if (player1.Hand != null && player2.Hand == null) return 1;

            return player1.Hand.CompareTo(player2.Hand);
        }
    }
}
