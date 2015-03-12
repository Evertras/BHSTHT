using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Localization
{
    public class SimpleFileLocalizer : ILocalizer
    {
        private readonly Dictionary<string, LocalizedString> values = new Dictionary<string, LocalizedString>();

        public SimpleFileLocalizer(string filename)
        {
            using (var stream = File.OpenRead(filename))
            {
                using (var reader = new StreamReader(stream))
                {
                    while (!reader.EndOfStream)
                    {
                        string line = reader.ReadLine();

                        if (string.IsNullOrWhiteSpace(line) || line.IndexOf(' ') == -1)
                        {
                            continue;
                        }

                        int spaceSplitIndex = line.IndexOf(' ');

                        var key = line.Substring(0, spaceSplitIndex);
                        var value = line.Substring(spaceSplitIndex + 1);

                        values[key] = new LocalizedString(key, value);
                    }
                }
            }
        }

        private readonly static LocalizedString errorNotFound = new LocalizedString("ERROR", "ERROR - NOT FOUND");
        private readonly static LocalizedString errorFormat = new LocalizedString("ERROR", "ERROR - INVALID FORMAT");

        public LocalizedString Localize(string key)
        {
            try
            {
                return values[key];
            }
            catch (KeyNotFoundException)
            {
                return errorNotFound;
            }
        }

        public GeneratedLocalizedString LocalizeFormat(string formatKey, params object[] objs)
        {
            try
            {
                return new GeneratedLocalizedString(string.Format(values[formatKey].Localized, objs));
            }
            catch (KeyNotFoundException)
            {
                return new GeneratedLocalizedString(errorNotFound.Localized);
            }
            catch (FormatException)
            {
                return new GeneratedLocalizedString(errorFormat.Localized);
            }
        }
    }
}
