using System.Collections.Generic;
using System.Linq;

namespace PhysX
{
    public static class VectorExtensions
    {
        public static Vector Sum(this IEnumerable<Vector> vectors) => vectors.Aggregate(Vector.Zero, (current, vector) => current + vector);
    }
}