using System;
using System.Diagnostics;

namespace ProjectFunOpt
{
    internal class Program
    {
        private static void Main()
        {
            FullReviewExecute();
            foreach(var i in new[]{10, 100, 1000, 10000, 100000, 1000000, 10000000})
            {
                RandomSearchExecute(i);
            }
            foreach (var i in new[] { 0.1, 0.2, 0.5, 1, 1.5, 2, 5})
            {
                HillClimbingExecute(10000, i);
            }
            foreach (var i in new[] {1, 2, 3, 5, 10, 100, 1000})
            {
                TabuSearchExecute(1000, 1, i);
            }
            foreach (var i in new[] {10, 20, 30, 50, 100})
            {
                GaExecute(i, 10000, 0.8, 0.05);
            }
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }

        private static void FullReviewExecute()
        {
            Console.WriteLine($"****************************\nStart of {nameof(FullReviewExecute)}\n****************************\n");
            var s = new Stopwatch();
            s.Start();
            var result = FullReview.Run();
            s.Stop();
            Console.WriteLine($"Elapsed time: {s.ElapsedMilliseconds}ms\nBest X: {result.Key}\tBest Y: {result.Value}\n");
            Console.WriteLine($"****************************\nEnd of {nameof(FullReviewExecute)}\n****************************\n");
        }

        private static void RandomSearchExecute(int noOfIterations)
        {
            Console.WriteLine($"****************************\nStart of {nameof(RandomSearchExecute)}\n" +
                $"Parameter: Iterations - {noOfIterations}\n****************************\n");

            var s = new Stopwatch();
            s.Start();
            var result = RandomSearch.Run(noOfIterations);
            s.Stop();
            Console.WriteLine($"Elapsed time: {s.ElapsedMilliseconds}ms\nBest X: {result.Key}\tBest Y: {result.Value}\n");
            Console.WriteLine($"****************************\nEnd of {nameof(RandomSearchExecute)}\n****************************\n");
        }

        private static void HillClimbingExecute(int noOfIterations, double deviation)
        {
            Console.WriteLine($"****************************\nStart of {nameof(HillClimbingExecute)}\n" +
                $"Parameter: Standard deviation - {deviation}\n****************************\n");

            var s = new Stopwatch();
            s.Start();
            var result = HillClimbing.Run(noOfIterations, deviation);
            s.Stop();
            Console.WriteLine($"Elapsed time: {s.ElapsedMilliseconds}ms\nBest X: {result.Key}\tBest Y: {result.Value}\n");
            Console.WriteLine($"****************************\nEnd of {nameof(HillClimbingExecute)}\n****************************\n");
        }

        private static void TabuSearchExecute(int noOfIterations, double deviation, int tabuLength)
        {
            Console.WriteLine($"****************************\nStart of {nameof(TabuSearchExecute)}\n" +
                $"Parameter: Length of tabu list - {tabuLength}\n****************************\n");
            
            var s = new Stopwatch();
            s.Start();
            var result = TabuSearch.Run(noOfIterations, deviation, tabuLength);
            s.Stop();
            Console.WriteLine($"Elapsed time: {s.ElapsedMilliseconds}ms\nBest X: {result.Key}\tBest Y: {result.Value}\n");
            Console.WriteLine($"****************************\nEnd of {nameof(TabuSearchExecute)}\n****************************\n");
        }

        private static void GaExecute(int popSize, int maxGen, double crossProb, double mutProb)
        {
            Console.WriteLine($"****************************\nStart of {nameof(GaExecute)}\n" +
                              $"Parameter: Population size - {popSize}\n****************************\n");
            var s = new Stopwatch();
            var ga = new Ga(popSize);
            s.Start();
            var result = ga.Run(maxGen, crossProb, mutProb);
            s.Stop();
            Console.WriteLine($"Elapsed time: {s.ElapsedMilliseconds}ms\nBest X: {result.Key}\tBest Y: {result.Value}\n");
            Console.WriteLine($"****************************\nEnd of {nameof(GaExecute)}\n****************************\n");
        }
    }
}
