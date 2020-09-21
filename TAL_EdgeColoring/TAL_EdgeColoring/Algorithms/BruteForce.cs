using System;
using System.Collections.Generic;
using System.Text;
using TAL_EdgeColoring.GraphALL;

namespace TAL_EdgeColoring.Algorithms
{
    class BruteForce
    {
        public Graph graph;
        bool graphColored = false;

        public BruteForce(Graph graph)
        {
            this.graph = graph;
        }

        public Graph ColorEdges()
        {
            for (int i = 2; i <= graph.Edges.Count; i++)
            {
                //Console.WriteLine("BruteForce: Checking " + (i-1) + " time...");
                if (!graphColored)
                    Step(i, graph.Edges, 0);
            }
            return graph;
        }

        private void Step(int numberOfColors, List<Edge> edges, int index)
        {
            //Console.WriteLine(index + "/" + edges.Count);
            for (int i = 0; i < numberOfColors; i++)
            {
                if (graphColored)
                {
                    break;
                }
                if (index == edges.Count)
                {
                    int goodColored = 0;
                    foreach (Edge edge in edges)
                    {
                        bool bad = false;
                        List<Edge> neighbourEdges = edge.NeighbourEdges(edge.ID, graph);
                        foreach (Edge neighbour in neighbourEdges)
                        {
                            if (neighbour.Color == edge.Color)
                            {
                                bad = true;
                            }
                        }
                        if (!bad)
                        {
                            goodColored++;
                        }
                        bad = false;
                    }
                    //Console.WriteLine("Good colored: " + goodColored);
                    if (goodColored == edges.Count)
                    {
                        graphColored = true;
                    }
                    break;
                }
                edges[index].Color = i+1;
                Step(numberOfColors, edges, index + 1);
            }
        }
    }
}
