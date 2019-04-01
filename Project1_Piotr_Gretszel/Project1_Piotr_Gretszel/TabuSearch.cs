using System.Collections.Generic;
using p = Project1_Piotr_Gretszel.Problems;

namespace Project1_Piotr_Gretszel
{
    public class TabuSearch
    {
        public static KeyValuePair<double, double> Run(int maxNoIterations, double deviation, int tabuLength)
        {
            var tabu = new List<double>();
            var max = double.MinValue;
            var bestX = double.MinValue;

            for(var i = 0; i < maxNoIterations; i++)
            {
                var x = p.Rand.NextDouble() * 3 - 1;
                
                if (tabu.Exists(z => z > x - 0.0001 && z < x + 0.0001)) continue;
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

                if (!(y > max)) continue;
                bestX = x;
                max = y;
                if(tabu.Count > tabuLength)
                {
                    tabu.RemoveAt(0);
                }
                tabu.Add(x);
            }   

            return new KeyValuePair<double, double>(bestX, max);
        }
    }
}
