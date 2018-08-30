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
    public class DirectedGraphTests
    {
        Graph graph = new DirectedGraph();
        Vertex v1 = new Vertex();
        Vertex v2 = new Vertex(7);
        Vertex v3 = new Vertex(10);

        public DirectedGraphTests()
        {
            graph.MyGraph.Add(v1);
            graph.MyGraph.Add(v2);
            graph.MyGraph.Add(v3);
        }

        [TestMethod()]
        public void IsAdjacentTest()
        {

            v1.AdjacentVertices.Add(new Adjacency(v2));
            v2.AdjacentVertices.Add(new Adjacency(v1));


            Assert.IsTrue(graph.IsAdjacent(v1, v2));
        }

        [TestMethod()]
        public void NeighborsTest()
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
        public void AddVertexTest()
        {
            Graph graph2 = new DirectedGraph();
            graph2.AddVertex(v1);
            graph2.AddVertex(v2);

            Assert.AreEqual(7, graph2.MyGraph[1].VertexID);

        }

        [TestMethod()]
        public void RemoveVertexTest()
        {

            graph.RemoveVertex(v1);
            Assert.AreEqual(2, graph.MyGraph.Count);
        }

        [TestMethod()]
        public void AddEdgeTest()
        {
            graph.AddEdge(v1, v2);
            Assert.IsNotNull(graph.MyGraph[0].AdjacentVertices[0]);
        }
        [TestMethod()]
        public void AddEdgeTestWithDistance()
        {
            graph.AddEdge(v1, v2, 16);
            Assert.AreEqual(16, graph.MyGraph[0].AdjacentVertices[0].Distance);
        }

        [TestMethod()]
        public void RemoveEdgeTest()
        {
            v1.AdjacentVertices.Add(new Adjacency(v2));
            v2.AdjacentVertices.Add(new Adjacency(v1));



            graph.RemoveEdge(v1, v2);
            Assert.AreEqual(0, graph.MyGraph[0].AdjacentVertices.Count);
        }

        [TestMethod()]
        public void GetVertexValueTest()
        {
            Assert.AreEqual(7, graph.GetVertexValue(v2));
        }

        [TestMethod()]
        public void SetVertexValueTest()
        {
            graph.SetVertexValue(v1, 14);
            Assert.AreEqual(14, graph.MyGraph[0].VertexID);
        }

        [TestMethod()]
        public void GetEdgeValueTest()
        {
            v1.AdjacentVertices.Add(new Adjacency(v2, 5));
            v2.AdjacentVertices.Add(new Adjacency(v1, 5));


            Assert.AreEqual(5, graph.GetEdgeValue(v1, v2));
        }

        [TestMethod()]
        public void SetEdgeValueTest()
        {
            v1.AdjacentVertices.Add(new Adjacency(v2, 5));
            v2.AdjacentVertices.Add(new Adjacency(v1, 5));

            graph.SetEdgeValue(v1, v2, 11);
            Assert.AreEqual(11, graph.MyGraph[0].AdjacentVertices[0].Distance);
        }
    }
}