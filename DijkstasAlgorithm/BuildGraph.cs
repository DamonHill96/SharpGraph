using System;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Xml;
using DijkstasAlgorithm.Helpers;
using SharpGraph;

namespace DijkstasAlgorithm
{
    public class BuildGraph
    {
        public static Graph graph { get; set; }

        public static Graph BuildMenu()
        {
            while (true)
            {
                Console.Clear();
                int choice;
                Console.WriteLine("Please make a choice:");
                Console.WriteLine("1. Set Graph Type");
                Console.WriteLine("2. Add a Vertex");
                Console.WriteLine("3. View Current Graph");
                Console.WriteLine("4. Add an adjaceny");
                Console.WriteLine("5. Create Random Graph");
                Console.WriteLine("6. Back");

                choice = int.Parse(Console.ReadLine());
                if (choice == 6)
                {
                    return graph;
                }

                Build(choice);
            }
        }

        public static void Build(int choice)
        {
            switch (choice)
            {
                case 1:
                    graph = SetGraphTypeMenu();
                    break;
                case 2:
                    CheckGraphStatus();
                    graph.AddVertex(
                        ConsoleHelpers.ReadLineAfterDisplayingMessage("Please enter a name for your vertex: "));
                    break;
                case 3:
                    CheckGraphStatus();
                    ViewGraph.View(graph);
                    break;
                case 4:
                    CheckGraphStatus();
                    ListVertex();
                    var v1 = GetFirstVertex();
                    var v2 = GetSecondVertex();
                    var distance = GetDistance();
                    AddAdjacency(v1, v2, distance);
                    break;
               
                case 5: 
                    graph = (Graph) GraphBuilder.ValidRandom()[0];
                    break;
                default: break;
            }
        }

        private static void ListVertex()
        {
            var i = 0;
            foreach (var vertex in graph.MyGraph)
            {
                Console.WriteLine("{0}. {1}",++i, vertex.VertexID);
            }
        }

        public static void AddAdjacency(Vertex v1, Vertex v2, int distance)
        {
            graph.AddEdge(v1, v2, distance);
        }

        private static int GetDistance()
        {
            var distance = 0;
            try
            {
                distance =
                    int.Parse(ConsoleHelpers.ReadLineAfterDisplayingMessage(
                        "Please specify a distance (or 0 for no distance"));
            }
            catch (Exception)
            {
                return 0; //Just return a default value
            }

            return distance;
        }

        public static Vertex GetFirstVertex()
        {
            while (true)
            {
                var v1 = ConsoleHelpers.ReadLineAfterDisplayingMessage(
                    "Please enter the number of your first vertex (or ^e to exit)");
                if (v1 == "^e")
                {
                    BuildMenu();
                }

                var result = graph.MyGraph[int.Parse(v1) - 1];
                if (result != null)
                {
                    return result;
                }

                Console.WriteLine("A vertex with that ID does not exist!");
            }
        }

        public static Vertex GetSecondVertex()
        {
            while (true)
            {
                var v2 = ConsoleHelpers.ReadLineAfterDisplayingMessage(
                    "Please enter the number of your second vertex (or ^e to exit)");
                if (v2 == "^e")
                {
                    BuildMenu();
                }

                var result = graph.MyGraph[int.Parse(v2) - 1];
                if (result != null)
                {
                    return result;
                }

                Console.WriteLine("A vertex with that ID does not exist!");
            }
        }

        private static void CheckGraphStatus()
        {
            if (graph != null) return;
            Console.WriteLine("You need to specify a type first");
            Build(1);
        }

        private static Graph SetGraphTypeMenu()
        {
            Console.WriteLine("1. Undirected Graph");
            Console.WriteLine("2. Directed Graph");
            Console.WriteLine("3. Back");
            var choice = int.Parse(Console.ReadLine());
            return choice == 3 ? graph : SetGraphType(choice);
        }

        public static Graph SetGraphType(int choice)
        {
            switch (choice)
            {
                case 1:
                    return new UndirectedGraph();
                case 2:
                    return new DirectedGraph();
                default:
                    Console.WriteLine("Error");
                    return null;
            }
        }
    }
}