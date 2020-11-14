using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode.Naive.Problems
{
  /// <summary>
  ///    Problem: https://leetcode.com/problems/poor-pigs/
  ///    Submission: https://leetcode.com/submissions/detail/420153278/
  /// </summary>
  internal class P0458
  {
    public class Solution
    {
      public int PoorPigs(int buckets, int minutesToDie, int minutesToTest)
      {
        var t = minutesToTest / minutesToDie + 1;

        var exp = 0;
        for (; ; )
        {
          var pow = (int)Math.Pow(t, exp);
          if (pow >= buckets)
            return exp;

          exp++;
        }
      }
    }
  }
}
