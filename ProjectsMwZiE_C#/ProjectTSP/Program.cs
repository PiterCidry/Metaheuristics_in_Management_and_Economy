using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using CsvHelper;

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
            var resultList = new List<Result>();

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
                                var s = new Stopwatch();
                                s.Start();
                                Console.WriteLine($"**************************\nGenetic algorithm for {problem.Split('.')[0]} with parameters:\n" +
                                                  $"Iterations: {i}\tPopulation Size: {size}\tPc: {k}\tPm: {l}\tPi: {m}");
                                var ga = new Ga(size, rand);
                                var result = ga.Run(i, k, l, m);
                                s.Stop();
                                Console.WriteLine($"Elapsed Time: {s.ElapsedMilliseconds}");
                                resultList.Add(new Result { Iterations = i, Pc = k, Pi = m, Pm = l, PopulationSize = size, ElapsedMilliseconds = s.ElapsedMilliseconds, BestGen = result.Key, BestFitness = result.Value});
                            }
                        }
                    }
                }
            }
            using (var writer = new StreamWriter("C:\\Users\\kasia\\Documents\\Studia\\Semestr 8\\MwZiE\\Zadania\\Metaheuristics_in_Management_and_Economy\\ProjectsMwZiE_C#\\ProjectTSP\\GaForTspResults.csv"))
            {
                using (var csv = new CsvWriter(writer))
                {
                    csv.WriteRecords(resultList);
                    writer.Flush();
                }
            }
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }
    }
}
