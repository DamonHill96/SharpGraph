﻿using System;
using System.Collections.Generic;

namespace SharpGraph
{
    public class UndirectedGraph : Graph
    {
        public UndirectedGraph()
        {

            VertexIDCounter = 1;
            MyGraph = new List<Vertex>();

        }

        //This is only used if an id is not constructed when a Vertex object is created
        //TODO unique id for each vertex
        public int VertexIDCounter { get; set; }

        public override void ClearGraph()
        {
            MyGraph.Clear();
        }

        public override void AddEdge(Vertex a, Vertex b)
        {
            if (a.Equals(b))
            {
                Console.WriteLine("Cannot add adjacency to itself!");
                return;
            }

            a.AdjacentVertices.Add(new Adjacency(b));
            b.AdjacentVertices.Add(new Adjacency(a));


            //Replaces originals with the updated vertex
            MyGraph[MyGraph.FindIndex(x => x.VertexID == a.VertexID)] = a;
            MyGraph[MyGraph.FindIndex(x => x.VertexID == b.VertexID)] = b;
        }
        public override void AddEdge(Vertex a, Vertex b, int distance)
        {
            if (a.Equals(b))
            {
                Console.WriteLine("Cannot add adjacency to itself!");
                return;
            }

            a.AdjacentVertices.Add(new Adjacency(b, distance));
            b.AdjacentVertices.Add(new Adjacency(a, distance));


            //Replaces originals with the updated vertex
            MyGraph[MyGraph.FindIndex(x => x.VertexID == a.VertexID)] = a;
            MyGraph[MyGraph.FindIndex(x => x.VertexID == b.VertexID)] = b;
        }

        public override void AddVertex(string name)
        {
            if (name == null)
            {
                name = VertexIDCounter++.ToString();
            }
            MyGraph.Add(new Vertex(name));

        }

        public override void AddVertex(Vertex a)
        {
            if (a.VertexID == null)
            {
                a.VertexID = VertexIDCounter++.ToString();
            }
            MyGraph.Add(a);

        }



        public override bool IsAdjacent(Vertex a, Vertex b)
        {
            return a.AdjacentVertices.Exists(x => x.AdjacentVertex.VertexID == b.VertexID);

        }


        public override int GetEdgeValue(Vertex a, Vertex b)
        {
            return a.AdjacentVertices.Find(x => x.AdjacentVertex == b).Distance;

        }

        public override string GetVertexValue(Vertex a)
        {
            return a.VertexID;
        }

        public override void Neighbors(Vertex a)
        {
            foreach (Adjacency adj in a.AdjacentVertices)
            {
                Console.WriteLine("Vertex ID: {0} is connected to: {1} with a distance of {2}", a.VertexID, adj.AdjacentVertex.VertexID, adj.Distance);
                Logger.Log("Vertex ID: {0} is connected to: {1} with a distance of {2}", a.VertexID, adj.AdjacentVertex.VertexID, adj.Distance);
                Logger.Log(Environment.NewLine);
            }
        }

        public void ListAllAdjacencies(Graph g)
        {
            foreach (Vertex v in g.MyGraph)
            {
                Logger.Log("Vertex ID: {0}", v.VertexID);
                Logger.Log(Environment.NewLine);

                Neighbors(v);
                
            }
            Logger.Close();
        }

        public override void RemoveEdge(Vertex a, Vertex b)
        {
            //Index for where the vertex is in the graph
            var graphIndexA = MyGraph.FindIndex(x => x.VertexID == a.VertexID);
            var graphIndexB = MyGraph.FindIndex(x => x.VertexID == b.VertexID);

            //Index for where the adjacency is located
            var AdjIndexA = MyGraph[graphIndexA].AdjacentVertices.FindIndex(x => x.AdjacentVertex.VertexID == b.VertexID);
            var AdjIndexB = MyGraph[graphIndexB].AdjacentVertices.FindIndex(x => x.AdjacentVertex.VertexID == a.VertexID);

            MyGraph[graphIndexA].AdjacentVertices.Remove(MyGraph[graphIndexA].AdjacentVertices[AdjIndexA]);
            MyGraph[graphIndexB].AdjacentVertices.Remove(MyGraph[graphIndexB].AdjacentVertices[AdjIndexB]);


        }

        public override void RemoveVertex(Vertex a)
        {
            MyGraph.Remove(MyGraph.Find(x => x.VertexID == a.VertexID));
        }

        public override void SetEdgeValue(Vertex a, Vertex b, int newDistance)
        {
            a.AdjacentVertices.Find(x => x.AdjacentVertex == b).Distance = newDistance;
            b.AdjacentVertices.Find(x => x.AdjacentVertex == a).Distance = newDistance;
        }

        public override void SetVertexValue(Vertex a, string newValue)
        {
            a.VertexID = newValue;
            MyGraph[MyGraph.FindIndex(x => x.VertexID == a.VertexID)] = a;
        }



        public List<Vertex> Finish()
        {
            return MyGraph;
        }
    }
}
