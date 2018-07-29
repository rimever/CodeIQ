using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Q06
{
    class Program
    {
        static void Main(string[] args)
        {
            var answers = Answers();
            foreach (var item in answers)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("数は" + answers.Count());
            Console.ReadKey();
        }
        private static IEnumerable<int> Answers()
        {
            for(int i = 2; i <= 10000; i+= 2)
            {
                if (CheckValue(i))
                {
                    yield return i;
                }
            }
        }

        private static bool CheckValue(int number)
        {
            int current = number * 3 + 1;
            do
            {
                if (current %2 == 0)
                {
                    current /= 2;
                }else
                {
                    current = current * 3 + 1;
                }

            } while (current != number && current != 1);
            return current == number;
        }
    }
}
