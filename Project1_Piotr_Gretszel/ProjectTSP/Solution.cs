using System;
using System.Linq;

namespace ProjectTSP
{
    class Solution
    {
        private int[] solution;
        private double fitness;
        private Random rand;

        public double Fitness
        {
            get
            {
                return fitness;
            }

            set
            {
                fitness = value;
            }
        }

        public Solution(Random rand)
        {
            solution = new int[Problem.NoOfCities];
            this.rand = rand;
        }

        public void Initialize()
        {
            for (var i = 0; i < Problem.NoOfCities; i++)
            {
                solution[i] = i;
            }

            for (var i = 0; i < Math.Pow(Problem.NoOfCities, 2); i++)
            {
                Swap();
            }
        }

        private void Swap()
        {
            var p1 = rand.Next(Problem.NoOfCities);
            int p2;
            do
            {
                p2 = rand.Next(Problem.NoOfCities);
            } while (p1 == p2);
            int temp = solution[p1];
            solution[p1] = solution[p2];
            solution[p2] = temp;
        }

        public void Cross (Solution r2, double crossProb)
        {
            if (rand.NextDouble() < crossProb)
            {
                var child1 = new Solution(rand);
                child1.solution = Enumerable.Repeat(-1, Problem.NoOfCities).ToArray();
                var child2 = new Solution(rand);
                child2.solution = Enumerable.Repeat(-1, Problem.NoOfCities).ToArray();
                var np = rand.Next(Problem.NoOfCities);

                for (var i = 0; i < np; i++)
                {
                    var p = rand.Next(Problem.NoOfCities);
                    child1.solution[p] = solution[p];
                    child2.solution[p] = r2.solution[p];
                }

                int p1 = 0, p2 = 0;

                for (var i = 0; i < Problem.NoOfCities; i++)
                {
                    if(child1.solution[i] == -1)
                    {
                        while (child1.solution.Contains(r2.solution[p2]))
                        {
                            p2++;
                        }
                        child1.solution[i] = r2.solution[p2];
                    }

                    if (child2.solution[i] == -1)
                    {
                        while (child2.solution.Contains(solution[p1]))
                        {
                            p1++;
                        }
                        child2.solution[i] = solution[p1];
                    }
                }
                solution = child1.solution;
                r2.solution = child2.solution;
            }
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
                sum2 += solution[i];
            }

            return sum1 == sum2;
        }

        public void Inverse(double invProb)
        {
            if(rand.NextDouble() < invProb)
            {
                var p1 = rand.Next(Problem.NoOfCities);
                var p2 = rand.Next(Problem.NoOfCities);
                if (p1 > p2)
                {
                    var tmp = p1;
                    p1 = p2;
                    p2 = tmp;
                }

                for (var i = p1; i < (p2 - p1) / 2; i++)
                {
                    var tmp = solution[i];
                    solution[i] = solution[p2 - i];
                    solution[p2 - i] = tmp;
                }
            }
        }

        public void Mutate(double mutProb)
        {
            if (rand.NextDouble() < mutProb)
            {
                Swap();
            }
        }

        public void Evaluate()
        {
            if (CheckSolution())
            {
                Fitness = Problem.Function(solution);
            }
            else
            {
                Console.WriteLine("Error!");
            }
        }

        public Solution Clone()
        {
            Solution copy = (Solution)MemberwiseClone();
            copy.solution = (int[])solution.Clone();
            return copy;
        }
    }
}
