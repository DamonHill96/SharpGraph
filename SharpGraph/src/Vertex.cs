using System;
using System.Collections.Generic;

namespace SharpGraph
{
   public class Vertex
    {
        public string VertexID { get; set; }
        public List<Adjacency> AdjacentVertices { get; set; } = new List<Adjacency>();

        public Vertex()
        {
        }

        public Vertex(string vertexID)
        {
            VertexID = vertexID;
        }

        public void ValidateID()
        {
            throw new NotImplementedException();
        }

    }
}
