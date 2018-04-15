using System;
using System.Collections.Generic;
using System.Linq;

namespace PokerHand
{
    public static class Evaluator
    {
        public static List<Player> GetWinners(List<Player> players){
            if (players.Count < 1) throw new Exception("No players join. NO WINNER.");

            Player highestPlayer = null;
            List<Player> winners = new List<Player> {};
            //find winners
            for (int i = 0; i < players.Count; i++)
            {
                Player player = players[i];
                //if the highestPlaer is null and the current player is valide
                if( highestPlayer == null && player != null && player.Hand != null){
                    highestPlayer = player;
                    winners = new List<Player> { highestPlayer };
                }
                else {
                    int compareResult = highestPlayer.CompareTo(player);

                    if (compareResult == -1)
                    {
                        highestPlayer = player;
                        winners = new List<Player> { highestPlayer };
                    }
                    if (compareResult == 0)
                    {
                        winners.Add(player);
                    }
                }
            }
            return winners;
        }
    }
}
