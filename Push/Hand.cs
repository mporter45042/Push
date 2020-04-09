using System;
using System.Collections.Generic;
using System.Text;

namespace Push
{
    public class Hand
    {
        public IEnumerable<NumberedCard> BlueCards { get; set; }
        public IEnumerable<NumberedCard> GreenCards { get; set; }

        public IEnumerable<NumberedCard> PurpleCards { get; set; }

        public IEnumerable<NumberedCard> RedCards { get; set; }
        public IEnumerable<NumberedCard> YellowCards { get; set; }

        public Hand()
        {
            BlueCards = new List<NumberedCard>();
            GreenCards = new List<NumberedCard>();
            PurpleCards = new List<NumberedCard>();
            RedCards = new List<NumberedCard>();
            YellowCards = new List<NumberedCard>();
        }
    }
}
