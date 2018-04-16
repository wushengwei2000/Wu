using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmDotnet
{
    public class Permutations
    {
        private static IList<List<T>> Permutate<T>(IList<T> input)
        {
            if (input.Count <=1)
                return new List<List<T>>(){input as List<T>};

            IList<List<T>> result = new List<List<T>>();        //Extra Space 1 (N-1)!+....
            HashSet<T> checkDuplicateSet = new HashSet<T>();    //Extra Space 2 N(N+1)/2
            for (int i=0; i<input.Count; i++)
            {
                if(!checkDuplicateSet.Add(input[i]))
                    continue;   //Check Duplications 

                var first = input[i];
                var remainInputs = new List<T>();               //Extra Space 2 N(N+1)/2
                for (int j = 0; j < input.Count; j++)
                {
                    if(j!=i)
                        remainInputs.Add(input[j]);
                }

                foreach (var subpermutation in Permutate(remainInputs)) //Using Recurisve Call
                {
                    List<T> list1 = new List<T>();
                    list1.Add(first);
                    list1.AddRange(subpermutation);

                    result.Add(list1);
                }
            }
            return result;
        }

        //Improve it to save some space (In-Place for each record)
        //However, this algorithm does not solve the duplicate key problems 
        private static void Permutate<T>(IList<T> input, int startIndex, IList<IList<T>> permutatedResult)
        {
            if (startIndex >= input.Count-1)
            {
                permutatedResult.Add(input);
                return;
            }

            var duplicateChecker = new HashSet<T>();    //For handling Duplication case 
            for (int i = startIndex; i < input.Count; i++)
            {
                if(!duplicateChecker.Add(input[i]))
                Swap(input, startIndex, i);
                IList<T> onePermutationResult = new List<T>(input);     
                Permutate(onePermutationResult, startIndex+1, permutatedResult);
                Swap(input, startIndex, i);
            }
        }

        private static void Swap<T>(IList<T> list, int index1, int index2)
        {
            if (index1 >= list.Count || index2 >= list.Count)
                return;

            var temp = list[index1];
            list[index1] = list[index2];
            list[index2] = temp;
        }

        public static void TestPermutate()
        {
            Console.WriteLine("Populating test List ");
            IList<int> list = Utility.PopulateRandomInts(4, 0, 10, true);
            Utility.PrintSequence(list.ToArray());

            Console.WriteLine("Find All permutations: ");
            var result = Permutations.Permutate<int>(list);
            Console.WriteLine("Total Permutation Found: " + result.Count);
            Console.WriteLine("Total Distinct Permutation Found: " + result.Distinct().Count());
            foreach (var lst in result)
            {
                Utility.PrintSequence(lst.ToArray());
            }

            Console.ReadLine();
        }

        public static void TestPermutate2()
        {
            Console.WriteLine("Populating test List ");
            IList<int> list = Utility.PopulateRandomInts(4, 0, 10, false);
            Utility.PrintSequence(list.ToArray());

            Console.WriteLine("Find All permutations: ");
            IList<IList<int>> result = new List<IList<int>>();
            Permutations.Permutate<int>(list, 0, result);
            Console.WriteLine("Total Permutation Found: " + result.Count);
            foreach (var lst in result)
            {
                Utility.PrintSequence(lst.ToArray());
            }

            Console.ReadLine();
        } 
    }
}
