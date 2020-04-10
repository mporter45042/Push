using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Push
{
    public class Hand
    {
        private List<NumberedCard> _cardsInHand;

        public IEnumerable<NumberedCard> BlueCards
        {
            get
            {
                return _cardsInHand.Where(c => c.Color == Color.Blue);
            }
        }
        public IEnumerable<NumberedCard> GreenCards
        {
            get
            {
                return _cardsInHand.Where(c => c.Color == Color.Green);
            }
        }

        public IEnumerable<NumberedCard> PurpleCards
        {
            get
            {
                return _cardsInHand.Where(c => c.Color == Color.Purple);
            }
        }

        public IEnumerable<NumberedCard> RedCards
        {
            get
            {
                return _cardsInHand.Where(c => c.Color == Color.Red);
            }
        }
        public IEnumerable<NumberedCard> YellowCards
        {
            get
            {
                return _cardsInHand.Where(c => c.Color == Color.Yellow);
            }
        }

        public Hand()
        {
            _cardsInHand = new List<NumberedCard>();
        }

        public void AddCard(NumberedCard card)
        {
            _cardsInHand.Add(card);
        }

        public void RemoveAllCardsOfColor(Color color)
        {
            _cardsInHand.RemoveAll(c => c.Color == color);
        }
    }
}
