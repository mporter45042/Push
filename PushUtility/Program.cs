using System;
using Push;

namespace PushUtility
{
    class Program
    {
        private static readonly Game _game = new Game();

        static void Main(string[] args)
        {
            var continueTurn = true;

            while (continueTurn)
            {
                _game.GetNextCard();
                UpdateDisplay();
                if (!Game.IsValidMoveAvailableInCurrentCardStacks(_game.CurrentSelectedCard, _game.CurrentCardStack))
                {
                    Console.WriteLine("You busted");
                    break;
                }

                Console.WriteLine("Which column would you like to play the card in?");
                var playCardNumberIn = Int32.Parse(Console.ReadLine());

                if (Game.IsValidMoveAvailable(_game.CurrentSelectedCard,
                    _game.CurrentCardStack.Columns[playCardNumberIn - 1]))
                {
                    _game.PlayCard(playCardNumberIn);
                }

                UpdateDisplay();
                Console.WriteLine("Would you like continue Y for yes, or Finish to end turn");

                var action = Console.ReadLine();
                if (action == "Finish")
                {
                    continueTurn = false;
                }
            }
        }

        private static void UpdateDisplay()
        {
            Console.WriteLine();
            Console.WriteLine($"Current Card: {_game?.CurrentSelectedCard?.DisplayName}");
            int currentColumn = 1;
            foreach (var column in _game.CurrentCardStack.Columns)
            {
                Console.WriteLine();
                Console.Write($"Column {currentColumn}: ");
                foreach (var card in column)
                {
                    Console.Write($"{card.DisplayName}, ");
                }

                currentColumn++;
            }
            Console.WriteLine();
        }
    }
}
