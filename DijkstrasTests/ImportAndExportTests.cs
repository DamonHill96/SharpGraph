using System.IO;
using System.Xml;
using Xunit;
using DijkstasAlgorithm;
using DijkstasAlgorithm.Helpers;
using FluentAssertions;
using SharpGraph;

namespace DijkstrasTests
{
    public class ImportAndExportTests
    {
        [Fact]
        public void Should_return_a_valid_graph()
        {
            var graph = Settings.Load(@"C:\Users\Damon\undirectedtest.xml");
            graph.Should().BeOfType<UndirectedGraph>();
            graph.MyGraph[0].VertexID.Should().Be("Paddington");
            graph.MyGraph[5].AdjacentVertices[1].Distance.Should().Be(16);
            graph.MyGraph[11].AdjacentVertices[2].AdjacentVertex.VertexID.Should().Be("Victoria");
        }

        [Fact]
        public void Should_save_an_xml_file_with_graph()
        {
            var graph = GraphBuilder.ValidUndirected();
            var path = @"C:\Users\Damon\exporttest.xml";


            Settings.Save(graph, path, Settings.GetType(graph), false);
            File.Exists(path).Should().BeTrue();
//Reads the file and checks content to ensure it saved correctly
            XmlDocument doc = new XmlDocument();
            doc.Load(path);
            doc.ChildNodes[0].Attributes[0].InnerText.Should().Be("Undirected");
            doc.ChildNodes[0].ChildNodes[0].ChildNodes[6].Attributes[0].InnerText.Should().Be("Mansion House");
            doc.ChildNodes[0].ChildNodes[0].ChildNodes[9].ChildNodes[2].Attributes[0].InnerText.Should().Be("Canary Wharf");

            File.Delete(path);
        }
    }
}