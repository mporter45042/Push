using System;
using System.Collections.Generic;
using System.Text;

namespace Push
{
    public class Player
    {
        public int PlayerNumber { get; }
        public string PlayerName { get; }
        public Hand CardsInHand { get; set; }
        public Hand CardsInBank { get; set; }
        public bool RollRequired { get; set; } = false;

        public Player(int playerNumber, string name = "")
        {
            PlayerNumber = playerNumber;
            PlayerName = name;
            if (name == string.Empty)
            {
                PlayerName = $"Player {playerNumber}";
            }
            CardsInHand = new Hand();
            CardsInBank = new Hand();
        }
    }
}
