using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Q15
{
    class Program
    {
        static readonly List<int> moveDistances = new List<int>(Enumerable.Range(1, 4));
        /// <summary>
        /// 10段の階段を１～４段まで一度に進むことができる。ぶつかる組み合わせはいくつあるか
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            var list = Answer(10, new List<int>(), new List<int>());
            Console.WriteLine($"答えは{list.Count()}通り");
            Console.ReadLine();
        }
        static IEnumerable<Tuple<List<int>,List<int>>> Answer(int distance,List<int> logA,List<int> logB)
        {
            for (int i = 0; i < moveDistances.Count; i++)
            {
                for (int j = 0; j < moveDistances.Count; j++)
                {
                    int result = distance - moveDistances[i] - moveDistances[j];
                    var a = new List<int>(logA);
                    a.Add(moveDistances[i]);
                    var b = new List<int>(logB);
                    b.Add(moveDistances[j]);
                    if (result == 0)
                    {
                        yield return new Tuple<List<int>, List<int>>(a, b);
                    }
                    else if (result < 0)
                    {
                        break;
                    }
                    else
                    {
                        foreach (var item in Answer(result, a, b))
                        {
                            yield return item;
                        }
                    }
                }
            }
        }
    }
}
