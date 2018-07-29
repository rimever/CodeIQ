using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Q10
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] European = new int[]
            {
                0,32,15,19,4,21,2,25,17,34,6,27,13,36,11,30,8,23,10,5,24,16,33,1,20,14,
                31,9,22,18,29,7,28,12,35,3,26
            };
            int[] American = new int[]
            {
                0,28,9,26,30,11,7,20,32,17,5,22,34,15,3,24,36,13,1,0,27,10,25,29,12,8,19,31,18,6,21,33,16,4,23,35,14,2
            };



            //            Console.WriteLine("European " + GetSumMax(European));
            //            Console.WriteLine("American " + EnumerableSum(American, 3).Max());
            Console.WriteLine(Answers(European, American).Count());
            Console.ReadKey();
        }

        private static int GetSumMax(int[] array, int number)
        {
            return EnumerableSum(array, number).Max();
        }

        private static IEnumerable<int> Answers(int[] european, int[] american)
        {
            for (int n = 2; n <= 36; n++)
            {
                if (GetSumMax(european, n) < GetSumMax(american, n))
                {
                    yield return n;
                }
            }
        }

        private static IEnumerable<int> EnumerableSum(int[] array, int number)
        {
            for (int i = 0; i < array.Length; i++)
            {
                int sum = 0;
                for (int j = 0; j < number; j++)
                {
                    sum += GetValue(array, i + j);
                }
                yield return sum;
            }
        }

        private static int GetValue(int[] array, int index)
        {
            if (index < array.Length)
            {
                return array[index];
            }
            return array[index - array.Length];
        }
    }
}
