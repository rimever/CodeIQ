using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Q08
{
    class Program
    {
        static readonly List<VPoint> moves = new List<VPoint>()
            {
                new VPoint(1,0),new VPoint(0,1),new VPoint(-1,0),new VPoint(0,-1)
            };
        static void Main(string[] args)
        {
            var list = Answers(12);
            Console.WriteLine($"{list.Count()}通り");
            Console.ReadKey();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="times"></param>
        /// <param name="log">開始時はnullを指定してください。</param>
        /// <returns></returns>
        private static IEnumerable<List<VPoint>> Answers(int times, List<VPoint> log = null)
        {
            if (log == null)
            {
                log = new List<VPoint>() { new VPoint(0, 0) };
            }
            var now = log.Last();
            foreach (var move in moves)
            {
                var next = new VPoint(now.X + move.X, now.Y + move.Y);
                if (!log.Contains(next))
                {
                    var nextLog = new List<VPoint>(log);
                    nextLog.Add(next);
                    if (nextLog.Count == times + 1)
                    {
                        yield return nextLog;
                    }
                    else
                    {
                        foreach (var item in Answers(times, nextLog))
                        {
                            yield return item;
                        }
                    }
                }
            }
        }
        /// <summary>
        /// System.Drawing.Pointのポータブル版ライブラリ
        /// https://github.com/mono/mono/blob/master/mcs/class/System.Drawing/System.Drawing/Point.cs
        /// </summary>
        public struct VPoint
        {
            /// <summary>
            /// 
            /// 構造体はプロパティだけでなく、変数＋プロパティで宣言する必要があるみたい
            /// </summary>
            private int _X;
            private int _Y;
            public int X
            {
                get
                {
                    return _X;
                }
                set
                {
                    _X = value;
                }
            }
            public int Y
            {
                get
                {
                    return _Y;
                }
                set
                {
                    _Y = value;
                }

            }

            public VPoint(int x, int y)
            {
                _X = x;
                _Y = y;
            }
            /// <summary>
            ///	Equality Operator
            /// </summary>
            ///
            /// <remarks>
            ///	Compares two Point objects. The return value is
            ///	based on the equivalence of the X and Y properties 
            ///	of the two points.
            /// </remarks>

            public static bool operator ==(VPoint left, VPoint right)
            {
                return ((left.X == right.X) && (left.Y == right.Y));
            }

            /// <summary>
            ///	Inequality Operator
            /// </summary>
            ///
            /// <remarks>
            ///	Compares two Point objects. The return value is
            ///	based on the equivalence of the X and Y properties 
            ///	of the two points.
            /// </remarks>

            public static bool operator !=(VPoint left, VPoint right)
            {
                return ((left.X != right.X) || (left.Y != right.Y));
            }
            /// <summary>
            ///	Equals Method
            /// </summary>
            ///
            /// <remarks>
            ///	Checks equivalence of this Point and another object.
            /// </remarks>

            public override bool Equals(object obj)
            {
                if (!(obj is VPoint))
                    return false;

                return (this == (VPoint)obj);
            }

            /// <summary>
            ///	GetHashCode Method
            /// </summary>
            ///
            /// <remarks>
            ///	Calculates a hashing value.
            /// </remarks>

            public override int GetHashCode()
            {
                return X ^ Y;
            }
        }
    }
}
