using System;

namespace ProjectFunOpt
{
    public static class Problem
    {
        public static Random Rand = new Random();

        public static double Function(double x)
        {
            return x * x * Math.Sin(15 * Math.PI * x) + 1;
        }

        public static double Normal(double mean, double deviation)
        {
            var u1 = 1.0 - Rand.NextDouble();
            var u2 = 1.0 - Rand.NextDouble();
            var randStdNormal = Math.Sqrt(-2.0 * Math.Log(u1)) *
                Math.Sin(2.0 * Math.PI * u2);
            return mean + deviation * randStdNormal;
        }
    }
}
