using System.Linq;
using p = Project1_Piotr_Gretszel.Problems;

namespace Project1_Piotr_Gretszel
{
    internal class FullReview
    {
        public static double Run()
        {
            const int steps = 3000001;
            const int minRange = -1;
            const int maxRange = 2;
            var seq = Enumerable.Range(0, steps)
                 .Select(i => minRange + (maxRange - minRange) * ((double)i / (steps - 1)));
            seq = seq.ToList();

            var max = seq.Select(p.Function).Concat(new[] {double.MinValue}).Max();

            return max;
        }
    }
}
