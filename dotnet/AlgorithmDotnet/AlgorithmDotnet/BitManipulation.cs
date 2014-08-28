using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmDotnet
{
    public class BitManipulation
    {
        public static void PrintAsBitArray(double decimalValue)
        {
            int integerPart = (int) decimalValue;
            double decimalPart = decimalValue - integerPart;

            StringBuilder buffer = new StringBuilder();

            //Print Integer Part
            while (integerPart > 0)
            {
                var bit = integerPart%2;
                integerPart = integerPart >> 1; //== integerPart/2
                buffer.Insert(0, bit);
            }
            //Print Decimal Point
            buffer.Append(".");

            //Print Decimal Part 
            while (decimalPart!=0)
            {
                decimalPart = decimalPart*2;
                if (decimalPart >= 1)
                {
                    decimalPart--;
                    buffer.Append("1");
                }
                else
                {
                    buffer.Append("0");
                }
            }

            Console.WriteLine(string.Format("Decimal {0} binary format is {1}", decimalValue, buffer.ToString()));
        }

        public static void FindNearestData()
        {
            Func<int[], int, bool, int> FindNextBitFunc = (input, startIndex, bRight) =>
            {
                //if()
                return 0;
            };
        }

        public static void TestBitOperations()
        {
            PrintAsBitArray(11);
            PrintAsBitArray(0.5);
            PrintAsBitArray(12.9);
        }
    }
}
