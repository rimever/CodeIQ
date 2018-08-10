using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicProgramming
{
    class ShopItem
    {
        public string Name { get; set; }
        public int Weight { get; set; }
        public int Price { get; set; }
    }
    /// <summary>
    /// 動的計画法
    /// ナップザック問題
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            int maxWeight = 9;
            var items = new List<ShopItem>()
            {
                new ShopItem()
                {
                    Name = "*",
                    Weight = 0,
                    Price = 0
                },
                new ShopItem()
                {
                    Name = "A",
                    Weight = 1,
                    Price = 730
                },
                new ShopItem()
                {
                    Name = "B",
                    Weight = 2,
                    Price = 1470
                },
                new ShopItem()
                {
                    Name = "C",
                    Weight = 3,
                    Price = 2200
                },
                new ShopItem()
                {
                    Name = "D",
                    Weight = 4,
                    Price = 2870
                },
                new ShopItem()
                {
                    Name = "E",
                    Weight = 5,
                    Price = 3500
                }
            };
            var valueMaxTable = new int[items.Count, maxWeight + 1];
            var isTakeoutTable = new bool[items.Count, maxWeight + 1];

            for (int i = 1; i < items.Count; i++)
            {
                for (int w = 1; w <= maxWeight; w++)
                {
                    var item = items[i];
                    if (item.Weight <= w)
                    {
                        var v1 = item.Price + valueMaxTable[i - 1, w - item.Weight];
                        var v2 = valueMaxTable[i - 1, w];

                        if (v1 > v2)
                        {
                            valueMaxTable[i, w] = v1;
                            isTakeoutTable[i, w] = true;
                        }
                        else
                        {
                            valueMaxTable[i, w] = v2;
                        }
                    }
                    else
                    {
                        valueMaxTable[i, w] = valueMaxTable[i - 1, w];
                    }
                }
            }

            {
                var i = items.Count - 1;
                var w = maxWeight;
                do
                {
                    var item = items[i];
                    if (isTakeoutTable[i, w])
                    {
                        Console.Write(item.Name);
                        w -= item.Weight;
                    }

                    i--;
                } while (i > 0 || w > 0);
                Console.WriteLine();
                Console.ReadKey();
            }
        }
    }
}
