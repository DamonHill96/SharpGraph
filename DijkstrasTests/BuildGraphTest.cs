using System;
using System.IO;
using System.Linq;
using System.Xml;
using Xunit;
using DijkstasAlgorithm;
using DijkstasAlgorithm.Helpers;
using FluentAssertions;
using SharpGraph;

namespace DijkstrasTests
{
    public class BuildGraphTest
    {
        
        [Fact]
        public void Should_return_directed_graph()
        {
            var Graph = BuildGraph.SetGraphType(2);
            Graph.Should().BeOfType<DirectedGraph>();
        } 
        
        [Fact]
        public void Should_return_undirected_graph()
        {
            var Graph = BuildGraph.SetGraphType(1);
            Graph.Should().BeOfType<UndirectedGraph>();
        }

        [Fact]
        public void invalid_graph_type_should_return_null()
        {
            var graph = BuildGraph.SetGraphType(3);
            graph.Should().BeNull();
        }

        [Fact]
        public void Should_add_a_vertex()
        {
            BuildGraph.graph = new UndirectedGraph();
            Console.SetIn(new StringReader("DummyName"));
            BuildGraph.Build(2);

            BuildGraph.graph.MyGraph[0].VertexID.Should().Be("DummyName");
        }

        [Fact]
        public void Should_add_an_adjacency()
        {
            BuildGraph.graph = GraphBuilder.ValidUndirected();
            var vertexIndex = new Random();
            var randomDistance = new Random();

            var index1 = vertexIndex.Next(1, 14);
            var index2 = vertexIndex.Next(1, 14);
            var distance = vertexIndex.Next(1, 100);
            //2 random vertexes to add and a random distance         
            BuildGraph.AddAdjacency(BuildGraph.graph.MyGraph[index1], BuildGraph.graph.MyGraph[index2], distance);
            var result = BuildGraph.graph;

            result.MyGraph[index1].AdjacentVertices[result.MyGraph[index1].AdjacentVertices.Count - 1].AdjacentVertex
                .VertexID.Should()
                .Be(result.MyGraph[index2].VertexID);
            
            result.MyGraph[index1].AdjacentVertices[result.MyGraph[index1].AdjacentVertices.Count - 1].Distance.Should()
                .Be(distance);
        }
    }
}