using System;
using System.Collections.Generic;
using System.IO;
using GraphService;

namespace Main
{
    static class Program
    {
        static void Main(string[] args)
        {
            var graph = new Graph
            (
                new[] {0,0,1,1,2,4,5},
                new[] {1,2,2,3,3,5,6}
            );
            WriteGraphToFile(graph, "out.txt");
            
            graph.ConnectedComponentsViaDFS();
            WriteArrayToConsole(graph.Components);
        }

        private static void WriteArrayToConsole(IEnumerable<int> collection)
        {
            
            foreach (var color in collection)
            {
                Console.Write($"{color} ");
            }
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