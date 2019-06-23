using System;
using System.Collections.Generic;

namespace ProjectFunOpt
{
    internal class Ga
    {
        private readonly Solution[] _pop;
        private readonly Random _rand;
        private readonly int _popSize;

        public Ga(int popSize)
        {
            _pop = new Solution[popSize];
            _popSize = popSize;
            _rand = new Random();
        }

        public KeyValuePair<double, double> Run(int maxGen, double crossProb, double mutProb)
        {
            // Initialization
            for (var i = 0; i < _popSize; i++)
            {
                _pop[i] = new Solution(-1, 2, 8, _rand);
                _pop[i].Initialize();
            }

            // Evaluation
            var bestFitness = double.MinValue;
            var bestX = double.MinValue;

            foreach (var s in _pop)
            {
                s.Evaluate();
                if (!(s.Fitness > bestFitness)) continue;
                bestFitness = s.Fitness;
            }

            for (var gen = 1; gen < maxGen; gen++)
            {
                var nPop = new Solution[_popSize];

                //selection
                for (var i = 0; i < _popSize; i++)
                {
                    var r1 = _rand.Next(_popSize);
                    int r2;
                    do
                    {
                        r2 = _rand.Next(_popSize);
                    } while (r1 == r2);
                    nPop[i] = _pop[r1].Fitness > _pop[r2].Fitness ? _pop[r1].Clone() : _pop[r2].Clone();
                }

                //cross
                for (var i = 0; i < _popSize - 1; i += 2)
                {
                    nPop[i].Cross(nPop[i + 1], crossProb);
                }

                //mutation
                for (var i = 0; i < _popSize; i++)
                {
                    nPop[i].Mutate(mutProb);
                }

                foreach (var s in nPop)
                {
                    s.Evaluate();
                    if (!(s.Fitness > bestFitness)) continue;
                    bestX = s.ToReal();
                    bestFitness = s.Fitness;
                }

                for (var i = 0; i < _popSize; i++)
                {
                    _pop[i] = nPop[i];
                }
            }
            return new KeyValuePair<double, double>(bestX, bestFitness);
        }
    }
}