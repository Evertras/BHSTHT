using HSData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using static System.Console;

namespace HSConsole
{
    public class HSConsoleUI
    {
        public Board Board { get; }

        public HSConsoleUI(Board board)
        {
            Board = board;

            Board.StateChanged += b => DisplayBoard();
        }

        private void DrawPlayer(IPlayerState playerState)
        {
            ForegroundColor = ConsoleColor.Blue;

            CursorLeft = 0;
            Write("Player name");

            CursorLeft = BufferWidth / 2 - 1;
            ForegroundColor = ConsoleColor.Cyan;
            Write($"{playerState.ManaCrystals.Current}/{playerState.ManaCrystals.Maximum}");

            CursorLeft = BufferWidth - 6;
            ForegroundColor = ConsoleColor.Red;
            Write($"{playerState.Hero.CurrentHealth}/{playerState.Hero.MaxHealth}");

            CursorTop += 1;
            CursorLeft = 4;

            ForegroundColor = ConsoleColor.Yellow;

            for (int i = 0; i < playerState.Hand.Cards.Count; ++i)
            {
                Write($"[{i+1}] ");
            }
        }

        private void DrawHand(IPlayerState playerState)
        {
            ForegroundColor = ConsoleColor.White;

            for (int i = 0; i < playerState.Hand.Cards.Count; ++i)
            {
                var card = playerState.Hand.Cards[i];

                CursorTop = 4 + i;
                CursorLeft = 6;

                Write($"{i + 1}) ({card.Cost})");
            }
        }

        public void DisplayBoard()
        {
            WindowHeight = 40;
            var originalForegroundColor = ForegroundColor;

            var activePlayer = Board.CurrentState.ActivePlayer == BoardState.PlayerTurn.PlayerOne ? Board.CurrentState.PlayerOne : Board.CurrentState.PlayerTwo;
            var inactivePlayer = Board.CurrentState.ActivePlayer == BoardState.PlayerTurn.PlayerOne ? Board.CurrentState.PlayerTwo : Board.CurrentState.PlayerOne;

            BackgroundColor = ConsoleColor.DarkGray;

            Clear();

            // Draw inactive player on top
            DrawPlayer(inactivePlayer);

            // Draw active player on bottom
            CursorTop = WindowHeight - 3;
            DrawPlayer(activePlayer);

            // Show the active player's hand
            DrawHand(activePlayer);

            ForegroundColor = originalForegroundColor;
        }
    }
}
