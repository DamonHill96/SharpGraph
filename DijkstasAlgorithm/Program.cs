using System;
using DijkstasAlgorithm.Helpers;
using SharpGraph;

namespace DijkstasAlgorithm
{
    class Program
    {
        static void Main(string[] args)
        {
            Graph graph = null;
            while (true)
            {
                Console.Clear();
                int choice;
                Console.WriteLine("Please make a choice:");
                Console.WriteLine("1. Build Graph");
                Console.WriteLine("2. Import Graph");
                Console.WriteLine("3. Export Graph");
                Console.WriteLine("4. Traverse Graph");
                Console.WriteLine("5. View Current Graph");
                choice = int.Parse(Console.ReadLine());
                string path;
                
                switch (choice)
                {
                    case 1:
                        BuildGraph.graph = graph;
                        BuildGraph.BuildMenu();
                        break;
                    case 2:
                        path = ConsoleHelpers.ReadLineAfterDisplayingMessage("Please enter the path to your graph xml file");
                        graph = Settings.Load(path);
                        break;
                    case 3:
                        path = ConsoleHelpers.ReadLineAfterDisplayingMessage("Please enter path to save file to.");
                        Settings.Save(graph, path, Settings.GetType(graph), false);
                        break;   
                    case 4:
                        var i = 0;
                        foreach (var vertex in graph.MyGraph)
                        {
                            Console.WriteLine("{0}. {1}", ++i, vertex.VertexID);
                        }

                        var source = BuildGraph.GetFirstVertex();
                        var target = BuildGraph.GetSecondVertex();
                        GraphTraversal.TraverseGraph(graph, source, target);
                        break;
                    case 5:
                        ViewGraph.View(graph);
                        break;
                    default: break;
                }
            }
        }
    }
}