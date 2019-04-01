using System.Collections.Generic;
using System.Linq;
using p = Project1_Piotr_Gretszel.Problems;

namespace Project1_Piotr_Gretszel
{
    internal class FullReview
    {
        public static KeyValuePair<double, double> Run()
        {
            const int steps = 3000001;
            const int minRange = -1;
            const int maxRange = 2;
            var seq = Enumerable.Range(0, steps)
                 .Select(i => minRange + (maxRange - minRange) * ((double)i / (steps - 1)));
            seq = seq.ToList();

            var enumerable = seq.ToArray();
            var max = enumerable.Select(p.Function).Concat(new[] {double.MinValue}).Max();
            var bestX = enumerable.ToArray()[enumerable.Select(p.Function).Concat(new[] {double.MinValue}).ToList().IndexOf(max)];

            return new KeyValuePair<double, double>(bestX, max);
        }
    }
}
