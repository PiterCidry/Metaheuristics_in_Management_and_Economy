using System;
using System.Collections.Generic;

namespace ProjectTSP
{
    class GA
    {
        Solution[] pop;
        Random rand;
        Solution bestSolution;
        int popSize;

        public GA(int popSize, Random rand)
        {
            pop = new Solution[popSize];
            this.popSize = popSize;
            this.rand = rand;
        }

        public KeyValuePair<double, double> Run(int maxGen, double crosProb, double mutProb, double invProb = 0)
        {
            // Initialization
            for (var i = 0; i < popSize; i++)
            {
                pop[i] = new Solution(rand);
                pop[i].Initialize();
            }
            // Evalutaion
            var bestFitness = double.MinValue;
            var bestGen = double.MinValue;

            foreach (var s in pop)
            {
                s.Evaluate();
                if (s.Fitness > bestFitness)
                {
                    bestFitness = s.Fitness;
                }
            }

            for (var gen = 1; gen < maxGen; gen++)
            {

                Solution[] npop = new Solution[popSize];
                //Selection
                for (int i = 0; i < popSize; i++)
                {
                    int r1 = rand.Next(popSize);
                    int r2;
                    do
                    {
                        r2 = rand.Next(popSize);
                    } while (r1 == r2);
                    npop[i] = pop[r1].Fitness < pop[r2].Fitness ? pop[r1].Clone() : pop[r2].Clone();
                }

                //Elite
                if (bestSolution != null)
                {
                    npop[0] = bestSolution.Clone();
                }


                //Cross
                for (var i = 0; i < popSize - 1; i += 2)
                {
                    npop[i].Cross(npop[i + 1], crosProb);
                }

                //Inversion
                for (var i = 0; i < popSize; i++)
                {
                    npop[i].Inverse(invProb);
                }

                //Mutation
                for (var i = 0; i < popSize; i++)
                {
                    npop[i].Mutate(mutProb);
                }

                foreach (Solution s in npop)
                {
                    s.Evaluate();
                    if (s.Fitness < bestFitness)
                    {
                        bestFitness = s.Fitness;
                        bestGen = gen;
                        bestSolution = s.Clone();
                    }
                }

                for (var i = 0; i < popSize; i++)
                {
                    pop[i] = npop[i];
                }
            }

            Console.WriteLine($"best {bestFitness} in generation {bestGen}\n**************************");
            return new KeyValuePair<double, double>(bestFitness, bestGen);
        }
    }
}
