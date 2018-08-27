using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharpGraph.src
{
   public class Adjacency
    {
        public Adjacency()
        {
        }

        public Adjacency(Vertex adjacentVertex)
        {
            AdjacentVertex = adjacentVertex;
          
        }
        public Adjacency(Vertex adjacentVertex, int distance)
        {
            AdjacentVertex = adjacentVertex;
            Distance = distance;
          
        }

        public Vertex AdjacentVertex { get; set; }
        public int Distance { get; set; }


    }
}
