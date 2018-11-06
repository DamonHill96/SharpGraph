using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using SharpGraph;

namespace DijkstasAlgorithm
{
    public class GraphTraversal
    {
        private static List<KeyValuePair<Vertex,bool>> alreadyTraversed = new List<KeyValuePair<Vertex,bool>>();
        static List<int> distances = new List<int>();
        public static void TraverseGraph(Graph graph, Vertex sourceVertex, Vertex targetVertex)
        {
            var currentVertex = sourceVertex;
            var distance = 0;
            
            PopulateDictionary(graph);
            //Gets all that are false
            var numberOfVerticesToSearch = alreadyTraversed.FindAll(x => x.Value == false);
            while (numberOfVerticesToSearch.Any())
            {
                foreach (var adjacency in currentVertex.AdjacentVertices)
                {
                    if (alreadyTraversed.Exists(x => x.Key == currentVertex && x.Value == true))
                    {
                        continue;
                    }
                    currentVertex = adjacency.AdjacentVertex;
                    distance += adjacency.Distance;
                    alreadyTraversed.Find(x => x.Key == currentVertex);
                    if (currentVertex == targetVertex)
                    {
                        distances.Add(distance);
                    }
                }
            }

        }

        private static void PopulateDictionary(Graph graph)
        {
       
            //This gets every adjacency and assigns a false (not traversed)
            foreach (var vertex in graph.MyGraph)
            {
                foreach (var adjacency in vertex.AdjacentVertices)
                {
                    var kvp = new List<KeyValuePair<Vertex,bool>>();
                    alreadyTraversed.Add(new KeyValuePair<Vertex, bool>(adjacency.AdjacentVertex, false));
                }
            }
        }
    }
}
