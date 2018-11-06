using System;
using System.Diagnostics;
using System.Xml;

namespace SharpGraph
{
    public static class Settings
    {
        private static XmlDocument doc;

        public enum GraphType
        {
            Undirected,
            Directed
        }

        public static GraphType GetType(Graph graph)
        {
            if (graph.GetType() == typeof(UndirectedGraph))
            {
                return GraphType.Undirected;
            }

            return graph.GetType() == typeof(DirectedGraph) ? GraphType.Directed : default(GraphType);
        }
        #region Saving

        /// <summary>
        /// Save the graph in XML Format
        /// </summary>
        /// <param name="graph">Your Graph Variable (MyGraph)</param>
        /// <param name="path">Path to save the file to. Make sure it has a .xml file extension</param>
        /// <param name="type">Access through Settings.GraphType</param>
        /// <param name="shouldOpen">Specifies if the saved file should be opened after saving (with default text editor)</param>
        public static void Save(Graph graph, string path, GraphType type, bool shouldOpen)
        {
            doc = new XmlDocument();
            XmlNode root = doc.CreateElement("graph");
            doc.AppendChild(root);

            XmlAttribute graphType = doc.CreateAttribute("type");
            graphType.Value = type.ToString();
            root.Attributes?.Append(graphType);

            XmlNode vertices = doc.CreateElement("vertices");
            root.AppendChild(vertices);

            foreach (Vertex v in graph.MyGraph)
            {
                var vertexid = v.VertexID;
                var adjacentVertices = v.AdjacentVertices;

                XmlNode vertex = doc.CreateElement("vertex");
                vertices.AppendChild(vertex);
                XmlAttribute id = doc.CreateAttribute("id");
                id.Value = vertexid;
                vertex.Attributes?.Append(id);

                foreach (Adjacency a in adjacentVertices)
                {
                    XmlNode adjacencies = doc.CreateElement("adjacency");
                    vertex.AppendChild(adjacencies);
                    XmlAttribute idAttr = doc.CreateAttribute("id");
                    XmlAttribute distanceAttr = doc.CreateAttribute("Distance");

                    idAttr.Value = a.AdjacentVertex.VertexID;
                    distanceAttr.Value = a.Distance.ToString();

                    adjacencies.Attributes?.Append(idAttr);
                    adjacencies.Attributes?.Append(distanceAttr);
                }
            }
            doc.Save(path);

            if (shouldOpen)
            {
                Process.Start(path);
            }
        }


        #endregion

        #region Loading

        /// <summary>
        /// Loads a graph from an XML file.
        /// </summary>
        public static Graph Load(string path)
        {
            try
            {
                doc = new XmlDocument();

                doc.Load(path);

                var graphType = doc.DocumentElement?.GetAttribute("type");
                Graph graph = InstantiateGraphType(graphType);

                XmlNodeList list = doc.SelectNodes("graph//vertices//vertex");

                //Loads in each vertex

                if (list != null)
                {
                    foreach (XmlNode x in list)
                    {
                        var id = x.Attributes?["id"].Value;

                        graph.AddVertex(LoadVertices(id));
                    }

                    LoadAdjacencies(graph, list);
                }

                return graph;
            }
            catch (Exception e)
            {
                Logger.Log("An error occured while reading the file.");
                Console.WriteLine("An error occured while reading the file.");
                return null;
            }
        }

        private static Graph InstantiateGraphType(string type)
        {
            if (type == "Undirected")
                return new UndirectedGraph();
            return type != "Directed" ? null : new DirectedGraph();
        }

        private static void LoadAdjacencies(Graph graph, XmlNodeList list)
        {
            for (int i = 0; i < list.Count; i++) // For each vertex in the file
            {
                var currentVertex = graph.MyGraph[i];
                foreach (XmlNode node in list[i].ChildNodes) //Get each adjacency that has been saved
                {
                    var id = node.Attributes?["id"].Value;
                    var distance = int.Parse(node.Attributes?["Distance"].Value ?? throw new InvalidOperationException());

                    currentVertex.AdjacentVertices.Add(new Adjacency(graph.MyGraph.Find(x => x.VertexID == id), distance));
                }
            }
        }

        private static Vertex LoadVertices(string id)
        {
            return new Vertex(id);
        }
        #endregion
    }

}
