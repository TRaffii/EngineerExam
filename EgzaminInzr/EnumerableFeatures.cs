using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EgzaminInzr
{
    static class EnumerableFeatures
    {
        public static IEnumerable<T> Shuffle<T>(this IEnumerable<T> enumerable)
        {
            var r = new Random();
            return enumerable.OrderBy(x => r.Next()).ToList();
        }
    }
}
