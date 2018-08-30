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
        public void UndirectedSaveTest()
        {
            Graph graph = new UndirectedGraph();

            Vertex v1 = new Vertex("1");
            Vertex v2 = new Vertex("London Bridge");
            Vertex v3 = new Vertex("Victoria");

            graph.MyGraph.Add(v1);
            graph.MyGraph.Add(v2);
            graph.MyGraph.Add(v3);

            graph.AddEdge(v1, v2);
            graph.AddEdge(v1, v3, 7);


            Settings.Save(graph, @"C:\Users\Damon\undirectedtest.xml", Settings.GraphType.Undirected);
        }

        [TestMethod()]
        public void DirectedSaveTest()
        {
            Graph graph = new DirectedGraph();

            Vertex v1 = new Vertex("1");
            Vertex v2 = new Vertex("London Bridge");
            Vertex v3 = new Vertex("Victoria");

            graph.MyGraph.Add(v1);
            graph.MyGraph.Add(v2);
            graph.MyGraph.Add(v3);

            graph.AddEdge(v1, v2);
            graph.AddEdge(v1, v3, 7);


            Settings.Save(graph, @"C:\Users\Damon\directedtest.xml", Settings.GraphType.Directed);
        }

        [TestMethod()]
        public void UndirectedLoadTest()
        {
            Graph graph = new UndirectedGraph();

            Vertex v1 = new Vertex();
            Vertex v2 = new Vertex("London Bridge");
            Vertex v3 = new Vertex("Victoria");

            graph.MyGraph.Add(v1);
            graph.MyGraph.Add(v2);
            graph.MyGraph.Add(v3);

            graph.AddEdge(v1, v2);
            graph.AddEdge(v1, v3, 7);
            Graph loadedGraph = Settings.Load(@"C:\Users\Damon\undirectedtest.xml");
            Assert.IsTrue(graph.MyGraph[1].VertexID == loadedGraph.MyGraph[1].VertexID);
            Assert.IsTrue(graph.MyGraph[0].AdjacentVertices[1].Distance == loadedGraph.MyGraph[0].AdjacentVertices[1].Distance);
            Assert.AreEqual("Victoria", graph.MyGraph[2].VertexID);
        }

        [TestMethod()]
        public void DirectedLoadTest()
        {
            Graph graph = new DirectedGraph();

            Vertex v1 = new Vertex();
            Vertex v2 = new Vertex("London Bridge");
            Vertex v3 = new Vertex("Victoria");

            graph.MyGraph.Add(v1);
            graph.MyGraph.Add(v2);
            graph.MyGraph.Add(v3);

            graph.AddEdge(v1, v2);
            graph.AddEdge(v1, v3, 7);
            Graph loadedGraph = Settings.Load(@"C:\Users\Damon\directedtest.xml");
            Assert.IsTrue(graph.MyGraph[1].VertexID == loadedGraph.MyGraph[1].VertexID);
            Assert.IsTrue(graph.MyGraph[0].AdjacentVertices[1].Distance == loadedGraph.MyGraph[0].AdjacentVertices[1].Distance);
            Assert.AreEqual("Victoria", graph.MyGraph[2].VertexID);
        }

        //Done here because static class
        [TestMethod()]
        public void LoggerTest()
        {
            UndirectedGraph loadedGraph = (UndirectedGraph) Settings.Load(@"C:\Users\Damon\undirectedtest.xml");
            loadedGraph.ListAllAdjacencies(loadedGraph);
        }

        
    }
}