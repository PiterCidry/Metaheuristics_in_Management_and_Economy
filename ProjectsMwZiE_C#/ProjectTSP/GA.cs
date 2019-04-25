using System;
using System.Collections.Generic;

namespace ProjectTSP
{
    internal class Ga
    {
        private readonly Solution[] _pop;
        private readonly Random _rand;
        private Solution _bestSolution;
        private readonly int _popSize;

        public Ga(int popSize, Random rand)
        {
            _pop = new Solution[popSize];
            _popSize = popSize;
            _rand = rand;
        }

        public KeyValuePair<double, double> Run(int maxGen, double crossProb, double mutProb, double invProb = 0)
        {
            // Initialization
            for (var i = 0; i < _popSize; i++)
            {
                _pop[i] = new Solution(_rand);
                _pop[i].Initialize();
            }

            // Evaluation
            var bestFitness = double.MinValue;
            var bestGen = double.MinValue;

            foreach (var s in _pop)
            {
                s.Evaluate();
                if (s.Fitness > bestFitness)
                {
                    bestFitness = s.Fitness;
                }
            }

            for (var gen = 1; gen < maxGen; gen++)
            {
                var nPop = new Solution[_popSize];
                
                //Selection
                for (var i = 0; i < _popSize; i++)
                {
                    var r1 = _rand.Next(_popSize);
                    int r2;
                    do
                    {
                        r2 = _rand.Next(_popSize);
                    } while (r1 == r2);
                    nPop[i] = _pop[r1].Fitness < _pop[r2].Fitness ? _pop[r1].Clone() : _pop[r2].Clone();
                }

                //Elite
                if (_bestSolution != null)
                {
                    nPop[0] = _bestSolution.Clone();
                }

                //Cross
                for (var i = 0; i < _popSize - 1; i += 2)
                {
                    nPop[i].Cross(nPop[i + 1], crossProb);
                }

                //Inversion
                for (var i = 0; i < _popSize; i++)
                {
                    nPop[i].Inverse(invProb);
                }

                //Mutation
                for (var i = 0; i < _popSize; i++)
                {
                    nPop[i].Mutate(mutProb);
                }

                foreach (var s in nPop)
                {
                    s.Evaluate();
                    if (!(s.Fitness < bestFitness)) continue;
                    bestFitness = s.Fitness;
                    bestGen = gen;
                    _bestSolution = s.Clone();
                }

                for (var i = 0; i < _popSize; i++)
                {
                    _pop[i] = nPop[i];
                }
            }

            Console.WriteLine($"best {bestFitness} in generation {bestGen}\n**************************");
            return new KeyValuePair<double, double>(bestFitness, bestGen);
        }
    }
}
