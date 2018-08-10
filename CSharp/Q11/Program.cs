using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Q11
{
    class Program
    {
        static void Main(string[] args)
        {
            var list = Answers(11);
            foreach (var item in list)
            {
                Console.WriteLine(item);
            }
            Console.ReadKey();
        }
        private static IEnumerable<ulong> Answers(int number)
        {
            ulong first = 1;
            ulong second = 1;

            int count = 0;
            do
            {
                ulong newValue = first + second;
                if (newValue % GetSum(newValue) == 0)
                {
                    count++;
                    yield return newValue;
                }
                first = second;
                second = newValue;
            } while (count != number);
        }
        private static ulong GetSum(ulong value)
        {
            string text = value.ToString();
            ulong sum = 0;
            for(int i = 0; i < text.Length; i++)
            {
                var character = text[i];
                sum += ulong.Parse(character.ToString());
            }
            return sum;
        }

        private static IEnumerable<ulong> GetFibonach(int number)
        {
            ulong first = 1;
            ulong second = 1;
            yield return first;
            yield return second;

            for (int i = 0; i <= number -2; i++)
            {
                ulong newValue = first + second;
                yield return newValue;
                first = second;
                second = newValue;
            }
        }
    }
}
