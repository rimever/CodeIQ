using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnswerSupport
{
    /// <summary>
    /// 組み合わせを求めるユーティリティクラスです。
    /// </summary>
    public class Combination
    {
        /// <summary>
        /// 順列を求めます。
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="items"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public static IEnumerable<IEnumerable<T>> Perm<T>(IEnumerable<T> items, int? k = null)
        {
            if (k == null)
                k = items.Count();

            if (k == 0)
            {
                yield return Enumerable.Empty<T>();
            }
            else
            {
                var i = 0;
                foreach (var x in items)
                {
                    var xs = items.Where((_, index) => i != index);
                    foreach (var c in Perm(xs, k - 1))
                        yield return Before(c, x);

                    i++;
                }
            }
        }

        // 要素をシーケンスに追加するユーティリティ
        public static IEnumerable<T> Before<T>(IEnumerable<T> items, T first)
        {
            yield return first;

            foreach (var i in items)
                yield return i;
        }
        /// <summary>
        /// 組み合わせを求めます。
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="items"></param>
        /// <param name="r"></param>
        /// <returns></returns>
        public static IEnumerable<IEnumerable<T>> Comb<T>(IEnumerable<T> items, int r)
        {
            if (r == 0)
            {
                yield return Enumerable.Empty<T>();
            }
            else
            {
                var i = 1;
                foreach (var x in items)
                {
                    var xs = items.Skip(i);
                    foreach (var c in Comb(xs, r - 1))
                        yield return Before(c, x);

                    i++;
                }
            }

        }
    }
}
