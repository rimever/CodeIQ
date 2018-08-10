using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Q12
{
    class Program
    {
        /// <summary>
        /// 平方根にすると、0-9が最も早く現れる正の整数を求める
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            Console.WriteLine("小数点を含む場合 = " + Answer(true) + " " + AccurateSqrt(Answer(true), 20));
            Console.WriteLine("小数点を含まない場合 = " + Answer(false) + " " + AccurateSqrt(Answer(false), 20));
            Console.ReadKey();
        }

        private static int Answer(bool isContainInteger)
        {
            for (int i = 2; i < int.MaxValue; i++)
            {
                int count = Figure0To9(i, isContainInteger);
                if (count != 10)
                {
                    continue;
                }
                return i;
            }
            throw new InvalidOperationException("答えが見つかりませんでした。");
        }

        private static int Figure0To9(int number,bool isContainInteger)
        {
            bool[] checkedValues = new bool[10];
            decimal sqrt = AccurateSqrt(number, 20);
            int integerPart = (int)sqrt;
            decimal decimalPart = sqrt;
            decimalPart -= integerPart;
            int count = 0;

            if (isContainInteger)
            {
                string integerpartText = integerPart.ToString();
                for (int i = 0; i < integerpartText.Length; i++)
                {
                    count++;
                    int result;
                    if (int.TryParse(integerpartText[i].ToString(),out result))
                    {
                        checkedValues[result] = true;
                    }
                    if (CheckEnd(checkedValues))
                    {
                        return count;
                    }
                }
            }
            string decimalPartText = decimalPart.ToString();
            // 0.??? となるので2文字目からスタート
            for (int i = 2; i < decimalPartText.Length; i++)
            {
                count++;
                int result;
                if (int.TryParse(decimalPartText[i].ToString(), out result))
                {
                    checkedValues[result] = true;
                }
                if (CheckEnd(checkedValues))
                {
                    return count;
                }
            }
            return int.MaxValue;
        }
        private static bool CheckEnd(bool[] array)
        {
            for(int i = 0; i < array.Length; i++)
            {
                if (!array[i])
                {
                    return false;
                }
            }
            return true;
        }
        
        /// <summary>
        /// doubleより桁数の多い平方根を求めることのできる関数です。
        /// </summary>
        /// <param name="a"></param>
        /// <param name="scale"></param>
        /// <returns></returns>
        private static decimal AccurateSqrt(decimal a, int scale)
        {
            decimal x = (decimal)
                    Math.Sqrt((double)a);
            if (scale < 17) return x;

            for (int tempScale = 16; tempScale < scale; tempScale *= 2)
            {
                x = x - (x * x - a) / (2 * x);
            }
            return x;
        }

    }
}
