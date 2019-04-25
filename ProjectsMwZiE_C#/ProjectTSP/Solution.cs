using System;
using System.Linq;

namespace ProjectTSP
{
    internal class Solution
    {
        private int[] _solution;
        private readonly Random _rand;
        public double Fitness { get; set; }

        public Solution(Random rand)
        {
            _solution = new int[Problem.NoOfCities];
            _rand = rand;
        }

        public void Initialize()
        {
            for (var i = 0; i < Problem.NoOfCities; i++)
            {
                _solution[i] = i;
            }

            for (var i = 0; i < Math.Pow(Problem.NoOfCities, 2); i++)
            {
                Swap();
            }
        }

        private void Swap()
        {
            var p1 = _rand.Next(Problem.NoOfCities);
            int p2;
            do
            {
                p2 = _rand.Next(Problem.NoOfCities);
            } while (p1 == p2);
            var temp = _solution[p1];
            _solution[p1] = _solution[p2];
            _solution[p2] = temp;
        }

        public void Cross (Solution r2, double crossProb)
        {
            if (!(_rand.NextDouble() < crossProb)) return;
            var child1 = new Solution(_rand) {_solution = Enumerable.Repeat(-1, Problem.NoOfCities).ToArray()};
            var child2 = new Solution(_rand) {_solution = Enumerable.Repeat(-1, Problem.NoOfCities).ToArray()};
            var np = _rand.Next(Problem.NoOfCities);

            for (var i = 0; i < np; i++)
            {
                var p = _rand.Next(Problem.NoOfCities);
                child1._solution[p] = _solution[p];
                child2._solution[p] = r2._solution[p];
            }

            int p1 = 0, p2 = 0;

            for (var i = 0; i < Problem.NoOfCities; i++)
            {
                if(child1._solution[i] == -1)
                {
                    while (child1._solution.Contains(r2._solution[p2]))
                    {
                        p2++;
                    }
                    child1._solution[i] = r2._solution[p2];
                }

                if (child2._solution[i] != -1) continue;
                while (child2._solution.Contains(_solution[p1]))
                {
                    p1++;
                }
                child2._solution[i] = _solution[p1];
            }
            _solution = child1._solution;
            r2._solution = child2._solution;
        }

        public bool CheckSolution()
        {
            int sum1 = 0, sum2 = 0;
            for (var i = 0; i < Problem.NoOfCities; i++)
            {
                sum1 += i;
            }

            for (var i = 0; i < Problem.NoOfCities; i++)
            {
                sum2 += _solution[i];
            }

            return sum1 == sum2;
        }

        public void Inverse(double invProb)
        {
            if (!(_rand.NextDouble() < invProb)) return;
            var p1 = _rand.Next(Problem.NoOfCities);
            var p2 = _rand.Next(Problem.NoOfCities);
            if (p1 > p2)
            {
                var tmp = p1;
                p1 = p2;
                p2 = tmp;
            }

            for (var i = p1; i < (p2 - p1) / 2; i++)
            {
                var tmp = _solution[i];
                _solution[i] = _solution[p2 - i];
                _solution[p2 - i] = tmp;
            }
        }

        public void Mutate(double mutProb)
        {
            if (_rand.NextDouble() < mutProb)
            {
                Swap();
            }
        }

        public void Evaluate()
        {
            if (CheckSolution())
            {
                Fitness = Problem.Function(_solution);
            }
            else
            {
                Console.WriteLine("Error!");
            }
        }

        public Solution Clone()
        {
            var copy = (Solution)MemberwiseClone();
            copy._solution = (int[])_solution.Clone();
            return copy;
        }
    }
}
