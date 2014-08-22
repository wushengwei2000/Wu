using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmDotnet
{
    public class TravellingSalesMan
    {
        public IList<Vertex<int>> BrutalForceSearch(Graph citymap)
        {
            IList<Vertex<int>> result = new List<Vertex<int>>();
            //Assume graph nodes are all inter-connected 
            

            return result;
        }

        private double Distance(Queue<Vertex<int>> vertexes)
        {
            double result = 0;
            Vertex<int> head = vertexes.Peek();
            while (vertexes.Count > 0)
            {
                var current = vertexes.Dequeue();
                var next = vertexes.Peek() ?? head;
                result += current.EdgeWeight(next);
            }
            return result;
        }

        
    }
}
