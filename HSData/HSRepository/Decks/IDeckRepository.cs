using HSData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HSRepository
{
    public interface IDeckRepository
    {
        IDeckState Load();
    }
}
