using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TAL_EdgeColoring.GraphALL;


namespace TAL_EdgeColoring.Algorithms
{
    class LargestFirst
    {
        public Graph graph;

        public LargestFirst(Graph graph)
        {
            this.graph = graph;
        }

        public Graph ColorEdges()
        {
            graph.Edges = GreedyColoring(EdgesByDegreeList(graph.Edges));
            return graph;
        }

        private List<Edge> EdgesByDegreeList(List<Edge> edges)
        {
            List<Edge> degreeEdges = new List<Edge>();
            foreach(Edge edge in edges)
            {
                edge.degree = edge.EdgeDegree(edge.ID, graph);
                degreeEdges.Add(edge);
            }
            return degreeEdges.OrderBy(x => x.degree).ToList();
        }

        private List<Edge> GreedyColoring(List<Edge> edges)
        {
            bool bad = false;
            foreach(Edge edge in edges)
            {
                int i = 0;
                List<Edge> neighbourEdges = edge.NeighbourEdges(edge.ID, graph);
                while(edge.Color == 0)
                {
                    foreach (Edge neighbour in neighbourEdges)
                    {
                        if (neighbour.Color == edge.Color)
                        {
                            bad = true;
                        }
                    }
                    if (!bad)
                    {
                        edge.Color = i;
                    }
                    bad = false;
                    i++;
                }
            }
            return edges;
        }
    }
}
