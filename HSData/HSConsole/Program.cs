using HSData;
using HSRepository;
using Localization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HSConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            IDeckRepository deckRepository = new TestDeckRepository(new TestCardRepository());
            const int initialHP = 30;

            IPlayerState playerOneInitialState =
                new PlayerState(
                    "Player One",
                    new HeroState(initialHP, initialHP, initialHP),
                    ManaCrystalState.StartingValue,
                    deckRepository.Load(),
                    HandState.EmptyHand
                    );

            IPlayerState playerTwoInitialState =
                new PlayerState(
                    "Player Two",
                    new HeroState(initialHP, initialHP, initialHP),
                    ManaCrystalState.StartingValue,
                    deckRepository.Load(),
                    HandState.EmptyHand
                    );

            Board board = new Board(playerOneInitialState, playerTwoInitialState);

            HSConsoleUI ui = new HSConsoleUI(board, new NOPLocalizer());

            while (board.CurrentState.PlayerOne.IsAlive && board.CurrentState.PlayerTwo.IsAlive)
            {
                ui.DisplayBoard();

                var keyInput = Console.ReadKey(true);

                board.ApplyEvent(new GameEventTurnEnd());
            }
        }
    }
}
