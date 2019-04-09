using System;
using System.IO;

namespace ProjectTSP
{
    class Problem
    {
        public static int NoOfCities;
        private static int BestResult;
        private static int[,] Points;

        public static void ReadProblem(string path)
        {
            string[] lines = File.ReadAllLines(path);
            int.TryParse(lines[0], out NoOfCities);
            int.TryParse(lines[1], out BestResult);
            Points = new int[NoOfCities, 2];

            for (var i = 0; i < NoOfCities; i++)
            {
                string[] s = lines[2 + i].Split(' ');
                int.TryParse(s[0], out Points[i, 0]);
                int.TryParse(s[1], out Points[i, 1]);
            }
        }

        public static int Function(int[] path)
        {
            var result = 0;
            for (int i = 0; i < NoOfCities - 1; i++)
            {
                result += (int)(Math.Sqrt(Math.Pow(Points[path[i], 0] - Points[path[i + 1], 0], 2)
                    + Math.Pow(Points[path[i], 1] - Points[path[i + 1], 1], 2)) + 0.51);
            }
            result += (int)(Math.Sqrt(Math.Pow(Points[path[NoOfCities - 1], 0] - Points[path[0], 0], 2)
                + Math.Pow(Points[path[NoOfCities - 1], 1] - Points[path[0], 1], 2)) + 0.51);
            return result;
        }
    }
}
