using p = Project1_Piotr_Gretszel.Problems;

namespace Project1_Piotr_Gretszel
{
    public class RandomSearch
    {
        public static double Run(int maxNoIterations)
        {
            var max = double.MinValue;

            for(var i = 0; i < maxNoIterations; i++)
            {
                var x = p.Rand.NextDouble() * 3 - 1;
                var y = p.Function(x);
                max = y > max ? y : max;
            }

            return max;
        }
    }
}
