using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
namespace SharpGraph.src
{
    public static class Settings
    {
        private static XmlDocument doc = null;

        public enum GraphType
        {
            Undirected,
            Directed
        }
        #region Saving
        /// <summary>
        /// Save the graph in XML Format
        /// </summary>
    
        /// <param name="path">Path to save the file to. Make sure it has a .xml file extension</param>
        /// <param name="type">Access through Settings.GraphType</param>
        public static void Save(Graph graph, string path, GraphType type)
        {
            try
            {


                doc = new XmlDocument();
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
                    XmlAttribute id = doc.CreateAttribute("id");
                    id.Value = vertexid.ToString();
                    vertex.Attributes.Append(id);

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
            }catch (XmlException)
            {
                throw;
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

                var graphType = doc.DocumentElement.GetAttribute("type");
                Graph graph = InstantiateGraphType(graphType);

                XmlNodeList list = doc.SelectNodes("graph//vertices//vertex");

                //Loads in each vertex
                //TODO allow id to be more than just int
                foreach (XmlNode x in list)
                {
                    string id = x.Attributes["id"].Value;

                    graph.AddVertex(LoadVertices(id));
                    
                }

                LoadAdjacencies(graph, list);
                return graph;
            } catch (XmlException)
            {
                throw;
            }catch (FileNotFoundException) 
            {
                throw;
            }
            catch (Exception)
            {
                throw;
            }
           
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
            for (int i = 0; i < list.Count; i++) // For each vertex in the file
            {
                Vertex currentVertex = graph.MyGraph[i];
                foreach (XmlNode node in list[i].ChildNodes) //Get each adjacency that has been saved
                {
                    var id = node.Attributes["id"].Value;
                    var distance = int.Parse(node.Attributes["Distance"].Value);

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
