using System;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using System.Text;
using System.Linq;

namespace Push
{
    public class Game
    {
        private readonly Stack<ICard> _playingDeck;
        public List<Player> Players;
        public Player CurrentPlayer { get; private set; }
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

        public void CollectCards(int player1ColumnToKeep, int player2ColumnToKeep)
        {
            var cardsForPlayer1 = RetrieveCardsFromCurrentStackByColumn(player1ColumnToKeep);
            GiveCardsToSelectedPlayer(Players[0], cardsForPlayer1);
            SetRollRequired(Players[0], cardsForPlayer1);

            var cardsForPlayer2 = RetrieveCardsFromCurrentStackByColumn(player2ColumnToKeep);
            GiveCardsToSelectedPlayer(Players[1], cardsForPlayer2);
            SetRollRequired(Players[1], cardsForPlayer2);

            CurrentCardStack.Reset();
        }

        private void SetRollRequired(Player player, IEnumerable<ICard> cards)
        {
            var rollRequired = cards.Count(c => c.GetType() == typeof(RollCard));
            if (rollRequired > 0)
            {
                player.RollRequired = true;
            }
        }

        private IEnumerable<ICard> RetrieveCardsFromCurrentStackByColumn(int columnNumber)
        {
            if(columnNumber > 0)
            {
                return CurrentCardStack.Columns[columnNumber - 1];
            }

            return new List<ICard>();
        }

        private void GiveCardsToSelectedPlayer(Player player, IEnumerable<ICard> cards)
        {
            foreach (var card in cards)
            {
                var numberedCard = card as NumberedCard;
                if(numberedCard != null)
                {
                    player.CardsInHand.AddCard(numberedCard);
                }
            }
        }

        private void SwitchActivePlayer()
        {
            if(CurrentPlayer.Equals(Players[0]))
            {
                CurrentPlayer = Players[1];
            }
            else
            {
                CurrentPlayer = Players[0];
            }
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
