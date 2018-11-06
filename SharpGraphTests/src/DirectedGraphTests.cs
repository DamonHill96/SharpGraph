using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SharpGraph;
using Xunit;
using Assert = Microsoft.VisualStudio.TestTools.UnitTesting.Assert;

namespace SharpGraphTests
{
    [TestClass()]
    public class DirectedGraphTests
    {
        private readonly Graph graph = new DirectedGraph();
        private readonly Vertex v1 = new Vertex();
        private readonly Vertex v2 = new Vertex("Custom House");
        private readonly Vertex v3 = new Vertex("Prince Regent");

        public DirectedGraphTests()
        {
            graph.MyGraph.Add(v1);
            graph.MyGraph.Add(v2);
            graph.MyGraph.Add(v3);
        }

        [Fact]
        public void Should_be_adjacent()
        {

            v1.AdjacentVertices.Add(new Adjacency(v2));
            v2.AdjacentVertices.Add(new Adjacency(v1));


            Assert.IsTrue(graph.IsAdjacent(v1, v2));
        }

        [Fact]
        public void DirectedNeighborsTest()
        {


            v1.AdjacentVertices.Add(new Adjacency(v2));
            v2.AdjacentVertices.Add(new Adjacency(v1));

            v1.AdjacentVertices.Add(new Adjacency(v3));
            v3.AdjacentVertices.Add(new Adjacency(v1));

            v2.AdjacentVertices.Add(new Adjacency(v3));
            v3.AdjacentVertices.Add(new Adjacency(v2));

            graph.Neighbors(v1);


        }

        [Fact]
        public void Should_add_vertex()
        {
            Graph graph2 = new DirectedGraph();
            graph2.AddVertex(v1);
            graph2.AddVertex(v2);

            Assert.AreEqual("Custom House", graph2.MyGraph[1].VertexID);

        }

        [Fact]
        public void Should_remove_vertex()
        {

            graph.RemoveVertex(v1);
            Assert.AreEqual(2, graph.MyGraph.Count);
        }

        [Fact]
        public void Should_add_edge()
        {
            graph.AddEdge(v1, v2);
            Assert.IsNotNull(graph.MyGraph[0].AdjacentVertices[0]);
        }

        [Fact]
        public void Should_not_add_adjacency_to_self()
        {
            graph.AddEdge(v1, v1);
            graph.MyGraph[0].AdjacentVertices.Should().BeEmpty();
        }

        [Fact]
        public void Should_add_edge_with_distance()
        {
            graph.AddEdge(v1, v2, 16);
            Assert.AreEqual(16, graph.MyGraph[0].AdjacentVertices[0].Distance);
        }

        [Fact]
        public void Should_remove_edge()
        {
            v1.AdjacentVertices.Add(new Adjacency(v2));
            v2.AdjacentVertices.Add(new Adjacency(v1));



            graph.RemoveEdge(v1, v2);
            Assert.AreEqual(0, graph.MyGraph[0].AdjacentVertices.Count);
        }

        [Fact]
        public void Should_get_vertex_id()
        {
            Assert.AreEqual("Custom House", graph.GetVertexValue(v2));
        }

        [Fact]
        public void Should_set_vertex_id()
        {
            graph.SetVertexValue(v1, "14");
            Assert.AreEqual("14", graph.MyGraph[0].VertexID);
        }

        [Fact]
        public void Should_get_distance()
        {
            v1.AdjacentVertices.Add(new Adjacency(v2, 5));
            v2.AdjacentVertices.Add(new Adjacency(v1, 5));


            Assert.AreEqual(5, graph.GetEdgeValue(v1, v2));
        }

        [Fact]
        public void should_set_distance()
        {
            v1.AdjacentVertices.Add(new Adjacency(v2, 5));
            v2.AdjacentVertices.Add(new Adjacency(v1, 5));

            graph.SetEdgeValue(v1, v2, 11);
            Assert.AreEqual(11, graph.MyGraph[0].AdjacentVertices[0].Distance);
        }
    }
}