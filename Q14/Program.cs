using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Q14
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] countries = new string[]
            {
                "Brazil","Croatia","Mexico","Cameroon","Spain","Netherlands","Chile","Australia","Colombia",
                "Greece","Cote d'Ivoire","Japan","Uruguay","Costa Rica","England","Italy","Swizerland","Ecuador",
                "France","Honduras","Argentina","Bosnia and Herzegovina","Iran","Nigeria","Germany","Portugal","Ghana",
                "USA","Belgium","Algeria","Russia","Korea Republic"
            };
            /* 一覧出力
            foreach (var item in Answers(countries))
            {
                Console.WriteLine(string.Join("-", item.Select(i => countries[i])));
            }
            */
            var max = Answers(countries).Max(a => a.Count);
            Console.WriteLine($"{max}ヶ国");
            foreach (var item in Answers(countries).Where(a => a.Count == max))
            {
                Console.WriteLine(string.Join("-", item.Select(i => countries[i])));
            }
            Console.ReadKey();
        }
        static IEnumerable<IList<int>> Answers(string[] countries)
        {
            for (int i = 0; i < countries.Length; i++)
            {
                foreach (var item in Search(new List<int> {i }, countries))
                {
                    yield return item;
                }
            }
        }

        static IEnumerable<IList<int>> Search(IList<int> logs,string[] countries)
        {
            foreach (var item in Enumerable.Range(0,countries.Length).Where(i => ! logs.Contains(i)))
            {
                string lastCountry = countries[logs.Last()].ToString();
                string firstCountry = countries[item].ToString();
                if (lastCountry.Last().ToString().ToLower() == firstCountry.First().ToString().ToLower())
                {
                    var newLog = new List<int>(logs);
                    newLog.Add(item);
                    foreach (var itemSearch in Search(newLog,countries))
                    {
                        yield return itemSearch;
                    }
                }
            }
            yield return logs;
        }
    }
}
