using System;
using System.Diagnostics;

namespace Project1_Piotr_Gretszel
{
    internal class Program
    {
        private static void Main()
        {
            FullReviewExecute();
            RandomSearchExecute();
            HillClimbingExecute(1);
            TabuSearchExecute(1, 3);

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
            Console.WriteLine($"Elapsed time: {s.ElapsedMilliseconds}ms\nResult: {result}\n");
            Console.WriteLine($"****************************\nEnd of {nameof(FullReviewExecute)}\n****************************\n");
        }

        private static void RandomSearchExecute()
        {
            Console.WriteLine($"****************************\nStart of {nameof(RandomSearchExecute)}\n****************************\n");

            var noOfIterations = 10;
            var s = new Stopwatch();
            s.Start();
            var result = RandomSearch.Run(noOfIterations);
            s.Stop();
            Console.WriteLine($"Iterations: {noOfIterations}\nElapsed time: {s.ElapsedMilliseconds}ms\nResult: {result}\n");

            noOfIterations = 100;
            s.Reset();
            s.Start();
            result = RandomSearch.Run(noOfIterations);
            s.Stop();
            Console.WriteLine($"Iterations: {noOfIterations}\nElapsed time: {s.ElapsedMilliseconds}ms\nResult: {result}\n");

            noOfIterations = 1000;
            s.Reset();
            s.Start();
            result = RandomSearch.Run(noOfIterations);
            s.Stop();
            Console.WriteLine($"Iterations: {noOfIterations}\nElapsed time: {s.ElapsedMilliseconds}ms\nResult: {result}\n");

            noOfIterations = 10000;
            s.Reset();
            s.Start();
            result = RandomSearch.Run(noOfIterations);
            s.Stop();
            Console.WriteLine($"Iterations: {noOfIterations}\nElapsed time: {s.ElapsedMilliseconds}ms\nResult: {result}\n");

            noOfIterations = 100000;
            s.Reset();
            s.Start();
            result = RandomSearch.Run(noOfIterations);
            s.Stop();
            Console.WriteLine($"Iterations: {noOfIterations}\nElapsed time: {s.ElapsedMilliseconds}ms\nResult: {result}\n");

            noOfIterations = 1000000;
            s.Reset();
            s.Start();
            result = RandomSearch.Run(noOfIterations);
            s.Stop();
            Console.WriteLine($"Iterations: {noOfIterations}\nElapsed time: {s.ElapsedMilliseconds}ms\nResult: {result}\n");

            noOfIterations = 10000000;
            s.Reset();
            s.Start();
            result = RandomSearch.Run(noOfIterations);
            s.Stop();
            Console.WriteLine($"Iterations: {noOfIterations}\nElapsed time: {s.ElapsedMilliseconds}ms\nResult: {result}\n");

            Console.WriteLine($"****************************\nEnd of {nameof(RandomSearchExecute)}\n****************************\n");
        }

