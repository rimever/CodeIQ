using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Q05
{
    class Program
    {
        /// <summary>
        /// 500,100,50,10
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            var sets = Answers();
            foreach (var item in sets)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine(sets.Count());
            Console.ReadKey();
        }
        private static IEnumerable<CoinSet> Answers()
        {
            const int CoinSumMax = 15;
            for (int i = 0; i <= CoinSumMax; i++)
            {
                for (int j = 0; j <= CoinSumMax - i; j++)
                {
                    for (int k = 0; k <= CoinSumMax - i - j; k++)
                    {
                        for (int l = 0; l <= CoinSumMax - i - j - k; l++)
                        {
                            var set = new CoinSet()
                            {
                                Coin500Number = i,
                                Coin100Number = j,
                                Coin50Number = k,
                                Coin10Number = l
                            };
                            if (set.SumYen == 1000)
                            {
                                yield return set;
                            }
                        }
                    }
                }
            }

        }


        struct CoinSet
        {
            public int Coin500Number;

            public int Coin100Number;

            public int Coin50Number;

            public int Coin10Number;

            public int SumNumber
            {
                get
                {
                    return Coin500Number + Coin100Number + Coin50Number + Coin10Number;
                }
            }

            public int SumYen
            {
                get
                {
                    return Coin500Number * 500 + Coin100Number * 100 + Coin50Number * 50 + Coin10Number * 10;
                }
            }
            public override string ToString()
            {
                return $@"\500={Coin500Number}枚 , \100={Coin100Number}枚 , \50={Coin50Number}枚 , \10={Coin10Number}枚";
            }

        }
    }
}
