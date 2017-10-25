using System;
using System.Collections.Generic;
using System.Linq;

namespace Soundboard
{
    internal static class GenericCollectionExtensions
    {
        internal static T GetAnyRandomElement<T>(this IEnumerable<T> collection)
        {
            return collection.Any()
                ? collection.ElementAt(new Random().Next(collection.Count()))
                : default(T);
        }
    }
}