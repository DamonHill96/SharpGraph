using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharpGraph.src
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
            this.VertexID = vertexID;
        }

        public void ValidateID()
        {
            throw new NotImplementedException();
        }

    }
}
