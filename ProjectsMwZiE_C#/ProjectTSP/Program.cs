using System;

namespace ProjectTSP
{
    class Program
    {
        static void Main(string[] args)
        {
            var rand = new Random();
            var problem = "TSP75.txt";
            int[] maxGen = new int[3] { 10000, 25000, 50000 };
            int[] popSize = new int[3] { 20, 50, 100 };
            double[] pc = new double[3] { 0.9, 0.7, 0.5 };
            double[] pm = new double[3] { 0.1, 0.3, 0.5 };
            double[] pi = new double[3] { 0.05, 0.1, 0.2 };

            Problem.ReadProblem(problem);

            foreach (var i in maxGen)
            {
                for (var j = 0; j < popSize.Length; j++)
                {
                    for (var k = 0; k < pc.Length; k++)
                    {
                        for (var l = 0; l < pm.Length; l++)
                        {
                            for (var m = 0; m < pi.Length; m++)
                            {
                                Console.WriteLine($"**************************\nGenetic algorithm for {problem.Split('.')[0]} with parameters:\n" +
                                    $"Iterations: {i}\tPopulation Size: {popSize[j]}\tPc: {pc[k]}\tPm: {pm[l]}\tPi: {pi[m]}");

                                var GA = new GA(popSize[j], rand);
                                var result = GA.Run(i, pc[k], pm[l], pi[m]);
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
