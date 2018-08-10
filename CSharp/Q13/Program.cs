using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Q13
{
    class Program
    {
        static void Main(string[] args)
        {
            var answers = Answers().ToList();

            foreach (var item in answers)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine($"答えは、{answers.Count}通り");
            Console.ReadKey();
        }
        /// <summary>
        /// READ + WRITE + TALK = SKILLの解を取得します。
        /// </summary>
        /// <returns></returns>
        private static IEnumerable<string> Answers()
        {

            for (int W = 1; W < 10 - 1; W ++)
            {
                int S = W + 1;
                var combinations = Combination.Enumerate(Enumerable.Range(0, 10).Where(v => v != W && v != S).ToList(), 8).ToList();
                foreach (var combination in combinations)
                {
                    int R = combination[0];
                    int E = combination[1];
                    int A = combination[2];
                    int D = combination[3];
                    int I = combination[4];
                    int T = combination[5];
                    int K = combination[6];
                    int L = combination[7];
                    if (R == 0 || W == 0 || T == 0 || S == 0)
                    {
                        continue;
                    }
                    int read = R * 1000 + E * 100 + A * 10 + D;
                    int write = W * 10000 + R * 1000 + I * 100 + T * 10 + E;
                    int talk = T * 1000 + A * 100 + L * 10 + K;
                    int skill = S * 10000 + K * 1000 + I * 100 + L * 10 + L;
                    if (read + write + talk == skill)
                    {
                        yield return $"{R}{E}{A}{D} + {W}{R}{I}{T}{E} + {T}{A}{L}{K} = {S}{K}{I}{L}{L}";
                    }
                }
            }
        }

        public static class Combination
        {
            public static IEnumerable<T[]> Enumerate<T>(IEnumerable<T> items, int k)
            {
                if (k == 1)
                {
                    foreach (var item in items)
                    {
                        yield return new T[] { item };
                    }
                    yield break;
                }
                foreach (var item in items)
                {
                    var leftside = new T[] { item };
                    var unused = items.Except(leftside);
                    foreach (var rightside in Enumerate(unused, k - 1))
                    {
                        yield return leftside.Concat(rightside).ToArray();
                    }
                }
            }
        }
    }
}
