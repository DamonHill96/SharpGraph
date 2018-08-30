using Microsoft.VisualStudio.TestTools.UnitTesting;
using SharpGraph.src;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharpGraph.src.Tests
{
    [TestClass()]
    public class SettingsTests
    {
        [TestMethod()]
        public void SaveTest()
        {
            Graph graph = new UndirectedGraph();

            Vertex v1 = new Vertex(4);
            Vertex v2 = new Vertex(7);
            Vertex v3 = new Vertex(10);

            graph.MyGraph.Add(v1);
            graph.MyGraph.Add(v2);
            graph.MyGraph.Add(v3);

            graph.AddEdge(v1, v2);
            graph.AddEdge(v1, v3, 7);


            Settings.Save(graph, @"C:\Users\Damon\test.xml", Settings.GraphType.Undirected);
        }

        [TestMethod()]
        public void LoadTest()
        {
            Graph graph = new UndirectedGraph();

            Vertex v1 = new Vertex(4);
            Vertex v2 = new Vertex(7);
            Vertex v3 = new Vertex(10);

            graph.MyGraph.Add(v1);
            graph.MyGraph.Add(v2);
            graph.MyGraph.Add(v3);

            graph.AddEdge(v1, v2);
            graph.AddEdge(v1, v3, 7);
            Graph loadedGraph = Settings.Load(@"C:\Users\Damon\test.xml");
            Assert.IsTrue(graph.MyGraph[1].AdjacentVertices[0].Distance == loadedGraph.MyGraph[1].AdjacentVertices[0].Distance);
            Assert.IsTrue(graph.MyGraph[0].AdjacentVertices[1].Distance == loadedGraph.MyGraph[0].AdjacentVertices[1].Distance);
            
        }

        
    }
}