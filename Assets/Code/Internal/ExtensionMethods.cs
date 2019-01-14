using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
    }
}
