using HSData;
using Localization;
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
        public IBoard Board { get; }
        public ILocalizer Localizer { get; }

        private readonly List<LocalizedString> messages = new List<LocalizedString>();

        public HSConsoleUI(IBoard board, ILocalizer localizer)
        {
            if (board == null)
            {
                throw new ArgumentNullException("Board cannot be null");
            }

            if (localizer == null)
            {
                throw new ArgumentNullException("Localizer cannot be null");
            }

            Board = board;

            Board.StateChanged += (b, eventArgs) => DisplayBoard();

            Localizer = localizer;
        }

        private void DrawPlayer(IPlayerState playerState)
        {
            ForegroundColor = ConsoleColor.Blue;

            CursorLeft = 0;
            Write(playerState.BattleTag);

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
            for (int i = 0; i < playerState.Hand.Cards.Count; ++i)
            {
                var card = playerState.Hand.Cards[i];

                CursorTop = WindowHeight - (3 + playerState.Hand.Cards.Count) + i;
                CursorLeft = 6;

                if (card.Cost <= playerState.ManaCrystals.Current)
                {
                    ForegroundColor = ConsoleColor.Green;
                }
                else
                {
                    ForegroundColor = ConsoleColor.DarkRed;
                }

                Write($"{(i + 1) % 10}) {Localizer.Localize(card.NameKey)} ({card.Cost})");
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
