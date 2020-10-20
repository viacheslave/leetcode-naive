using System;
using System.Collections.Generic;

namespace LeetCode.Naive.Problems
{
  /// <summary>
  ///    Problem: https://leetcode.com/problems/minimum-number-of-days-to-eat-n-oranges/
  ///    Submission: https://leetcode.com/submissions/detail/411184157/
  /// </summary>
  internal class P1553
  {
    public class Solution
    {
      public int MinDays(int n)
      {
        var dp = new Dictionary<int, int>
        {
          [0] = 0,
          [1] = 1
        };

        DP(n, dp);

        var ans = dp[n];
        return ans;
      }

      private int DP(int n, Dictionary<int, int> dp)
      {
        if (dp.ContainsKey(n))
          return dp[n];

        var min = 1 + Math.Min(n % 2 + DP(n / 2, dp), n % 3 + DP(n / 3, dp));

        dp[n] = min;
        return dp[n];
      }
    }
  }
}
