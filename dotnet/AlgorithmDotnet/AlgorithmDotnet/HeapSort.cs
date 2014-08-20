using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmDotnet
{
    public class HeapArray
    {
        private int[] _HeapArray;
        private int _LastIndex = 0; //For Computation Easy, leave index 0 as empty

        public HeapArray(int capacity)
        {
            capacity = capacity < 2 ? 2 : capacity;
            _HeapArray = new int[capacity + 1];
        }

        public void Insert(int val)
        {
            _HeapArray[++_LastIndex] = val;
            Swim(_LastIndex);
        }

        private void Swim(int x)
        {
            var parentIndex = x/2;
            if (parentIndex == 0)
                return; //Root Element 

            if (_HeapArray[parentIndex] < _HeapArray[x])
            {
                Utility.Swap<int>(_HeapArray, parentIndex, x);
                Swim(parentIndex);
            }
        }

        private void Sink(int index)
        {
            if (2*index +1 > _LastIndex)
                return;

            int child1 = 2*index;
            int child2 = 2*index + 1;

            if (_HeapArray[index] >= _HeapArray[child1] && _HeapArray[index] >= _HeapArray[child2])
                return;

            int maxchildIndex = _HeapArray[child1] >= _HeapArray[child2] ? child1 : child2;

            Utility.Swap<int>(_HeapArray, index, maxchildIndex);
            Sink(maxchildIndex);
        }

        public int DeleteMax()
        {
            if (_LastIndex == 0)
                return -99999999;
            if (_LastIndex > 1)
            {
                Utility.Swap<int>(_HeapArray, 1, _LastIndex);
            }

            var ret = _HeapArray[_LastIndex];
            _HeapArray[_LastIndex--] = 0;

            if (_LastIndex > 1)
                Sink(1);

            return ret;
        }

        public void Print()
        {
            Utility.PrintSequence<int>(_HeapArray);
        }

        public void Sort()
        {
            while (_LastIndex > 0)
            {
                Utility.Swap<int>(_HeapArray, 1, _LastIndex--);

                if (_LastIndex > 1)
                    Sink(1);
            }
        }
    }
}
