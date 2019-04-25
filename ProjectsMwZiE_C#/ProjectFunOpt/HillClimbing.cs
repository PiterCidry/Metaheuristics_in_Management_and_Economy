using System.Collections.Generic;
using p = ProjectFunOpt.Problems;

namespace ProjectFunOpt
{
    public class HillClimbing
    {
        public static KeyValuePair<double, double> Run(int maxNoIterations, double deviation)
        {
            var max = double.MinValue;
            var bestX = double.MinValue;

            for(var i = 0; i < maxNoIterations; i++)
            {
                var x = p.Rand.NextDouble() * 3 - 1;
                var y = p.Function(x);
                bool progress;

                do
                {
                    progress = false;
                    var xLeft = x - p.Normal(0, deviation);
                    if (xLeft < -1) xLeft = -1;
                    if (xLeft > 2) xLeft = 2;
                    var xRight = x + p.Normal(0, deviation);
                    if (xRight < -1) xRight = -1;
                    if (xRight > 2) xRight = 2;
                    var yLeft = p.Function(xLeft);
                    var yRight = p.Function(xRight);

                    if (yLeft > y)
                    {
                        x = xLeft;
                        y = yLeft;
                        progress = true;
                    }
                    else if (yRight > y)
                    {
                        x = xRight;
                        y = yRight;
                        progress = true;
                    }
                } while (progress);

                bestX = y > max ? x : bestX;
                max = y > max ? y : max;
            }

            return new KeyValuePair<double, double>(bestX, max);
        }
    }
}
