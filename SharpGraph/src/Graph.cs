using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dijkstra_s_Algorithm.src.Graph
{
    public abstract class Graph
    {
        public List<Vertex> MyGraph { get; set; }

        public abstract bool IsAdjacent(Vertex a, Vertex b);
        public abstract void Neighbors(Vertex a);
        public abstract void AddVertex(Vertex a);
        public abstract void RemoveVertex(Vertex a);
        public abstract void AddEdge(Vertex a, Vertex b);
        public abstract void RemoveEdge(Vertex a, Vertex b);
        public abstract int GetVertexValue(Vertex a);
        public abstract void SetVertexValue(Vertex a, int newValue);
        public abstract int GetEdgeValue(Vertex a, Vertex b);
        public abstract void SetEdgeValue(Vertex a, Vertex b, int newDistance);
                
    }
}
