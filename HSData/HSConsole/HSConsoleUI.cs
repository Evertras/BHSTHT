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

        private void DrawPlayerLine(IPlayerState playerState)
        {
            ForegroundColor = ConsoleColor.Blue;

            CursorLeft = 0;
            Write("Player name");

            CursorLeft = BufferWidth / 2 - 2;
            ForegroundColor = ConsoleColor.Cyan;
            Write($"{playerState.ManaCrystals.Current}/{playerState.ManaCrystals.Maximum}");

            CursorLeft = BufferWidth - 5;
            ForegroundColor = ConsoleColor.Red;
            Write($"{playerState.Hero.CurrentHealth}/{playerState.Hero.MaxHealth}");
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
            DrawPlayerLine(inactivePlayer);

            // Draw active player on bottom
            CursorTop = WindowHeight - 2;
            DrawPlayerLine(activePlayer);

            ForegroundColor = originalForegroundColor;
        }
    }
}
