using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeIQ3555
{
    class Program
    {
        private static Map Map = new Map();

        private const string CanPassCode = "o";

        private const string GoalCode = "*";

        private const string NotPassCode = "x";

        private static readonly int LimitDays = 15;

        

        static void Main()
        {
            Map.Clear();
            /*
            String line;
            for (; (line = Console.ReadLine()) != null;)
            {
                Map.AddLine(line);
            }*/
            string data =
@"*oooxoo
oxooxxo
oxoxooo
oxx*oxo
oxoooxo
oxxxxxo
ooooooo";
            foreach (var line in data.Split(new string[]{ Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries))
            {
                Map.AddLine(line);
            }

            List<Point> route = new List<Point>() { new Point(0, 0) };
            var results = Search(route, Map).ToList();
            string answer = results.Any(result => result == true) ? "yes" : "no";
            Console.WriteLine(answer);

        }

        static IEnumerable<bool> Search(List<Point> route, Map map)
        {
            if (route.Count == LimitDays + 1)
            {
                yield return false;
                yield break;
            }
            Point last = route.LastOrDefault();
            List<Point> choices = new List<Point>()
            {
                new Point(last.X + 1, last.Y),
                new Point(last.X - 1, last.Y),
                new Point(last.X,last.Y - 1),
                new Point(last.X, last.Y + 1)
            };

            foreach (var choice in choices)
            {
                if (!map.InPoint(choice))
                {
                    continue;
                }
                if (route.Any(p => p.X == choice.X && p.Y == choice.Y))
                {
                    continue;
                }
                var code = map.Get(choice);
                switch (code)
                {
                    case NotPassCode:
                        continue;
                    case CanPassCode:
                        var newRoute = new List<Point>(route.ToArray());
                        newRoute.Add(choice);
                        foreach (var result in Search(newRoute, map))
                        {
                            yield return result;
                        }
                        break;
                    case GoalCode:
                        yield return true;
                        break;
                    default:
                        throw new InvalidOperationException(string.Format("想定されていない値{0}が指定されました。", code));
                }
            }
        }
    }
    /// <summary>
    /// 座標を扱うクラスです。
    /// </summary>
    public struct Point
    {
        /// <summary>
        /// X座標
        /// </summary>
        public readonly int X;
        /// <summary>
        /// Y座標
        /// </summary>
        public readonly int Y;
        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        public Point(int x, int y)
        {
            X = x;
            Y = y;
        }
    }
    public class Map : List<List<string>>
    {
        public void AddLine(string line)
        {
            List<string> row = new List<string>();
            for (int i = 0; i < line.Length; i++)
            {
                row.Add(line.Substring(i, 1));
            }
            Add(row);
        }
        /// <summary>
        /// 指定した座標がマップの範囲にあるか判定します。
        /// </summary>
        /// <param name="point"></param>
        /// <returns></returns>
        public bool InPoint(Point point)
        {
            if (point.Y < 0 || Count <= point.Y)
            {
                return false;
            }
            if (point.X < 0 || this[point.Y].Count <= point.X)
            {
                return false;
            }
            return true;
        }
        /// <summary>
        /// 指定した座標の値を取得します。
        /// </summary>
        /// <param name="point"></param>
        /// <returns></returns>
        public string Get(Point point)
        {
            return this[point.Y][point.X];
        }
    }
}
