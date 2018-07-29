using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Q04
{
    class Program
    {

        /// <summary>
        /// 切れ目が棒の長さ－１の分あると考える。
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            Console.WriteLine(Answer(3, 8, 1));
            Console.ReadKey();
        }
        private static int Answer(int m, int n, int current)
        {
            if (current >= n)
            {
                return 0;
            }
            else if (current < m)
            {
                return 1 + Answer(m, n, current * 2);
            }
            else
            {
                return 1 + Answer(m, n, current + m);
            }
        }
    }
}