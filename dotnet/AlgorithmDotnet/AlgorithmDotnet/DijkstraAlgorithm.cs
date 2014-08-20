using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmDotnet
{
    public class Graph
    {
        public Graph()
        {
            VertexList = new List<Vertex<int>>();
        }

        public IList<Vertex<int>> VertexList { get; set; }

        public void AddVertext(Vertex<int> v)
        {
            if(!VertexList.Contains(v))
                VertexList.Add(v);
        }

        public void AddEdge(Vertex<int> from, Vertex<int> to, int weight)
        {
            AddVertext(from);
            AddVertext(to);
            from.AddEdge(to, weight);   //One Directional
            to.AddEdge(from,weight);    //Bi-Directional 
        }

        public Stack<Vertex<int>> ShortestPathBetween(Vertex<int> start, Vertex<int> end)
        {
            //Find shortest path using Dajkstra Algorithm 
            var auxList = new List<Vertex<int>>();
            var dicVertexToPre = new Dictionary<int, Vertex<int>>();
            foreach (var vertex in VertexList)
            {
                vertex.Value = vertex == start ? 0: double.MaxValue;
                auxList.Add(vertex);
            }

            //Using Looping 
            while (auxList.Count>0)
            {
                var vertextShortest = auxList.FirstOrDefault(av=>(double)av.Value == auxList.Min(v=>(double)v.Value));
                if (vertextShortest == null || vertextShortest.Key.CompareTo(end.Key)==0)
                    break;

                auxList.Remove(vertextShortest);

                foreach (var nb in vertextShortest.AdjacentNodes.Keys)
                {
                    var distance = (double) vertextShortest.Value + vertextShortest.EdgeWeight(nb);
                    if (((double) nb.Value)> distance)
                    {
                        nb.Value = distance;    //Update the distance from the parents
                        dicVertexToPre[nb.Key] = vertextShortest;
                    }
                }
            }

            Stack<Vertex<int>> result = new Stack<Vertex<int>>();
            var temp = end;
            while (temp != null)
            {
                result.Push(temp);
                if (temp.Key.CompareTo(start.Key) == 0)
                    break;
                
                temp= dicVertexToPre[temp.Key];
            }
            return result;
        }

        public void Print()
        {
            if (VertexList == null || VertexList.Count == 0)
                Console.WriteLine("No nodes found in Graph");
            else
            {
                Console.WriteLine("Graph Details: ");
                foreach (var vertex in VertexList)
                {
                    Console.WriteLine(string.Format("Vertex: Key: {0}, Value {1}", vertex.Key, vertex.Value??"null"));
                    foreach (var adjacentNode in vertex.AdjacentNodes.Keys)
                    {
                        Console.WriteLine(string.Format("\tEdge to Key {0}, Weight: {1}", adjacentNode.Key, vertex.AdjacentNodes[adjacentNode]));
                    }
                }
            }
        }
    }

    public class Vertex<T> where T: IComparable
    {
        public T Key { get; set; }
        public Object Value { get; set; }

        public IDictionary<Vertex<T>, double> AdjacentNodes { get; set; }  //Store Ajacent node with Weights

        public Vertex()
        {
            AdjacentNodes = new Dictionary<Vertex<T>, double>();
        }

        public void AddEdge(Vertex<T> node, int weight)
        {
            if (node != null && this.Key.CompareTo(node.Key) != 0)
            {
               if(AdjacentNodes.ContainsKey(node))
                   AdjacentNodes[node]=weight;
                else
                    AdjacentNodes.Add(node, weight);
            }
        }

        public double EdgeWeight(Vertex<T> node)
        {
            if (AdjacentNodes.ContainsKey(node))
                return AdjacentNodes[node];
            else
                return 0;
        }
    }
}
