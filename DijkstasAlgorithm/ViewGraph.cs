using System;
using System.Linq;
using DijkstasAlgorithm.Helpers;
using SharpGraph;

namespace DijkstasAlgorithm
{
    class ViewGraph
    {
        public static void View(Graph graph)
        {
            try
            {
                Console.WriteLine("You currently have {0} elements in your graph.", graph.MyGraph.Count);
                Console.WriteLine(Environment.NewLine);
                foreach (var v in graph.MyGraph)
                {
                    Console.WriteLine(v.VertexID);
                    Console.WriteLine(" You currently have {0} adjacencies in this Vertex", v.AdjacentVertices.Count());
                    foreach (var adjacentVertex in v.AdjacentVertices)
                    {

                        Console.WriteLine("  {0}", adjacentVertex.AdjacentVertex.VertexID);
                        Console.Write("   Distance: {0}", adjacentVertex.Distance);
                        Console.WriteLine(Environment.NewLine);
                    }

                }

                Console.WriteLine("Your Graph is of type {0}", graph.GetType());
                ConsoleHelpers.PressAnyKeyToContinue();
            }
            catch (NullReferenceException)
            {
                Console.WriteLine("Looks like you don't have a graph set up!");
            }
        }
    }
}