using System;

namespace ProjectFunOpt
{
    internal class Solution
    {
        private int[] _solution;
        private readonly int _min;
        private readonly int _max;
        private readonly uint _length;
        private readonly Random _rand;

        public double Fitness { get; set; }

        public Solution(int min, int max, uint precision, Random rand)
        {
            _min = min;
            _max = max;
            uint m = 1;
            while ((max - min) * Math.Pow(10, precision) > Math.Pow(2, m) - 1)
            {
                m++;
            }
            _length = m;
            _solution = new int[_length];
            _rand = rand;
        }

        public void Initialize()
        {
            for (var i = 0; i < _length; i++)
            {
                _solution[i] = _rand.NextDouble() < 0.5 ? 0 : 1;
            }
        }

        public double ToReal()
        {
            long xb = 0;
            for (var i = 0; i < _length; i++)
            {
                xb += _solution[i] * (int)Math.Pow(2, _length - i - 1);
            }
            return _min + xb * (_max - _min) / (Math.Pow(2, _length) - 1);
        }

        public void Evaluate()
        {
            Fitness = Problem.Function(ToReal());
        }

        public void Mutate(double mutProb)
        {
            for (var i = 0; i < _length; i++)
            {
                if (_rand.NextDouble() < mutProb)
                {
                    _solution[i] = Math.Abs(_solution[i] - 1);
                }
            }
        }

        public void Cross(Solution r2, double crossProb)
        {
            if (!(_rand.NextDouble() < crossProb)) return;
            var cp = _rand.Next((int)_length);
            for (var i = cp; i < _length; i++)
            {
                var temp = _solution[i];
                _solution[i] = r2._solution[i];
                r2._solution[i] = temp;
            }
        }

        public Solution Clone()
        {
            var clone = (Solution)MemberwiseClone();
            clone._solution = (int[])_solution.Clone();
            return clone;
        }
    }
}