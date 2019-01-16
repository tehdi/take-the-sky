using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine.UI;

namespace TakeTheSky
{
    public static class ExtensionMethods
    {
        public static void Add<TKey, TValue>(this IDictionary<TKey, List<TValue>> dictionary, TKey key, TValue value)
        {
            List<TValue> list;
            if (!dictionary.TryGetValue(key, out list))
            {
                dictionary.Add(key, list = new List<TValue>());
            }
            dictionary[key].Add(value);
        }

        // https://stackoverflow.com/a/538751/9319242
        public static TValue GetOrDefault<TKey, TValue>(this IDictionary<TKey, TValue> dictionary, TKey key, TValue defaultValue)
        {
            return dictionary.TryGetValue(key, out var value) ? value : defaultValue;
        }
    }
}
