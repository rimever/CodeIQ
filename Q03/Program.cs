using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Q03
{
    class Program
    {
        public static void Main(string[] args)
        {
            List<bool> cards = new List<bool>();
            for (int i = 0; i < 100; i++)
            {
                cards.Add(false);
            }
            for (int i = 1; i < 100; i++)
            {
                var preCards = cards.ToList();
                for (int j = i; j < cards.Count; j+=(i+1))
                {
                    cards[j] = !cards[j];
                }
                if (equalsBoolList(cards,preCards))
                {
                    break;
                }
            }
                    OutputAnswer(cards);
            Console.ReadLine();
        }

        private static void OutputAnswer(List<bool> cards)
        {
            Console.WriteLine(string.Join(",", cards.Select((Value, Index) => new { Value, Index }).Where(item => !item.Value).Select(item => item.Index + 1)));
        }

        private static bool equalsBoolList(IList<bool> a, IList<bool> b)
        {
            for (int i = 0; i < a.Count; i++)
            {
                if (a[i] != b[i])
                {
                    return false;
                }
            }
            return true;
        }
    }
}
