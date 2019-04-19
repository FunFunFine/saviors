using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Drawing
{
    public static class EnumerableExtensions
    {
        public static IEnumerable<T> With<T>(this IEnumerable<T> enumerable, params T[] items) =>
            enumerable.Concat(items);
    }
}