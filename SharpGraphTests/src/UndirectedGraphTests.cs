using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharpGraph.src
{
    [TestClass()]
    public class UndirectedGraphTests
    {
        Graph graph = new UndirectedGraph();
        Vertex v1 = new Vertex();
        Vertex v2 = new Vertex("Bank");
        Vertex v3 = new Vertex("London Bridge");

        public UndirectedGraphTests()
        {
            graph.MyGraph.Add(v1);
            graph.MyGraph.Add(v2);
            graph.MyGraph.Add(v3);
        }

        [TestMethod()]
        public void UndirectedIsAdjacentTest()
        {

            v1.AdjacentVertices.Add(new Adjacency(v2));
            v2.AdjacentVertices.Add(new Adjacency(v1));


            Assert.IsTrue(graph.IsAdjacent(v1, v2));
        }

        [TestMethod()]
        public void UndirectedNeighborsTest()
        {


            v1.AdjacentVertices.Add(new Adjacency(v2));
            v2.AdjacentVertices.Add(new Adjacency(v1));

            v1.AdjacentVertices.Add(new Adjacency(v3));
            v3.AdjacentVertices.Add(new Adjacency(v1));

            v2.AdjacentVertices.Add(new Adjacency(v3));
            v3.AdjacentVertices.Add(new Adjacency(v2));

            graph.Neighbors(v1);


        }

        [TestMethod()]
        public void UndirectedAddVertexTest()
        {
            Graph graph2 = new UndirectedGraph();
            graph2.AddVertex("Paddington");
            graph2.AddVertex("Old Street");

            Assert.AreEqual("Old Street", graph2.MyGraph[1].VertexID);

        }

        [TestMethod()]
        public void UndirectedRemoveVertexTest()
        {

            graph.RemoveVertex(v1);
            Assert.AreEqual(2, graph.MyGraph.Count);
        }

        [TestMethod()]
        public void UndirectedAddEdgeTest()
        {
            graph.AddEdge(v1, v2);
            Assert.IsNotNull(graph.MyGraph[0].AdjacentVertices[0]);
        }
        [TestMethod()]
        public void UndirectedAddEdgeTestWithDistance()
        {
            graph.AddEdge(v1, v2, 16);
            Assert.AreEqual(16, graph.MyGraph[0].AdjacentVertices[0].Distance);
        }

        [TestMethod()]
        public void UndirectedRemoveEdgeTest()
        {
            v1.AdjacentVertices.Add(new Adjacency(v2));
            v2.AdjacentVertices.Add(new Adjacency(v1));



            graph.RemoveEdge(v1, v2);
            Assert.AreEqual(0, graph.MyGraph[0].AdjacentVertices.Count);
        }

        [TestMethod()]
        public void UndirectedGetVertexValueTest()
        {
            Assert.AreEqual("Bank", graph.GetVertexValue(v2));
        }

        [TestMethod()]
        public void UndirectedSetVertexValueTest()
        {
            graph.SetVertexValue(v1, "Waterloo");
            Assert.AreEqual("Waterloo", graph.MyGraph[0].VertexID);
        }

        [TestMethod()]
        public void UndirectedGetEdgeValueTest()
        {
            v1.AdjacentVertices.Add(new Adjacency(v2, 5));
            v2.AdjacentVertices.Add(new Adjacency(v1, 5));


            Assert.AreEqual(5, graph.GetEdgeValue(v1, v2));
        }

        [TestMethod()]
        public void UndirectedSetEdgeValueTest()
        {
            v1.AdjacentVertices.Add(new Adjacency(v2, 5));
            v2.AdjacentVertices.Add(new Adjacency(v1, 5));

            graph.SetEdgeValue(v1, v2, 11);
            Assert.AreEqual(11, graph.MyGraph[0].AdjacentVertices[0].Distance);
        }
    }
}