using System;
namespace CardGame
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
}
