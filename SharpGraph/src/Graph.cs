using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharpGraph.src
{
    public abstract class Graph
    {

        // access this by objName.MyGraph
        public List<Vertex> MyGraph { get; set; }

        /// <summary>
        /// Checks if two Vertices are adjacent to each other
        /// </summary>
        public abstract bool IsAdjacent(Vertex a, Vertex b);

        /// <summary>
        /// Prints all nodes adjacent to the one passed as a parameter
        /// </summary>
        public abstract void Neighbors(Vertex a);

        /// <summary>
        /// Add a new Vertex to the graph
        /// </summary>
        public abstract void AddVertex(Vertex a);

        /// <summary>
        /// Removes a vertex from the graph
        /// </summary>
        public abstract void RemoveVertex(Vertex a);

        /// <summary>
        /// Adds an unweighted connection between two vertices
        /// </summary>
        public abstract void AddEdge(Vertex a, Vertex b);

        /// <summary>
        /// Adds a weighted connection between two vertices
        /// </summary>
        public abstract void AddEdge(Vertex a, Vertex b, int distance);

        /// <summary>
        /// Removes a connection linking two vertices
        /// </summary>
        public abstract void RemoveEdge(Vertex a, Vertex b);

        /// <summary>
        /// Returns the ID of a vertex (Can also be done through Vertex.VertexID)
        /// </summary>
        public abstract int GetVertexValue(Vertex a);

        /// <summary>
        /// Sets the ID of a Vertex (Can also be done through Vertex.VertexID)
        /// </summary>
        public abstract void SetVertexValue(Vertex a, int newValue);

        /// <summary>
        /// Returns the Distance between two vertices
        /// </summary>
        public abstract int GetEdgeValue(Vertex a, Vertex b);

        /// <summary>
        /// Sets Distance between two vertices
        /// </summary>
        public abstract void SetEdgeValue(Vertex a, Vertex b, int newDistance);
                
    }
}
