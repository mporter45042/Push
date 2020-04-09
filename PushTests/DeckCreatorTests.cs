using Microsoft.VisualStudio.TestTools.UnitTesting;
using Push;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace PushTests
{
    [TestClass]
    public class DeckCreatorTests
    {
        [TestMethod]
        public void GenerateDeckTest()
        {
            var deck = DeckCreator.GenerateDeck();

            var redCards = deck.Count(c => c.DisplayName.ToLower().Contains("red"));
            var greenCards = deck.Count(c => c.DisplayName.ToLower().Contains("green"));
            var blueCards = deck.Count(c => c.DisplayName.ToLower().Contains("blue"));
            var purpleCards = deck.Count(c => c.DisplayName.ToLower().Contains("purple"));
            var yellowCards = deck.Count(c => c.DisplayName.ToLower().Contains("yellow"));
            var rollCards = deck.Count(c => c.DisplayName.ToLower().Contains("roll"));

            Assert.AreEqual(18, redCards);
            Assert.AreEqual(18, greenCards);
            Assert.AreEqual(18, blueCards);
            Assert.AreEqual(18, purpleCards);
            Assert.AreEqual(18, yellowCards);
            Assert.AreEqual(18, rollCards);
        }
        [TestMethod]
        public void ShuffleTest()
        {
            var deck = DeckCreator.GenerateDeck();
            var shuffledDeck = DeckCreator.Shuffle(deck).ToList();

            var allSame = true;
            var currentCard = shuffledDeck[0];

            for (int i = 1; i < 18; i++)
            {
                if (shuffledDeck[i].GetType() != currentCard.GetType())
                {
                    allSame = false;
                }
                if (shuffledDeck[i] is NumberedCard && currentCard is NumberedCard)
                {
                    var nextCard = shuffledDeck[i] as NumberedCard;
                    var currentNumbered = currentCard as NumberedCard;

                    if (currentNumbered.Color != nextCard.Color || currentNumbered.Number != nextCard.Number)
                    {
                        allSame = false;
                    }
                }
            }

            Assert.IsFalse(allSame);
        }
    }
}
