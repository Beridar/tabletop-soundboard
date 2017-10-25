using System;
using System.Collections.Generic;
using System.Linq;

namespace Soundboard
{
    static class GenericCollectionExtensions
    {
        static T GetAnyRandomElement<T>(this IEnumerable<T> collection) where T : new()
        {
            return collection.Any()
                ? collection.ElementAt(new Random().Next(collection.Count()))
                : default(T);
        }
    }
}