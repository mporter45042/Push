using System;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using System.Text;

namespace Push
{
    public class Game
    {
        private readonly Stack<ICard> _playingDeck;
        public  IEnumerable<Player> Players;
        public Player CurrentPlayer { get; }
        public ICard CurrentSelectedCard { get; set; }
        public CurrentCardStacks CurrentCardStack { get; }

        public Game(string player1Name = "", string player2Name = "")
        {
            var newDeck = DeckCreator.GenerateDeck();
            _playingDeck = DeckCreator.Shuffle(newDeck);
            CurrentCardStack = new CurrentCardStacks();
            var player1 = new Player(1, player1Name);
            var player2 = new Player(2, player2Name);
            Players = new List<Player>
            {
                player1,
                player2
            };

            CurrentPlayer = player1;
        }

        public void PlayCard(int columnNumber)
        {
            CurrentCardStack.Columns[columnNumber-1].Add(_playingDeck.Pop());
            CurrentSelectedCard = null;
        }

        public void EndGame()
        {

        }

        public bool DeckIsEmpty()
        {
            return _playingDeck.Count == 0;
        }

        public void GetNextCard()
        {
            if (DeckIsEmpty())
            {
                EndGame();
            }

            CurrentSelectedCard = _playingDeck.Peek();
        }

        public static bool IsValidMoveAvailableInCurrentCardStacks(ICard currentCard, CurrentCardStacks cardStacks)
        {
            var validMove = false;

            foreach (var column in cardStacks.Columns)
            {
                if (IsValidMoveAvailable(currentCard, column))
                {
                    validMove = true;
                }
            }

            return validMove;
        }

        public static bool IsValidMoveAvailable(ICard currentCard, List<ICard> cards)
        {
            if (cards.Count == 0)
            {
                return true;
            }

            var foundMatch = false;

            foreach (var card in cards)
            {
                if (currentCard.GetType() == typeof(RollCard))
                {
                    if (card.GetType() == typeof(RollCard))
                    {
                        foundMatch = true;
                    }
                }
                else
                {
                    var currentCardNumbered = currentCard as NumberedCard;
                    if (card is NumberedCard numberedCard && currentCardNumbered != null)
                    {
                        if (currentCardNumbered.Number == numberedCard.Number
                            || currentCardNumbered.Color == numberedCard.Color)
                        {
                            foundMatch = true;
                        }
                    }
                }
            }

            return !foundMatch;
        }
    }
}
