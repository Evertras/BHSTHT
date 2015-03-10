using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HSData
{
    public abstract class GameEventTargeted
    {
        public GameEventTargeted(IBoardEntity target)
        {
            if (target == null)
            {
                throw new ArgumentNullException("Target cannot be null");
            }

            Target = target;
        }

        public IBoardEntity Target { get; }
    }
}
