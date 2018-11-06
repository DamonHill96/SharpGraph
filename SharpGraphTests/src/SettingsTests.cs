using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SharpGraph;
using Xunit;
using Assert = Microsoft.VisualStudio.TestTools.UnitTesting.Assert;

namespace SharpGraphTests
{
    public class SettingsTests
    {
        [Fact]
        public void UndirectedSaveTest()
        {
            Graph graph = new UndirectedGraph();

            Vertex v1 = new Vertex("Paddington");
            Vertex v2 = new Vertex("London Bridge");
            Vertex v3 = new Vertex("Victoria");
            Vertex v4 = new Vertex("Bank");
            Vertex v5 = new Vertex("Old Street");
            Vertex v6 = new Vertex("Gloucester Road");
            Vertex v7 = new Vertex("Mansion House");
            Vertex v8 = new Vertex("Canary Wharf");
            Vertex v9 = new Vertex("Lewisham");
            Vertex v10 = new Vertex("Custom House");
            Vertex v11 = new Vertex("Canning Town");
            Vertex v12 = new Vertex("East India");
            Vertex v13 = new Vertex("Prince Regent");
            Vertex v14 = new Vertex("King's Cross");
            Vertex v15 = new Vertex("Waterloo");

            graph.MyGraph.Add(v1);
            graph.MyGraph.Add(v2);
            graph.MyGraph.Add(v3);
            graph.MyGraph.Add(v4);
            graph.MyGraph.Add(v5);
            graph.MyGraph.Add(v6);
            graph.MyGraph.Add(v7);
            graph.MyGraph.Add(v8);
            graph.MyGraph.Add(v9);
            graph.MyGraph.Add(v10);
            graph.MyGraph.Add(v11);
            graph.MyGraph.Add(v12);
            graph.MyGraph.Add(v13);
            graph.MyGraph.Add(v14);
            graph.MyGraph.Add(v15);

            graph.AddEdge(v1, v2);
            graph.AddEdge(v1, v3, 7);
            graph.AddEdge(v12, v6, 64);
            graph.AddEdge(v4, v3, 1);
            graph.AddEdge(v1, v7, 43);
            graph.AddEdge(v1, v13, 12);
            graph.AddEdge(v12, v14, 9);
            graph.AddEdge(v15, v6, 16);
            graph.AddEdge(v7, v9, 25);
            graph.AddEdge(v5, v10, 96);
            graph.AddEdge(v8, v11, 71);
            graph.AddEdge(v11, v15, 37);
            graph.AddEdge(v3, v2, 42);
            graph.AddEdge(v8, v9, 82);
            graph.AddEdge(v1, v10, 81);
            graph.AddEdge(v8, v10, 45);
            graph.AddEdge(v14, v10, 48);
            graph.AddEdge(v12, v3, 94);
            graph.AddEdge(v9, v10, 60);
            graph.AddEdge(v9, v6, 70);


            Settings.Save(graph, @"C:\Users\Damon\undirectedtest.xml", Settings.GraphType.Undirected, false);
        }

        [Fact]
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


            Settings.Save(graph, @"C:\Users\Damon\directedtest.xml", Settings.GraphType.Directed, false);
        }

        [Fact]
        public void UndirectedLoadTest()
        {
           
            Graph graph = Settings.Load(@"C:\Users\Damon\undirectedtest.xml");
            graph.MyGraph[0].VertexID.Should().Be("Paddington");
            graph.MyGraph[5].AdjacentVertices[1].Distance.Should().Be(16);
            graph.MyGraph[11].AdjacentVertices[2].AdjacentVertex.VertexID.Should().Be("Victoria");

        }

        [Fact]
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
        [Fact]
        public void LoggerTest()
        {
            UndirectedGraph graph = new UndirectedGraph();

            Vertex v1 = new Vertex("1");
            Vertex v2 = new Vertex("London Bridge");
            Vertex v3 = new Vertex("Victoria");

            graph.MyGraph.Add(v1);
            graph.MyGraph.Add(v2);
            graph.MyGraph.Add(v3);

            graph.AddEdge(v1, v2);
            graph.AddEdge(v1, v3, 7);
            

            
        }

        
    }
}