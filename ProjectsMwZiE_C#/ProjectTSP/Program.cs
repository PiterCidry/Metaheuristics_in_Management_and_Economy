using System;

namespace ProjectTSP
{
    internal class Program
    {
        private static void Main()
        {
            var rand = new Random();
            const string problem = "TSP75.txt";
            var maxGen = new[] { 10000, 25000, 50000 };
            var popSize = new[] { 20, 50, 100 };
            var pc = new[] { 0.9, 0.7, 0.5 };
            var pm = new[] { 0.1, 0.3, 0.5 };
            var pi = new[] { 0.05, 0.1, 0.2 };

            Problem.ReadProblem(problem);

            foreach (var i in maxGen)
            {
                foreach (var size in popSize)
                {
                    foreach (var k in pc)
                    {
                        foreach (var l in pm)
                        {
                            foreach (var m in pi)
                            {
                                Console.WriteLine($"**************************\nGenetic algorithm for {problem.Split('.')[0]} with parameters:\n" +
                                                  $"Iterations: {i}\tPopulation Size: {size}\tPc: {k}\tPm: {l}\tPi: {m}");

                                var ga = new Ga(size, rand);
                                ga.Run(i, k, l, m);
                                // TODO: Writing results to .csv file!
                            }
                        }
                    }
                }
            }

            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }
    }
}
