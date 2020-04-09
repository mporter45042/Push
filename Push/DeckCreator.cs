using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Push
{
    public static class DeckCreator
    {
        public static Stack<ICard> GenerateDeck()
        {
            var colorsForDeck = new List<Color>
            {
                Color.Blue,
                Color.Green,
                Color.Purple,
                Color.Red,
                Color.Yellow
            };

            var deck = new Stack<ICard>();

            //create numbered cards
            foreach (var color in colorsForDeck)
            {
                //create numbers 1 through 6 in each color
                for (int i = 1; i <= 6; i++)
                {
                    //add 3 of each number to the deck
                    for (int j = 0; j < 3; j++)
                    {
                        var numberedCard = new NumberedCard(i, color);
                        deck.Push(numberedCard);
                    }
                }
            }

            //add 18 Roll Cards
            var rollCard = new RollCard();
            for (int i = 0; i < 18; i++)
            {
                deck.Push(rollCard);
            }

            return deck;
        }

        public static Stack<ICard> Shuffle(Stack<ICard> cards)
        {
            //Shuffle the existing cards using Fisher-Yates Modern
            List<ICard> transformedCards = cards.ToList();
            Random r = new Random(DateTime.Now.Millisecond);
            for (int n = transformedCards.Count - 1; n > 0; --n)
            {
                //Step 2: Randomly pick a card which has not been shuffled
                int k = r.Next(n + 1);

                //Step 3: Swap the selected item 
                //        with the last "unselected" card in the collection
                ICard temp = transformedCards[n];
                transformedCards[n] = transformedCards[k];
                transformedCards[k] = temp;
            }

            Stack<ICard> shuffledCards = new Stack<ICard>();
            foreach (var card in transformedCards)
            {
                shuffledCards.Push(card);
            }

            return shuffledCards;
        }
    }
}
