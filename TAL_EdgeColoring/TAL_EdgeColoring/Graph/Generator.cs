using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TAL_EdgeColoring.GraphALL
{
    class Generator
    {
        public Graph GenerateNewGraph(int numberOfNodes, int numberOfEdges)
        {
            Console.WriteLine("Generuje graf");
            Graph graph = new Graph();
            Random random = new Random();
            List<Edge> edges = new List<Edge>();
            List<int> nodes = new List<int>();
            for(int i = 0; i < numberOfNodes; i++)
            {
                nodes.Add(i);
            }
            nodes = nodes.OrderBy(x => random.Next()).ToList();
            for(int i = 0; i < numberOfEdges; i++)
            {
                if( i< numberOfNodes - 1)
                {
                    edges.Add(new Edge(i, Tuple.Create(nodes[i], nodes[i + 1])));
                }
                else
                {
                    var tuple = Tuple.Create(0, 0);
                    while(edges.FindAll(x=>(x.Nodes.Item1 == tuple.Item1 && x.Nodes.Item2 == tuple.Item2) ||
                                           (x.Nodes.Item1 == tuple.Item2 && x.Nodes.Item2 == tuple.Item1)).Count !=0 ||
                                           tuple.Item1 == tuple.Item2)
                    {
                        tuple = Tuple.Create(nodes[random.Next(0, numberOfNodes - 1)], nodes[random.Next(0, numberOfNodes - 1)]);
                    }
                    edges.Add(new Edge(i, tuple));
                }
            }
            
            graph.Edges = edges;
            return graph;
        }

        
    }
}
