using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Q16
{
    class Program
    {
        /// <summary>
        /// 間違っている！！！！
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            List<Tuple<int,int,int>> answers = new List<Tuple<int, int, int>>();
            for (int i = 1; i <= 500/4; i++)
            {
                List<Tuple<int, int>> squares = new List<Tuple<int, int>>();
                for (int j = 1; j < i; j++)
                {
                    squares.Add(new Tuple<int, int>(j, j * (2 * i - j)));
                }
                int sum = i * i;
                var check = Check(squares, sum);
                if (check != null)
                {
                     if (!answers.Any(a => check.Item1 % a.Item1== 0 && check.Item2 % a.Item2 == 0 && i % a.Item3 == 0
                     && check.Item1 / a.Item1 == check.Item2 / a.Item2 && check.Item1 / a.Item1 == i / a.Item3))
                {
                    answers.Add(new Tuple<int, int, int>(check.Item1, check.Item2, i));
                    }else
                    {
                        int a = 0;
                    }

                }
            }
            Console.WriteLine($"{answers.Count}通り");
            Console.ReadKey();
        }
        private static Tuple<int,int> Check(List<Tuple<int, int>> squares, int sum)
        {
            for (int j = 0; j < squares.Count - 1; j++)
            {
                for (int k = j + 1; k < squares.Count; k++)
                {
                    int squareA = squares[j].Item2;
                    int squareB = squares[k].Item2;
                    if (sum == squareA + squareB)
                    {
                        return new Tuple<int, int>(squares[j].Item1, squares[k].Item1);
                    }
                }
            }
            return null;
        }
    }
}