        private static void HillClimbingExecute(double deviation)
        {
            Console.WriteLine($"****************************\nStart of {nameof(HillClimbingExecute)}\n" +
                $"Parameter: Standard deviation - {deviation}\n****************************\n");

            var noOfIterations = 10;
            var s = new Stopwatch();
            s.Start();
            var result = HillClimbing.Run(noOfIterations, deviation);
            s.Stop();
            Console.WriteLine($"Iterations: {noOfIterations}\nElapsed time: {s.ElapsedMilliseconds}ms\nResult: {result}\n");

            noOfIterations = 100;
            s.Reset();
            s.Start();
            result = HillClimbing.Run(noOfIterations, deviation);
            s.Stop();
            Console.WriteLine($"Iterations: {noOfIterations}\nElapsed time: {s.ElapsedMilliseconds}ms\nResult: {result}\n");

            noOfIterations = 1000;
            s.Reset();
            s.Start();
            result = HillClimbing.Run(noOfIterations, deviation);
            s.Stop();
            Console.WriteLine($"Iterations: {noOfIterations}\nElapsed time: {s.ElapsedMilliseconds}ms\nResult: {result}\n");

            noOfIterations = 10000;
            s.Reset();
            s.Start();
            result = HillClimbing.Run(noOfIterations, deviation);
            s.Stop();
            Console.WriteLine($"Iterations: {noOfIterations}\nElapsed time: {s.ElapsedMilliseconds}ms\nResult: {result}\n");

            noOfIterations = 100000;
            s.Reset();
            s.Start();
            result = HillClimbing.Run(noOfIterations, deviation);
            s.Stop();
            Console.WriteLine($"Iterations: {noOfIterations}\nElapsed time: {s.ElapsedMilliseconds}ms\nResult: {result}\n");

            noOfIterations = 1000000;
            s.Reset();
            s.Start();
            result = HillClimbing.Run(noOfIterations, deviation);
            s.Stop();
            Console.WriteLine($"Iterations: {noOfIterations}\nElapsed time: {s.ElapsedMilliseconds}ms\nResult: {result}\n");

            noOfIterations = 10000000;
            s.Reset();
            s.Start();
            result = HillClimbing.Run(noOfIterations, deviation);
            s.Stop();
            Console.WriteLine($"Iterations: {noOfIterations}\nElapsed time: {s.ElapsedMilliseconds}ms\nResult: {result}\n");

            Console.WriteLine($"****************************\nEnd of {nameof(HillClimbingExecute)}\n" +
                $"Parameter: Standard deviation - {deviation}\n****************************\n");
        }

        private static void TabuSearchExecute(double deviation, int tabuLength)
        {
            Console.WriteLine($"****************************\nStart of {nameof(TabuSearchExecute)}\n" +
                $"Parameter: Standard deviation - {deviation}\n" +
                $"Parameter: Length of tabu list - {tabuLength}\n****************************\n");

            var noOfIterations = 10;
            var s = new Stopwatch();
            s.Start();
            var result = TabuSearch.Run(noOfIterations, deviation, tabuLength);
            s.Stop();
            Console.WriteLine($"Iterations: {noOfIterations}\nElapsed time: {s.ElapsedMilliseconds}ms\nResult: {result}\n");

            noOfIterations = 100;
            s.Reset();
            s.Start();
            result = TabuSearch.Run(noOfIterations, deviation, tabuLength);
            s.Stop();
            Console.WriteLine($"Iterations: {noOfIterations}\nElapsed time: {s.ElapsedMilliseconds}ms\nResult: {result}\n");

            noOfIterations = 1000;
            s.Reset();
            s.Start();
            result = TabuSearch.Run(noOfIterations, deviation, tabuLength);
            s.Stop();
            Console.WriteLine($"Iterations: {noOfIterations}\nElapsed time: {s.ElapsedMilliseconds}ms\nResult: {result}\n");

            noOfIterations = 10000;
            s.Reset();
            s.Start();
            result = TabuSearch.Run(noOfIterations, deviation, tabuLength);
            s.Stop();
            Console.WriteLine($"Iterations: {noOfIterations}\nElapsed time: {s.ElapsedMilliseconds}ms\nResult: {result}\n");

            noOfIterations = 100000;
            s.Reset();
            s.Start();
            result = TabuSearch.Run(noOfIterations, deviation, tabuLength);
            s.Stop();
            Console.WriteLine($"Iterations: {noOfIterations}\nElapsed time: {s.ElapsedMilliseconds}ms\nResult: {result}\n");

            noOfIterations = 1000000;
            s.Reset();
            s.Start();
            result = TabuSearch.Run(noOfIterations, deviation, tabuLength);
            s.Stop();
            Console.WriteLine($"Iterations: {noOfIterations}\nElapsed time: {s.ElapsedMilliseconds}ms\nResult: {result}\n");

            noOfIterations = 10000000;
            s.Reset();
            s.Start();
            result = TabuSearch.Run(noOfIterations, deviation, tabuLength);
            s.Stop();
            Console.WriteLine($"Iterations: {noOfIterations}\nElapsed time: {s.ElapsedMilliseconds}ms\nResult: {result}\n");

            Console.WriteLine($"****************************\nEnd of {nameof(TabuSearchExecute)}\n" +
                $"Parameter: Standard deviation - {deviation}\n" +
                $"Parameter: Length of tabu list - {tabuLength}\n****************************\n");
        }
    }
}
