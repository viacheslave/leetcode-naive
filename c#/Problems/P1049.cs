using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode.Naive.Problems
{
  /// <summary>
  ///    Problem: https://leetcode.com/problems/last-stone-weight-ii
  ///    Submission: https://leetcode.com/submissions/detail/417496040/
  /// </summary>
  internal class P1049
  {
    class Solution
    {
      public int LastStoneWeightII(int[] stones)
      {
        var dp = new HashSet<int>[stones.Length];
        dp[0] = new HashSet<int>
        {
          -stones[0],
          stones[0]
        };

        for (var i = 1; i < stones.Length; i++)
        {
          dp[i] = new HashSet<int>();

          foreach (var item in dp[i - 1])
          {
            dp[i].Add(item - stones[i]);
            dp[i].Add(item + stones[i]);
          }
        }

        return dp[stones.Length - 1].Where(x => x >= 0).Min();
      }
    }
  }
}
