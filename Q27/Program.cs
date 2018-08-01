using System;
using System.Linq;
using System.Collections.Generic;

namespace Q27
{
    class MainClass
    {
        public class Route {
            public int X;
            public int Y;
            public Direction Direction;

            public override string ToString()
            {
                return $"({X},{Y},Dir={Direction})";
            }
        }
        [Flags]
        public enum Direction
        {
            None = 0,
            Right = 1,
            Up = 1 << 1,
            Left = 1 << 2,
            Down = 1 << 3,
            Size = 1 << 4
        }

        public static void Main(string[] args)
        {
			Direction[][] map = CreateArray(4, 3);
            List<Route> routes = new List<Route>();
            int startX = 0;
            int startY = map[0].Length - 1;
            map[startX][startY] = Direction.Right;
            routes.Add(new Route() {
                X = 0,
                Y = startY,
                Direction = Direction.Right
            });
			var answers = Answers(map, startX, startY, Direction.Right, routes).ToList();
			foreach (var item in answers)
            {
                Console.WriteLine(string.Join(",", item.Select(route => route.ToString())));
            }
            Console.WriteLine($"{answers.Count()}通り");
            Console.WriteLine("Hello World!");
        }
        private static IEnumerable<IList<Route>> Answers(Direction[][] map, int nowX, int nowY, Direction nowDirection,IList<Route> routes)
        {
            foreach (var item in Enumerable.Range(0, 2))
            {
                var nextDirection = nowDirection;
                if (item > 0) {
                    var nextDirectionValue = (int)nextDirection << item;
                    if (nextDirectionValue == (int)Direction.Size) {
                        nextDirectionValue = 1;
                    }
                    nextDirection = (Direction)nextDirectionValue;
                }
                int nextX = nowX;
                int nextY = nowY;

                switch (nextDirection)
                {
                    case Direction.Down:
                        nextY++;
                        break;
                    case Direction.Left:
                        nextX--;
                        break;
                    case Direction.Right:
                        nextX++;
                        break;
                    case Direction.Up:
                        nextY--;
                        break;
                    default:
                        throw new InvalidOperationException("想定されていない値が指定されました。");
                }
                if (0 <= nextX && nextX < map.Length)
                {
                    if (0 <= nextY && nextY < map[0].Length)
                    {
                        if (!map[nextX][nextY].HasFlag(nextDirection))
                        {
							var copyTable = CopyArray(map);
                            copyTable[nextX][nextY] = copyTable[nextX][nextY] | nextDirection;
                            var nextRoutes = new List<Route>(routes);
                            nextRoutes.Add(new Route()
                            {
                                X = nextX,
                                Y = nextY,
                                Direction = nextDirection
                            });
                            if (nextX == map.Length - 1 && nextY == 0)
                            {
                                yield return nextRoutes;
                            }
                            foreach (var answer in Answers(copyTable, nextX, nextY, nextDirection,nextRoutes))
                            {
                                yield return answer;
                            }
                        }
                    }
                }
            }
        }
        private static Direction[][] CopyArray(Direction[][] table) {
            Direction[][] copyTable = new Direction[table.Length][];
            for (int i = 0; i < table.Length; i++) {
                copyTable[i] = new Direction[table[i].Length];
                for (int j = 0; j < table[i].Length; j++) {
                    copyTable[i][j] = table[i][j];
                }
            }
            return copyTable;
        }


        private static Direction[][] CreateArray(int x,int y) {
            Direction[][] table = new Direction[x][];
            for (int i = 0; i < table.Length; i++) {
                table[i] = new Direction[y];
                for (int j = 0; j < table[i].Length; j++) {
                    table[i][j] = Direction.None;
                }
            }
            return table;
        }
    }
}
