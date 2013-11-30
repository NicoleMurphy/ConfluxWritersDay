using System.Collections.Generic;
using System.Linq;
using OpenMagic;

namespace ConfluxWritersDay.Specifications.Infrastructure
{
    public static class IEnumerableExtensions
    {
        public static T RandomItem<T>(this IEnumerable<T> collection)
        {
            return collection.ToArray().RandomItem();
        }

        public static T RandomItem<T>(this T[] array)
        {
            var randomIndex = RandomNumber.NextInt(0, array.Length);

            return array[randomIndex];
        }
    }
}
