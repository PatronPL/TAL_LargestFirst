using System;
using TAL_EdgeColoring.Algorithms;
using TAL_EdgeColoring.GraphALL;

namespace TAL_EdgeColoring
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfNodes = 30;
            int numberOfEdges = 30;
            Console.WriteLine("Program by Damian Tomasik");
            var generator = new Generator();
            var graph = generator.GenerateNewGraph(numberOfNodes, numberOfEdges);
            Console.WriteLine("Przykładowy graf dla: "+numberOfNodes+" wierzchołków i "+numberOfEdges+" krawędzi");
            graph.ShowGraph();

            var diagnostic = System.Diagnostics.Stopwatch.StartNew();
            var memory = GC.GetTotalMemory(false) / 1024;

            Console.WriteLine("BruteForce:");
            BruteForce bruteForce = new BruteForce(graph);

            diagnostic.Restart();
            memory = GC.GetTotalMemory(false) / 1024;
                bruteForce.ColorEdges();
            diagnostic.Stop();
            memory = (GC.GetTotalMemory(false) / 1024) -memory;

            bruteForce.graph.ShowGraph();
            Console.WriteLine("BruteForce:");
            Console.WriteLine("Czas trwania: " + diagnostic.ElapsedMilliseconds + "ms");
            Console.WriteLine("Pamięć wykorzystana: " + memory.ToString() + "kb");


            Console.WriteLine("\nLargestFirst:");
            LargestFirst largestFirst = new LargestFirst(graph);

            diagnostic.Restart();
            memory = GC.GetTotalMemory(false) / 1024;
                largestFirst.ColorEdges();
            diagnostic.Stop();
            memory = (GC.GetTotalMemory(false) / 1024) - memory;

            largestFirst.graph.ShowGraph();
            Console.WriteLine("LargestFirst:");
            Console.WriteLine("Czas trwania: " + diagnostic.ElapsedMilliseconds + "ms");
            Console.WriteLine("Pamięć wykorzystana: " + memory.ToString() + "kb");
        }
    }
}
