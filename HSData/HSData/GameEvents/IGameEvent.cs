using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HSData
{
    public interface IGameEvent
    {
        BoardState Apply(BoardState initialState);
    }
}
