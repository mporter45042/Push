using Microsoft.VisualStudio.TestTools.UnitTesting;
using Push;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Push.Tests
{
    [TestClass()]
    public class GameTests
    {
        [TestMethod]
        public void DeckIsEmptyTest()
        {
            var game = new Game();

            Assert.IsFalse(game.DeckIsEmpty());
        }

        [TestMethod]
        public void PlayersAreCreated()
        {
            var game = new Game();

            Assert.IsTrue(game.Players.Count() == 2);
        }

        [TestMethod]
        public void WhenNumberedCardValidMoveIsAvailableTrueIsReturned()
        {
            var cardDeckToValidateAgainst = new List<ICard>
            {
                new NumberedCard(1, Color.Blue),
                new RollCard()
            };
            var currentCard = new NumberedCard(4, Color.Green);
            var isValidMove = Game.IsValidMoveAvailable(currentCard, cardDeckToValidateAgainst);
            Assert.IsTrue(isValidMove);
        }

        [TestMethod]
        public void WhenNumberedCardNoValidMoveIsAvailableFalseIsReturned()
        {
            var cardDeckToValidateAgainst = new List<ICard>
            {
                new NumberedCard(1, Color.Blue),
                new NumberedCard(4, Color.Green),
                new RollCard()
            };
            var currentCard = new NumberedCard(4, Color.Green);
            var isValidMove = Game.IsValidMoveAvailable(currentCard, cardDeckToValidateAgainst);
            Assert.IsFalse(isValidMove);
        }

        [TestMethod]
        public void WhenRollCardValidMoveIsAvailableTrueIsReturned()
        {
            var cardDeckToValidateAgainst = new List<ICard>
            {
                new NumberedCard(1, Color.Blue),
                new NumberedCard(3, Color.Red)
            };
            var currentCard = new RollCard();
            var isValidMove = Game.IsValidMoveAvailable(currentCard, cardDeckToValidateAgainst);
            Assert.IsTrue(isValidMove);
        }

        [TestMethod]
        public void WhenRollCardNoValidMoveIsAvailableFalseIsReturned()
        {
            var cardDeckToValidateAgainst = new List<ICard>
            {
                new NumberedCard(1, Color.Blue),
                new NumberedCard(4, Color.Green),
                new RollCard()
            };
            var currentCard = new RollCard();
            var isValidMove = Game.IsValidMoveAvailable(currentCard, cardDeckToValidateAgainst);
            Assert.IsFalse(isValidMove);
        }

        [TestMethod]
        public void WhenRollCardIsCurrentAndValidMoveAvailableInStackThenTrueIsR()
        {
            var currentCardStack = new CurrentCardStacks();
            var column1 = new List<ICard>
            {
                new NumberedCard(1, Color.Blue),
                new NumberedCard(4, Color.Green),
            };
            var column2 = new List<ICard>
            {
                new NumberedCard(2, Color.Blue),
                new NumberedCard(3, Color.Yellow),
                new RollCard()
            };
            var column3 = new List<ICard>
            {
                new NumberedCard(1, Color.Blue),
                new NumberedCard(6, Color.Red),
                new RollCard()
            };
            currentCardStack.Columns[0].AddRange(column1);
            currentCardStack.Columns[1].AddRange(column2);
            currentCardStack.Columns[2].AddRange(column3);

            var currentCard = new RollCard();

            var isValidMove = Game.IsValidMoveAvailableInCurrentCardStacks(currentCard, currentCardStack);
            Assert.IsTrue(isValidMove);
        }

        [TestMethod()]
        public void WhenNumberedCardIsCurrentAndValidMoveAvailableInStackThenTrueIsR()
        {
            var currentCardStack = new CurrentCardStacks();
            var column1 = new List<ICard>
            {
                new NumberedCard(1, Color.Blue),
                new NumberedCard(4, Color.Green),
            };
            var column2 = new List<ICard>
            {
                new NumberedCard(2, Color.Blue),
                new NumberedCard(3, Color.Yellow),
                new RollCard()
            };
            var column3 = new List<ICard>
            {
                new NumberedCard(4, Color.Blue),
                new NumberedCard(6, Color.Red),
                new RollCard()
            };
            currentCardStack.Columns[0].AddRange(column1);
            currentCardStack.Columns[1].AddRange(column2);
            currentCardStack.Columns[2].AddRange(column3);

            var currentCard = new NumberedCard(1, Color.Yellow);

            var isValidMove = Game.IsValidMoveAvailableInCurrentCardStacks(currentCard, currentCardStack);
            Assert.IsTrue(isValidMove);
        }

        [TestMethod()]
        public void WhenRollCardIsCurrentAndValidMoveAvailableInStackThenTrueIsReturned()
        {
            var currentCardStack = new CurrentCardStacks();

            currentCardStack.Columns[0].Add(new NumberedCard(5, Color.Green));
            currentCardStack.Columns[1].Add(new NumberedCard(1, Color.Green));
            currentCardStack.Columns[2].Add(new NumberedCard(4, Color.Green));

            var currentCard = new RollCard();

            var isValidMove = Game.IsValidMoveAvailableInCurrentCardStacks(currentCard, currentCardStack);
            Assert.IsTrue(isValidMove);
        }

        [TestMethod()]
        public void WhenNumberedCardIsCurrentAndValidMoveAvailableAndStackIsEmptyThenTrueIsR()
        {
            var currentCardStack = new CurrentCardStacks();

            var currentCard = new NumberedCard(1, Color.Yellow);

            var isValidMove = Game.IsValidMoveAvailableInCurrentCardStacks(currentCard, currentCardStack);
            Assert.IsTrue(isValidMove);
        }

        [TestMethod()]
        public void fixfailed()
        {
            var currentCardStack = new CurrentCardStacks();
            var column1 = new List<ICard>
            {
                new NumberedCard(4, Color.Blue)
            };
            var column2 = new List<ICard>
            {
                new NumberedCard(3, Color.Blue)
            };
            var column3 = new List<ICard>
            {
                new NumberedCard(4, Color.Green),
                new NumberedCard(6, Color.Red),
                new RollCard()
            };
            currentCardStack.Columns[0].AddRange(column1);
            currentCardStack.Columns[1].AddRange(column2);
            currentCardStack.Columns[2].AddRange(column3);

            var currentCard = new NumberedCard(1, Color.Yellow);

            var isValidMove = Game.IsValidMoveAvailableInCurrentCardStacks(currentCard, currentCardStack);
            Assert.IsTrue(isValidMove);
        }
    }
}