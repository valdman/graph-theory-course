using System;
using System.Collections.Generic;
using System.Drawing;

namespace GraphService
{
    class BFS
    {
        static void Run(string[] args)
        {
            var (n, m) = ReadPairOfNumbers();
            var field = ReadMatrix(n, m);

            Point from, to;
            (from.X, from.Y) = ReadPairOfNumbers();
            (to.X, to.Y) = ReadPairOfNumbers();

            var ans = RunSearch(n, m, field, from, to);
        }

        private static int RunSearch(int n, int m, int[,] field, Point from, Point to)
        {
            var queue = new Queue<Point>();
            queue.Enqueue(from);
            var l = 0;
            while (queue.Count > 0)
            {
                ++l;
                var currentPoint = queue.Dequeue();
                var currentState = field[currentPoint.X, currentPoint.Y];

                var nextStepPoints = GetNextStepPoint(field, currentPoint);
                foreach (var stepPoint in nextStepPoints)
                {
                    if (stepPoint == to)
                    {
                        return l;
                    }
                    field[currentPoint.X, currentPoint.Y] = l;
                    queue.Enqueue(stepPoint);
                }
            }
            throw new NotImplementedException();
        }

        private static int[,] ReadMatrix(int n, int m)
        {
            var a = new int[n, m];
            for(var i = 0; i < n; ++i)
            {
                var line = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
                for (var j = 0; j < m; j++)
                {
                    a[i, j] = line[j];
                }
            }
            return a;
        }

        private static (int n, int m) ReadPairOfNumbers()
        {
            var line = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
            return (line[0], line[1]);
        }

        private static IEnumerable<Point> GetNextStepPoint(int[,] field, Point point)
        {
            if (field[point.X + 2, point.Y + 1] == 0) yield return new Point(point.X + 2, point.Y + 1);
            if (field[point.X + 2, point.Y - 1] == 0) yield return new Point(point.X + 2, point.Y - 1);
            if (field[point.X - 2, point.Y + 1] == 0) yield return new Point(point.X - 2, point.Y + 1);
            if (field[point.X - 2, point.Y - 1] == 0) yield return new Point(point.X - 2, point.Y - 1);
        }
    }
}
