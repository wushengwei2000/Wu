using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmDotnet
{
    class Program
    {
        static void Main(string[] args)
        {
            BitManipulation.TestBitOperations();
            Console.ReadLine();
        }

        public static void TestDijksStraAlgorithm()
        {
            //1. Generating Graphs 
            Console.WriteLine("Generating Testing Graphs ");
            Graph g = new Graph();
            var randomList = Utility.PopulateRandomInts(10, 1, 100);
            foreach (var i in randomList)
            {
                g.AddVertext(new Vertex<int>(){Key=i});
            }

            Random r = new Random();
            foreach (var vertex in g.VertexList)
            {
                for(int i=0; i<1; i++)
                    g.AddEdge(vertex, g.VertexList[r.Next(0,10)], r.Next(100,999));
            }
            g.Print();

            //2. Find Shortest Path Between two nodes 
            var start = g.VertexList.FirstOrDefault();
            var end = g.VertexList.LastOrDefault();

            Console.WriteLine(string.Format("Find shortest Path between {0} and {1}", start.Key, end.Key));

            var shortestPath = g.ShortestPathBetween(start, end);
            while (shortestPath.Count > 0)
            {
                var node = shortestPath.Pop();
                Console.Write(string.Format("{0} --> ", node.Key));
            }
            Console.ReadLine();
        }

        public static void TestHeapSort()
        {
            var randomList = Utility.PopulateRandomInts(20, 1, 100).ToArray();
            Utility.PrintSequence<int>(randomList);
            Console.WriteLine("Creating Heap ...");
            HeapArray heap = new HeapArray(20);

            foreach (var i in randomList)
            {
                heap.Insert(i);
            }

            heap.Print();
            Console.WriteLine("Heap Sorting Result: ");
            heap.Sort();
            heap.Print();

            Console.ReadLine();
        }

        public static void TestSorts()
        {
            var randomList = Utility.PopulateRandomInts(20, 1, 100).ToArray();
            Utility.PrintSequence<int>(randomList);
            Console.WriteLine("Merge Sorting ...");
            MergeSort ms = new MergeSort();
            ms.Sort(randomList);
            Console.WriteLine("Merge Sorting Result: ");
            Utility.PrintSequence<int>(randomList);
            Console.ReadLine();

            randomList = Utility.PopulateRandomInts(20, 1, 100).ToArray();
            Utility.PrintSequence<int>(randomList);
            Console.WriteLine("Selection Sorting ...");
            SelectionSort.Sort(randomList);
            Console.WriteLine("Selection Sorting Result: ");
            Utility.PrintSequence<int>(randomList);
            Console.ReadLine();

            randomList = Utility.PopulateRandomInts(20, 1, 100).ToArray();
            Utility.PrintSequence<int>(randomList);
            Console.WriteLine("Insertion Sorting ...");
            InsertionSort.Sort(randomList);
            Console.WriteLine("Insertion Sorting Result: ");
            Utility.PrintSequence<int>(randomList);
            Console.ReadLine();
        }

        public static void TestBST()
        {
            var randomList = Utility.PopulateRandomInts(5, 1, 100).ToArray();
            Console.WriteLine("Populating Binary Tree");

            Random random = new Random();
            BST<int> testBST = new BST<int>();
            foreach (var i in randomList)
            {
                Console.WriteLine("Inserting "+i);
                testBST.Insert(i, random.Next(1000, 2000));
            }
            Console.WriteLine("Finish Generating Treeview");
            testBST.Print();

            Console.WriteLine("Breath First Print");
            testBST.PrintBreathFirst();
            Console.ReadLine();

            Console.WriteLine("Find Key " + 50 + " "+ (testBST.Search(50)==null? "Not Found": "Found Key"));
            Console.WriteLine("Find Key " + randomList[5] + " " + (testBST.Search(randomList[5]) == null ? "Not Found" : "Found Key"));

            Console.WriteLine("Press Enter to test deleting ");
            Console.ReadLine();
            Console.WriteLine("Deleting " + randomList[6]);
            testBST.Delete(randomList[6]);
            testBST.Print();
            Console.ReadLine();
            Console.WriteLine("Deleting " + randomList[0]);
            testBST.Delete(randomList[0]);
            testBST.Print();

            Console.ReadLine();
        }

        public static void TestQuickSort()
        {
            var randomList = Utility.PopulateRandomInts(20, 1, 100).ToArray();
            Utility.PrintSequence<int>(randomList);
            Console.WriteLine("Quick Sorting ...");

            QuickSort<int> qs = new QuickSort<int>();
            qs.Sort(randomList);
            Utility.PrintSequence<int>(randomList);
            Console.WriteLine("Done Quick Sorting");

            Console.WriteLine("Test Quick Sorting with duplicate keys");
            randomList = Utility.PopulateRandomInts(50, 1, 6).ToArray();
            Utility.PrintSequence(randomList);
            Console.WriteLine("Quick Sorting with Duplicate Keys");
            qs.SortWithDuplicateKeys(randomList, 0, randomList.Length - 1);
            Utility.PrintSequence(randomList);
            Console.WriteLine("Done Quick Sorting");
            Console.ReadLine();
        }

        public static void TestAmazon()
        {
            Console.WriteLine("Generating Testing Customers");
            var random = new Random();
            var cusotmer = new Customer() { Name = "Root Cusomter", Purchases = random.NextDouble() * 1000 };

            //Construct Level 1;
            int childCount = 0;
            cusotmer.ReferedCustomers = Enumerable.Repeat(string.Empty, random.Next(2, 5)).Select(n =>
                new Customer()
                {
                    Name = "Customer 1." + (++childCount),
                    Purchases = random.NextDouble() * 1000
                }).ToList();

            //Construct Level 2:
            childCount = 0;
            Array.ForEach(cusotmer.ReferedCustomers.ToArray(), c =>
            {
                c.ReferedCustomers = Enumerable.Repeat(string.Empty, random.Next(2, 5)).Select(n =>
                new Customer()
                {
                    Name = "Customer 2." + (++childCount),
                    Purchases = random.NextDouble() * 1000
                }).ToList();
            });

            Console.WriteLine("Finish generating, now print the result");
            Amazon.PrintCustomerTree(cusotmer);
            Console.WriteLine("Press Enter to Print Recursively");
            Console.ReadLine();
            cusotmer.Level = 0;
            Amazon.PrintCusomterRecursive(cusotmer);
            Console.WriteLine("Press Enter to calculate reward: ");
            Console.ReadLine();
            Console.WriteLine(string.Format("Customer {0} has rewards of {1} ", cusotmer.Name, cusotmer.GetRewards(new ReferingReward())));
            Console.ReadLine();
        }
    }
}
