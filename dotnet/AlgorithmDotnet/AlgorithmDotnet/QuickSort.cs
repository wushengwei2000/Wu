using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmDotnet
{
    public class QuickSort<T> where T : IComparable
    {
        public int Partition(T[] inputs, int low, int high)
        {
            if (low >= high)
                return low;
            else
            {
                int i = low + 1;
                int j = high;
                while (true)
                {
                    while (inputs[i].CompareTo(inputs[low]) <= 0 && i < high)
                        i++;

                    while (inputs[j].CompareTo(inputs[low]) > 0 && j > low)
                        j--;

                    if (j <= i) break;
                    Swap(inputs, i, j);
                }
                Swap(inputs, low, j);
                return j;
            }
        }

        

        
        public void Sort(T[] inputs)
        {
            PartitionAndSort(inputs, 0, inputs.Length - 1);
        }

        private void PartitionAndSort(T[] inputs, int start, int end)
        {
            if (start >= end)
                return;

            var partitionIndex = Partition(inputs, start, end);
            PartitionAndSort(inputs, start, partitionIndex - 1);
            PartitionAndSort(inputs, partitionIndex + 1, end);
        }

        public void SortWithDuplicateKeys(T[] inputs, int low, int high)
        {
            if (low >= high) return;

            int lt = low+1;
            int i = low+1;
            int gt = high+1;

            while (i < gt)
            {
                if (inputs[i].CompareTo(inputs[low]) == 0)
                {
                    i++;
                }
                else if (inputs[i].CompareTo(inputs[low]) < 0)
                {
                    Swap(inputs, lt++, i++);
                }
                else
                {
                    gt--;
                    if(inputs[gt].CompareTo(inputs[low])<=0)
                        Swap(inputs, gt, i);
                }
            }
            Swap(inputs, low, lt-1);

            SortWithDuplicateKeys(inputs, low, lt - 1);
            SortWithDuplicateKeys(inputs, i, high);
        }

        public void Swap(T[] inputs, int index1, int index2)
        {
            var tmp = inputs[index1];
            inputs[index1] = inputs[index2];
            inputs[index2] = tmp;
        }
    }


    public class Utility
    {
        public static T[] Shuffle<T>(T[] input)
        {
            if (input == null || input.Length <= 1)
                return input;
            Random random = new Random();
            for (var i = 0; i < input.Length; i++)
            {
                var exchangeIndex = random.Next(i, input.Length+1);
                var tmp = input[i];
                input[i] = input[exchangeIndex];
                input[exchangeIndex] = tmp;
            }
            return input;
        }

        public static IList<int> PopulateRandomInts(int size, int min, int max)
        {
            var random = new Random();
            return Enumerable.Range(1, size).Select(item => random.Next(min, max)).ToList();
        }

        public static void PrintSequence<T>(T[] input)
        {
            if (input == null || input.Length==0)
            {
                Console.WriteLine("Array is empty or null");
            }
            else
            {
                Console.WriteLine("Array Squence as following: ");
                Array.ForEach(input, obj => Console.Write(obj.ToString()+"\t"));
                Console.WriteLine("");
            }
        }

        public static void Swap<T>(T[] inputs, int index1, int index2)
        {
            var tmp = inputs[index1];
            inputs[index1] = inputs[index2];
            inputs[index2] = tmp;
        }
    }
}
