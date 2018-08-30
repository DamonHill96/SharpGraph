using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
namespace SharpGraph.src
{
    public static class Settings
    {
        public enum GraphType
        {
            Undirected,
            Directed
        }
        #region Saving
        /// <summary>
        /// Save the graph in XML Format
        /// </summary>
        public static void Save(Graph graph, string path, GraphType type)
        {
            XmlDocument doc = new XmlDocument();
            XmlNode root = doc.CreateElement("graph");
            doc.AppendChild(root);

            XmlAttribute graphType = doc.CreateAttribute("type");
            graphType.Value = type.ToString();
            root.Attributes.Append(graphType);

            XmlNode vertices = doc.CreateElement("vertices");
            root.AppendChild(vertices);

            foreach (Vertex v in graph.MyGraph)
            {
                var vertexid = v.VertexID;
                var adjacentVertices = v.AdjacentVertices;

                XmlNode vertex = doc.CreateElement("vertex");
                vertices.AppendChild(vertex);
                XmlAttribute attribute = doc.CreateAttribute("id");
                attribute.Value = vertexid.ToString();
                vertex.Attributes.Append(attribute);



                foreach (Adjacency a in adjacentVertices)
                {
                    XmlNode adjacencies = doc.CreateElement("adjacency");
                    vertex.AppendChild(adjacencies);
                    XmlAttribute idAttr = doc.CreateAttribute("id");
                    XmlAttribute distanceAttr = doc.CreateAttribute("Distance");

                    idAttr.Value = a.AdjacentVertex.VertexID.ToString();
                    distanceAttr.Value = a.Distance.ToString();

                    adjacencies.Attributes.Append(idAttr);
                    adjacencies.Attributes.Append(distanceAttr);
                }
            }
            doc.Save(path);

        }
        #endregion

        #region Loading
        public static Graph Load(string path)
        {
            XmlDocument doc = new XmlDocument();
            
            doc.Load(path);

            var graphType = doc.DocumentElement.GetAttribute("type");
            Graph graph = InstantiateGraphType(graphType);

            XmlNodeList list = doc.SelectNodes("graph//vertices//vertex");

            //Loads in each vertex
            foreach (XmlNode x in list)
            {
                int id = int.Parse(x.Attributes["id"].Value);

                graph.AddVertex(LoadVertices(id));

            }

            LoadAdjacencies(graph, list);
            return graph;
        }

        private static Graph InstantiateGraphType(string type)
        {
            switch (type)
            {
                case "Undirected": return new UndirectedGraph(); 
                case "Directed": return new DirectedGraph();
            }
            return null;
        }

        private static void LoadAdjacencies(Graph graph, XmlNodeList list)
        {
            for (int i = 0; i < list.Count; i++) // For each vertex that has been loaded
            {
                Vertex currentVertex = graph.MyGraph[i];
                foreach (XmlNode node in list[i].ChildNodes) //Get each adjacency that has been saved
                {
                    var id = int.Parse(node.Attributes["id"].Value);
                    var distance = int.Parse(node.Attributes["Distance"].Value);

                    currentVertex.AdjacentVertices.Add(new Adjacency(graph.MyGraph.Find(x => x.VertexID == id), distance));
                }

            }
        }

        private static Vertex LoadVertices(int id)
        {

            Vertex v = new Vertex(id);
            return v;
        }
        #endregion
    }

}
