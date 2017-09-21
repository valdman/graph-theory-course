using System;
using System.IO;
using GraphService;

namespace Main
{
    static class Program
    {
        static void Main(string[] args)
        {
            var graph = new Graph(new[] {0,0,1,1,2},
                new[] {1,2,2,3,3});

            foreach (var arc in graph.GetAllArcsFrom(0))
            {
                Console.WriteLine($"{arc.FromNumber}->{arc.ToNumber}");
            }
            WriteGraphToFile(graph, "out.txt");
        }

        private static void WriteGraphToFile(Graph graph, string fileName)
        {
            var fileOutStream = File.CreateText(fileName);
                        
            graph.PrintToWolframFormat(fileOutStream);
            fileOutStream.Flush();
            fileOutStream.Dispose();
        }
    }
}