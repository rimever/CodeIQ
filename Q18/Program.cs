using AnswerSupport;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Q18
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<int, bool> powDictionary = new Dictionary<int, bool>();
            foreach (var item in EnumerablePow())
            {
                powDictionary.Add(item, true);
            }
            for (int i = 2; ; i++)
            {
                if (Answer(i, 1, new List<int>() { 1, }, powDictionary))
                {
                    break;
                }
            }
            Console.ReadKey();
        }
        private static bool Answer(int n, int pre, List<int> log, Dictionary<int, bool> powDictionary)
        {
            if (n == log.Count)
            {
                if (powDictionary.ContainsKey(1 + pre))
                {
                    Console.WriteLine(n);
                    return true;
                }
            }
            else
            {
                foreach (var item in Enumerable.Range(1, n).Where(i => !log.Contains(i))
)
                {
                    if (powDictionary.ContainsKey(pre + item))
                    {
                        var newLog = new List<int>(log);
                        newLog.Add(item);
                        if (Answer(n, item, newLog, powDictionary))
                        {
                            return true;
                        }
                    }
                }
            }
            return false;
        }

        private static bool Check(Dictionary<int, bool> powDictionary, List<int> itemList)
        {
            if (!powDictionary.ContainsKey(itemList.Last() + itemList.First()))
            {
                return false;
            }
            for (int j = 0; j < itemList.Count - 1; j++)
            {
                if (!powDictionary.ContainsKey(itemList[j] + itemList[j + 1]))
                {
                    return false;
                }
            }
            return true;
        }

        private static IEnumerable<int> EnumerablePow()
        {
            for (int i = 2; i < (int)Math.Sqrt(int.MaxValue); i++)
            {
                yield return i * i;
            }
        }
    }
}
