using System;
using System.Collections.Generic;
using System.Linq;

namespace CardGame
{
    public static class Evaluator
    {
        public static List<Player> GetWinners(List<Player> players){
            if (players.Count < 2) throw new Exception();

            Player highestPlayer = players[0];
            List<Player> winners = new List<Player> { highestPlayer };

            for (int i = 1; i < players.Count; i++) {
                Player player = players[i];
                int compareResult = highestPlayer.Hand.CompareTo(player.Hand);

                if (compareResult == -1) { highestPlayer = player; }
                if (compareResult == 0) {
                    winners.Add(player);
                }
            }

            return winners;
        }
    }
}
