using System;
using System.IO;
using DijkstasAlgorithm;
using DijkstasAlgorithm.Helpers;
using DijkstasAlgorithm.Helpers;
using FluentAssertions;
using SharpGraph;
using Xunit;

namespace DijkstrasTests
{
    public class HelpersTests
    {
        [Fact]
        public void Should_return_valid_graph()
        {
            var graph = GraphBuilder.ValidUndirected();

            graph.MyGraph[0].VertexID.Should().Be("Paddington");
            graph.MyGraph[7].AdjacentVertices.Count.Should().Be(3);
            graph.MyGraph[9].AdjacentVertices[3].Distance.Should().Be(48);
            graph.MyGraph[9].AdjacentVertices[3].AdjacentVertex.VertexID.Should().Be("King's Cross");
        }

        [Fact]
        public void Should_return_valid_random_graph()
        {
            var list = GraphBuilder.ValidRandom();
            var graph = (Graph) list[0];
            var vertices = (int) list[1];
            var adjacencies = (int) list[2];

            graph.MyGraph.Count.Should().Be(vertices);

        }

        [Fact]
        public void Should_output_and_wait_for_input()
        {
            Console.SetIn(new StringReader("contract"));
            var text = ConsoleHelpers.ReadLineAfterDisplayingMessage("ffff");
            
            text.Should().Be("contract");
        }

      
    }
}