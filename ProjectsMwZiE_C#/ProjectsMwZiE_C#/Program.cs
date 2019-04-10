using System;
using System.Diagnostics;

namespace ProjectFunOpt
{
    internal class Program
    {
        private static void Main()
        {
            FullReviewExecute();
            RandomSearchExecute(10);
            RandomSearchExecute(100);
            RandomSearchExecute(1000);
            RandomSearchExecute(10000);
            RandomSearchExecute(100000);
            RandomSearchExecute(1000000);
            RandomSearchExecute(10000000);
            HillClimbingExecute(10000, 0.1);
            HillClimbingExecute(10000, 0.2);
            HillClimbingExecute(10000, 0.5);
            HillClimbingExecute(10000, 1);
            HillClimbingExecute(10000, 1.5);
            HillClimbingExecute(10000, 2);
            HillClimbingExecute(10000, 5);
            TabuSearchExecute(10000, 1, 1);
            TabuSearchExecute(10000, 1, 2);
            TabuSearchExecute(10000, 1, 3);
            TabuSearchExecute(10000, 1, 5);
            TabuSearchExecute(10000, 1, 10);
            TabuSearchExecute(10000, 1, 100);
            TabuSearchExecute(10000, 1, 1000);
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
    }
}
