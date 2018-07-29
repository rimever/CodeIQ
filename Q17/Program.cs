using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Q17
{
    class Program
    {
        /// <summary>
        /// 男をfalse,女をtrueとする。
        /// </summary>
        static readonly IList<bool> choices = new List<bool>()
        {
            true,false
        };
        /// <summary>
        /// 30人を１列にならべるとき、
        /// 女女とならないような組み合わせはいくつあるか。
        /// 男女の人数は関係ない
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            var list = Answers(30, new List<bool>());
            Console.WriteLine($"{list.Count()}通り");
            Console.ReadKey();
        }
        private static IEnumerable<List<bool>> Answers(int number, List<bool> log)
        {
            foreach (var choice in choices)
            {
                if (log.Count == 0
                    || (!(log.Last() && choice)))
                {
                    var nextLog = new List<bool>(log);
                    nextLog.Add(choice);
                    if (nextLog.Count == number)
                    {
                        yield return nextLog;
                    }
                    else
                    {
                        foreach (var answer in Answers(number, nextLog))
                        {
                            yield return answer;
                        }
                    }
                }
            }
        }
    }
}
