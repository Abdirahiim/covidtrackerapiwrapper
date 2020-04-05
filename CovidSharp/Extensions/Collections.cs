using System.Collections.Generic;
using System.Linq;

namespace CovidSharp.Extensions
{
    public static class Collections
    {
        public static string ToString(this Dictionary<string, string> dictionary, string valueSeparator, string pairSeparator)
        {
            return string.Join(pairSeparator, dictionary.Select(x => x.Key + valueSeparator + x.Value).ToArray());
        }

        public static void AddIfNotNullOrEmpty(this Dictionary<string, string> dictionary, string key, string value)
        {
            if (!string.IsNullOrWhiteSpace(value))
            {
                dictionary.Add(key, value);
            }
        }

        public static bool IsNullOrEmpty(this Dictionary<string, string> dictionary)
        {
            return dictionary == null || !dictionary.Any();
        }
    }
}
