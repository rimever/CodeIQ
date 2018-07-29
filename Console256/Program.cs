using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Console256
{
    class Program
    {
        static void Main(string[] args)
        {
            string line;
            int lineNo = 0;
            int[] data = null;
            for (; (line = Console.ReadLine()) != null;)
            {
                switch (lineNo)
                {
                    case 0:
                        data = new int[int.Parse(line)];
                        break;
                    case 1:
                        foreach (var item in line.Split(' ').Select((Value, Index) => new { Value, Index }))
                        {
                            data[item.Index] = int.Parse(item.Value);
                        }
                        break;
                }
                lineNo++;
            }
            var answer = Answer(data);
            if (answer)
            {
                Console.WriteLine("yes");
            }else
            {
                Console.WriteLine("no");
            }
            Console.ReadKey();
        }

        private static bool Answer(int[] data)
        {
            for (int i = 0; i < data.Length - 1; i++)
            {
                for (int j = i + 1; j < data.Length; j++)
                {
                    if (data[i] + data[j] == 256)
                    {
                        return true;
                    }
                }
            }
            return false;
        }
    }
}
