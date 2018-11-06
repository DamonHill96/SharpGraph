using SharpGraph;
using System;
using System.Collections.Generic;

namespace DijkstasAlgorithm.Helpers
{
    public static class GraphBuilder
    {
        public static Graph ValidUndirected()
        {
            //This just builds up a graph used for testing.  
            var myGraph = new UndirectedGraph();
//Do it all manually to avoid any possible problems
            var paddington = new Vertex("Paddington");
            var londonBridge = new Vertex("London Bridge");
            var victoria = new Vertex("Victoria");
            var bank = new Vertex("Bank");
            var oldStreet = new Vertex("Old Street");
            var gloucesterRoad = new Vertex("Gloucester Road");
            var mansionHouse = new Vertex("Mansion House");
            var canaryWharf = new Vertex("Canary Wharf");
            var lewisham = new Vertex("Lewisham");
            var customHouse = new Vertex("Custom House");
            var canningTown = new Vertex("Canning Town");
            var eastIndia = new Vertex("East India");
            var princeRegent = new Vertex("Prince Regent");
            var kingsCross = new Vertex("King's Cross");
            var waterloo = new Vertex("Waterloo");
            paddington.AdjacentVertices.Add(new Adjacency(londonBridge, 0));
            paddington.AdjacentVertices.Add(new Adjacency(victoria, 7));
            paddington.AdjacentVertices.Add(new Adjacency(mansionHouse, 43));
            paddington.AdjacentVertices.Add(new Adjacency(princeRegent, 12));
            paddington.AdjacentVertices.Add(new Adjacency(customHouse, 81));

            londonBridge.AdjacentVertices.Add(new Adjacency(paddington, 0));
            londonBridge.AdjacentVertices.Add(new Adjacency(victoria, 42));

            victoria.AdjacentVertices.Add(new Adjacency(paddington, 7));
            victoria.AdjacentVertices.Add(new Adjacency(bank, 1));
            victoria.AdjacentVertices.Add(new Adjacency(londonBridge, 42));
            victoria.AdjacentVertices.Add(new Adjacency(eastIndia, 94));

            bank.AdjacentVertices.Add(new Adjacency(victoria,1));
            
            oldStreet.AdjacentVertices.Add(new Adjacency(customHouse, 96));
            
            gloucesterRoad.AdjacentVertices.Add(new Adjacency(eastIndia,64));
            gloucesterRoad.AdjacentVertices.Add(new Adjacency(waterloo,16));
            gloucesterRoad.AdjacentVertices.Add(new Adjacency(lewisham,70));
            
            mansionHouse.AdjacentVertices.Add(new Adjacency(paddington,43));
            mansionHouse.AdjacentVertices.Add(new Adjacency(lewisham, 25));
            
            canaryWharf.AdjacentVertices.Add(new Adjacency(canningTown,71));
            canaryWharf.AdjacentVertices.Add(new Adjacency(lewisham,82));
            canaryWharf.AdjacentVertices.Add(new Adjacency(customHouse,45));
            
            lewisham.AdjacentVertices.Add(new Adjacency(mansionHouse,25));
            lewisham.AdjacentVertices.Add(new Adjacency(canaryWharf,82));
            lewisham.AdjacentVertices.Add(new Adjacency(customHouse, 60));
            lewisham.AdjacentVertices.Add(new Adjacency(gloucesterRoad,70));
            
            customHouse.AdjacentVertices.Add(new Adjacency(oldStreet,96));
            customHouse.AdjacentVertices.Add(new Adjacency(paddington,81));
            customHouse.AdjacentVertices.Add(new Adjacency(canaryWharf,45));
            customHouse.AdjacentVertices.Add(new Adjacency(kingsCross,48));
            customHouse.AdjacentVertices.Add(new Adjacency(lewisham,60));
            
            canningTown.AdjacentVertices.Add(new Adjacency(canaryWharf,71));
            canningTown.AdjacentVertices.Add(new Adjacency(waterloo,37));
            
            eastIndia.AdjacentVertices.Add(new Adjacency(gloucesterRoad,64));
            eastIndia.AdjacentVertices.Add(new Adjacency(kingsCross,9));
            eastIndia.AdjacentVertices.Add(new Adjacency(victoria,94));

            princeRegent.AdjacentVertices.Add(new Adjacency(paddington,12));
            
            kingsCross.AdjacentVertices.Add(new Adjacency(eastIndia,9));
            kingsCross.AdjacentVertices.Add(new Adjacency(customHouse,48));
            
            waterloo.AdjacentVertices.Add(new Adjacency(gloucesterRoad,16));
            waterloo.AdjacentVertices.Add(new Adjacency(canningTown,37));
            
            myGraph.MyGraph.Add(paddington);
            myGraph.MyGraph.Add(londonBridge);
            myGraph.MyGraph.Add(victoria);
            myGraph.MyGraph.Add(bank);
            myGraph.MyGraph.Add(oldStreet);
            myGraph.MyGraph.Add(gloucesterRoad);
            myGraph.MyGraph.Add(mansionHouse);
            myGraph.MyGraph.Add(canaryWharf);
            myGraph.MyGraph.Add(lewisham);
            myGraph.MyGraph.Add(customHouse);
            myGraph.MyGraph.Add(canningTown);
            myGraph.MyGraph.Add(eastIndia);
            myGraph.MyGraph.Add(princeRegent);
            myGraph.MyGraph.Add(kingsCross);
            myGraph.MyGraph.Add(waterloo);
            return myGraph;
        }
//Returns a list with the graph and other info for testing
        public static List<object> ValidRandom()
        {
            var random = new Random();
            var graph = BuildGraph.SetGraphType(random.Next(1, 2));

            var numberOfVertices = random.Next(2, 50);
           
            for (var i = 0; i < numberOfVertices; i++)
            {
                graph.AddVertex(new Vertex(RNGHelpers.GetUniqueKey(random.Next(4,16))));
            }

            var numberOfAdjacenciesToAdd = random.Next(6, 32);

            for (var i = 0; i < numberOfAdjacenciesToAdd; i++)
            {
                graph.AddEdge(graph.MyGraph[random.Next(2, numberOfVertices -1)], graph.MyGraph[random.Next(2, numberOfVertices -1)], random.Next(0,500));
            }

            var list = new List<object>();
            list.Add(graph);
            list.Add(numberOfVertices);
            list.Add(numberOfAdjacenciesToAdd);
            return list ;
        }
    }
}