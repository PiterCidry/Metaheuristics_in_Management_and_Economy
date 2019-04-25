using System;
using System.IO;

namespace ProjectTSP
{
    internal class Problem
    {
        public static int NoOfCities;
        private static int[,] _points;

        public static void ReadProblem(string path)
        {
            var lines = File.ReadAllLines(path);
            int.TryParse(lines[0], out NoOfCities);
            int.TryParse(lines[1], out _);
            _points = new int[NoOfCities, 2];

            for (var i = 0; i < NoOfCities; i++)
            {
                var s = lines[2 + i].Split(' ');
                int.TryParse(s[0], out _points[i, 0]);
                int.TryParse(s[1], out _points[i, 1]);
            }
        }

        public static int Function(int[] path)
        {
            var result = 0;
            for (var i = 0; i < NoOfCities - 1; i++)
            {
                result += (int)(Math.Sqrt(Math.Pow(_points[path[i], 0] - _points[path[i + 1], 0], 2)
                    + Math.Pow(_points[path[i], 1] - _points[path[i + 1], 1], 2)) + 0.51);
            }
            result += (int)(Math.Sqrt(Math.Pow(_points[path[NoOfCities - 1], 0] - _points[path[0], 0], 2)
                + Math.Pow(_points[path[NoOfCities - 1], 1] - _points[path[0], 1], 2)) + 0.51);
            return result;
        }
    }
}
