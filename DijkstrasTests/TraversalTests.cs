using System;
using System.Collections.Generic;
using System.Text;
using DijkstasAlgorithm;
using DijkstasAlgorithm.Helpers;
using Xunit;

namespace DijkstrasTests
{
    public class TraversalTests
    {
        [Fact]
        public void Should_have_false_value_for_all_adjacencies()
        {
            var graph = GraphBuilder.ValidUndirected();
            GraphTraversal.TraverseGraph(graph, graph.MyGraph[8], graph.MyGraph[2]);
        }
    }
}
