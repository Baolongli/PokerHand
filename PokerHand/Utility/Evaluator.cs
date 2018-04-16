using System;
using System.Collections.Generic;

namespace PokerHand
{
    /** Assumptions:
     * 1. The game is using Standard 52-card deck.:https://en.wikipedia.org/wiki/Standard_52-card_deck
     * 2. In one round, two different players wont get any of the same card.
     * 3. The rank of a hand does not depends on the type of suit
     * 4. Four of a kind is consider as ThreeOfAKind and is weaker than any kind of flush in this library. (TODO: fix this)
     * 5. Stright does not exist and is consider as High card. (TODO: fix this)
     * 6. Two pairs belongs to one pair. The one pair hand with highest rank of pair wins, if two hands has same pair, the hand has greatest individual card wins. (TODO: fix this add two pair hand type)
     * 7. There is only one kind of Flush. the flush hand with greatest individual card wins. (TODO: fix this add other kind of flush)
     */

    /**
     * Find all the winners from a given list of players
     * 
     * @param players  A list of players that still in this round
     * 
     * @return A list of Winners; 
     *              1. if the count of players is 0, or none of the players have valid hand, then return empty list
     *              2. Return any of the players that have highest rank
     */
    public static class Evaluator
    {
        public static List<Player> GetWinners(List<Player> players){

            Player highestPlayer = null;
            List<Player> winners = new List<Player> {};
            //find winners
            for (int i = 0; i < players.Count; i++)
            {
                Player player = players[i];
                //if the highestPlayer is null and the current player is valide
                if( highestPlayer == null && player != null && player.Hand != null){
                    highestPlayer = player;
                    winners = new List<Player> { highestPlayer };
                }
                else {
                    //if the highestPlayer exist, compare it with a player
                    int compareResult = highestPlayer.CompareTo(player);

                    if (compareResult == -1)
                    {
                        highestPlayer = player;
                        winners = new List<Player> { highestPlayer }; //reset winner with this player if it has the highest rank.
                    }
                    if (compareResult == 0)
                    {
                        winners.Add(player);    //add to winner list if it has same highest rank
                    }
                }
            }
            return winners;
        }
    }
}
