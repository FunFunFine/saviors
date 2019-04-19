using System.Collections.Generic;

namespace Drawing
{
    public static class ArrayExtensions
    {
        public static IEnumerable<(T item, int x, int y)> IterateDoubleArray<T>(this T[,] doubleArray)
        {
            var width = doubleArray.GetLength(0);
            var height = doubleArray.GetLength(1);
            for (var x = 0; x < width; x++)
            {
                for (var y = 0; y < height; y++)
                {
                    yield return (doubleArray[x, y], x, y);
                }
            }
        }
    }
}