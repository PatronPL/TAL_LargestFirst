using System;
using System.Collections.Generic;
using System.Text;

namespace TAL_EdgeColoring.GraphALL
{
    class Graph
    {
        public List<Edge> Edges { get; set; }

        public int CountEdgeColors()
        {
            int x = 0;
            for(int i = 0; i < Edges.Count; i++)
            {
                if (x <= Edges[i].Color)
                {
                    x = Edges[i].Color;
                }
            }
            return x;
        }
        public void ShowGraph()
        {
            Console.WriteLine("EdgeColors: " + CountEdgeColors());
            Console.WriteLine("Graf: ( wierzchołek -Color- wierzchołek )");
            foreach (Edge edge in Edges)
            {
                if (edge.Color == 0)
                {
                    Console.WriteLine("     W" + edge.Nodes.Item1 + " --- W" + edge.Nodes.Item2);
                }
                else
                {
                    Console.WriteLine("     W" + edge.Nodes.Item1 + " -"+edge.Color+"- W" + edge.Nodes.Item2);
                }
                
            }
        }
    }
}
