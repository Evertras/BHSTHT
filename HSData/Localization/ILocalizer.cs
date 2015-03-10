using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Localization
{
    /// <summary>
    /// Localizes a string from a key to a value
    /// </summary>
    public interface ILocalizer
    {
        /// <summary>
        /// Creates a localized string based off a key
        /// </summary>
        /// <param name="key">The key to translate to the localizer's language</param>
        LocalizedString Localize(string key);
    }
}
