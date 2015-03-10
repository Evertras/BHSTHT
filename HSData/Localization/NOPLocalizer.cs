using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Localization
{
    /// <summary>
    /// A no-op localizer that just returns the key for faster testing
    /// </summary>
    public class NOPLocalizer : ILocalizer
    {
        public LocalizedString Localize(string key)
        {
            return new LocalizedString(key, key);
        }
    }
}
