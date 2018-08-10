using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleRace
{
    class Program
    {
        static void Main(string[] args)
        {
        }
        class RaceResult
        {

            public double harmonicMean { private set; get; }

            RaceResult(string resultData)
            {
                var data = resultData.Split(' ');
                double divideValue = 0;
                foreach (var item in data.Select((Value, Index) => new { Value, Index }))
                {
                    divideValue += 1 / (double)int.Parse(item.Value);
                }
                harmonicMean = data.Length / divideValue;
            }
            
        }
    }
}
