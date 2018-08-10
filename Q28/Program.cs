using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Q28
{
    class Program
    {
       /// <summary>
       /// 150人を超えないようにクラブ活動を選び、面積を最大にする。
       /// </summary>
       /// <param name="args"></param>
        static void Main(string[] args)
       {
           var clubs = new List<Club>()
           {
               new Club()
               {
                   Area = 11000,
                   MemberNumber = 40
               },
               new Club()
               {
                   Area = 8000,
                   MemberNumber = 30
               },
               new Club()
               {
                   Area = 400,
                   MemberNumber = 24
               },
               new Club()
               {
                   Area = 800,
                   MemberNumber = 20
               },
               new Club()
               {
                   Area = 900,
                   MemberNumber = 14
               },
               new Club()
               {
                   Area = 1800,
                   MemberNumber = 16
               },
               new Club()
               {
                   Area = 1000,
                   MemberNumber = 15
               },
               new Club()
               {
                   Area = 7000,
                   MemberNumber = 40
               },
               new Club()
               {
                   Area = 100,
                   MemberNumber = 10
               },
               new Club()
               {
                   Area = 300,
                   MemberNumber = 12
               }
           };
           int maxMembers = 150;
           var maxArea = Calculate(clubs, maxMembers);
           Console.WriteLine(maxArea);
           Console.ReadKey();
       }
        /// <summary>
        /// 算出します
        /// </summary>
        /// <param name="clubs"></param>
        /// <param name="maxMembers"></param>
        /// <returns></returns>
        private static int Calculate(List<Club> clubs, int maxMembers)
        {
            var area = new int[clubs.Count + 1, maxMembers + 1];
            for (int i = clubs.Count - 1; i >= 0; i--)
            {
                for (int j = 0; j <= maxMembers; j++)
                {
                    if (j < clubs[i].MemberNumber)
                    {
                        area[i, j] = area[i + 1, j];
                    }
                    else
                    {
                        area[i, j] = Math.Max(area[i + 1, j], area[i + 1, j - clubs[i].MemberNumber] + clubs[i].Area);
                    }
                }
            }

            var maxArea = area[0, maxMembers];
            return maxArea;
        }
    }
    /// <summary>
    /// 部活
    /// </summary>
    class Club
    {
        /// <summary>
        /// 面積
        /// </summary>
        public int Area { get; set; }
        /// <summary>
        /// 部員数
        /// </summary>
        public int MemberNumber { get; set; }
    }
}
