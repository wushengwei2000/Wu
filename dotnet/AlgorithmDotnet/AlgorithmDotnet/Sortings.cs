using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmDotnet
{
    public class SelectionSort
    {
        public static void Sort(int[] inputs)
        {
            for (var i = 0; i < inputs.Length; i++)
            {
                var minIndex = i;
                for (int j = i + 1; j < inputs.Length; j++)
                {
                    if (inputs[j] < inputs[minIndex])
                        minIndex = j;
                }
                Utility.Swap<int>(inputs, i, minIndex);
            }
        }
    }

    public class InsertionSort
    {
        public static void Sort(int[] inputs)
        {
            for (int i = 1; i < inputs.Length; i++)
            {
                for (int k = i; k > 0; k--)
                {
                    if(inputs[k]<inputs[k-1])
                        Utility.Swap<int>(inputs, k, k-1);
                }
            }
        }   
    }

    public class BubbleSort
    {
        //Swap Adjacent Ones until the array is sorted 
    }

    public class MergeSort
    {
        public void Sort(int[] inputs)
        {
            int[] hoder = new int[inputs.Length];
            SortRecurive(inputs, hoder, 0, inputs.Length-1);
        }

        private void SortRecurive(int[] inputs, int[] holder, int start, int end)
        {
            if (start >= end)
                return;
            int mid = (start + end + 1)/2;

            SortRecurive(inputs, holder, start, mid-1);
            SortRecurive(inputs, holder, mid, end);
            Merge(inputs, holder, start, mid, end);
        }

        private void Merge(int[] inputs, int[] holder, int low, int mid, int high)
        {
            if (low >= high)
                return;

            for (int i = low; i <= high; i++)
                holder[i] = inputs[i];

            int left = low;
            int right = mid;

            for (int i = low; i <= high; i++)
            {
                if (left >= mid)
                {
                    inputs[i] = holder[right];
                    right++;
                }
                else if (right > high)
                {
                    inputs[i] = holder[left];
                    left++;
                }
                else
                {
                    if (holder[left] <= holder[right])
                    {
                        inputs[i] = holder[left];
                        left++;
                    }
                    else
                    {
                        inputs[i] = holder[right];
                        right++;
                    }
                }
            }


        }
    }
}
