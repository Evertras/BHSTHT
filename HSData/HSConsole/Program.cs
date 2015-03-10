using HSData;
using HSRepository;
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
                    new HeroState(initialHP, initialHP, initialHP),
                    ManaCrystalState.StartingValue,
                    deckRepository.Load(),
                    HandState.EmptyHand
                    );

            IPlayerState playerTwoInitialState =
                new PlayerState(
                    new HeroState(initialHP, initialHP, initialHP),
                    ManaCrystalState.StartingValue,
                    deckRepository.Load(),
                    HandState.EmptyHand
                    );

            Board board = new Board(playerOneInitialState, playerTwoInitialState);

            HSConsoleUI ui = new HSConsoleUI(board);

            while (board.CurrentState.PlayerOne.IsAlive && board.CurrentState.PlayerTwo.IsAlive)
            {
                ui.DisplayBoard();

                Console.ReadKey(true);

                board.ApplyEvent(new GameEventTurnEnd());
            }
        }
    }
}
