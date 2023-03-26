using System.Collections.Generic;

namespace CoincapLibrary.Extensions
{
    internal static class DictionaryExtension
    {
        public static string? GenerateUriQueries<Key, Value>(this Dictionary<Key, Value> uriQueries) where Key : class where Value : class
        {
            var strs = uriQueries.Select((keyValue) => keyValue.Value is not null ? $"{keyValue.Key}={keyValue.Value}" : null)
                .OfType<string>();

            var generateQueries = string.Join("&", strs);

            return generateQueries;
        }
    }
}
