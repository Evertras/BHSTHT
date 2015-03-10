using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Localization
{
    public class LocalizedString
    {
        public LocalizedString(string key, string localized)
        {
            // There has to be a key, whitespace doesn't count
            if (string.IsNullOrWhiteSpace(key))
            {
                throw new ArgumentNullException("Must supply key for localized string");
            }

            // Specifically only check null, since maybe some language wants to just blank out a key... or some keys might
            // only be filled in for certain languages
            if (localized == null)
            {
                throw new ArgumentNullException("Translated string can be blank, but not null");
            }

            Key = key;
            Localized = localized;
        }

        public string Key { get; }

        public string Localized { get; }

        public override string ToString()
        {
            return Localized;
        }
    }
}
