using System.Collections.Generic;
using p = ProjectFunOpt.Problem;

namespace ProjectFunOpt
{
    public class RandomSearch
    {
        public static KeyValuePair<double, double> Run(int maxNoIterations)
        {
            var max = double.MinValue;
            var bestX = double.MinValue;

            for(var i = 0; i < maxNoIterations; i++)
            {
                var x = p.Rand.NextDouble() * 3 - 1;
                var y = p.Function(x);
                bestX = y > max ? x : bestX;
                max = y > max ? y : max;
            }

            return new KeyValuePair<double, double>(bestX, max);
        }
    }
}
