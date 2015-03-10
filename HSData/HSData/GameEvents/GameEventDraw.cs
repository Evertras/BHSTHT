using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HSData
{
    public class GameEventDraw : GameEventTargeted, IGameEvent
    {
        public GameEventDraw(IBoardEntity target) : base(target)
        {
            if (target as HeroState == null)
            {
                throw new ArgumentException("Target must be a hero");
            }
        }

        public BoardState Apply(BoardState initialState)
        {
            if (Target == initialState.PlayerOne.Hero)
            {
                return initialState.AlterPlayerOne(initialState.PlayerOne.Draw());
            }
            else if (Target == initialState.PlayerTwo.Hero)
            {
                return initialState.AlterPlayerTwo(initialState.PlayerTwo.Draw());
            }
            else
            {
                throw new ArgumentOutOfRangeException("Could not find target hero");
            }
        }
    }
}
