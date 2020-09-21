using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TAL_EdgeColoring.GraphALL
{
    class Edge
    {
        public int ID { get; set; }
        public int Color { get; set; }
        public Tuple<int,int> Nodes { get; set; }
        public int degree=0;

        public Edge(int edgeID, Tuple<int, int> nodes)
        {
            ID = edgeID;
            Nodes = nodes;
            //Color 0 => brak koloru
            Color = 0;
        }

        public List<Edge> NeighbourEdges(int edgeID, Graph graph)
        {
            Edge? edge = null;
            foreach(Edge e in graph.Edges)
            {
                if(e.ID == edgeID)
                {
                    edge = e;
                }
            }
            List<Edge> neighbours = graph.Edges.FindAll(x =>
                                    edge.Nodes.Item1 == x.Nodes.Item1 ||
                                    edge.Nodes.Item1 == x.Nodes.Item2 ||
                                    edge.Nodes.Item2 == x.Nodes.Item1 ||
                                    edge.Nodes.Item2 == x.Nodes.Item2
                                    ).Where(x => edge.ID != x.ID).ToList();
            return neighbours;
        }

        public int EdgeDegree(int edgeID, Graph graph)
        {
            Edge? edge = null;
            foreach (Edge e in graph.Edges)
            {
                if (e.ID == edgeID)
                {
                    edge = e;
                }
            }
            int degree = graph.Edges.FindAll(x =>
                                    edge.Nodes.Item1 == x.Nodes.Item1 ||
                                    edge.Nodes.Item1 == x.Nodes.Item2 ||
                                    edge.Nodes.Item2 == x.Nodes.Item1 ||
                                    edge.Nodes.Item2 == x.Nodes.Item2).Count();
            return degree-1;
        }
    }
}
