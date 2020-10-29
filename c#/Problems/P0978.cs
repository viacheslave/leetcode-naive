using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode.Naive.Problems
{
  /// <summary>
  ///    Problem: https://leetcode.com/problems/longest-turbulent-subarray/
  ///    Submission: https://leetcode.com/submissions/detail/414507954/
  /// </summary>
  internal class P0978
  {
    public class Solution
    {
      public int MaxTurbulenceSize(int[] A)
      {
        var dp = new int[A.Length, 2];

        // 0 - down
        // 1 - up
        dp[0, 0] = 1;
        dp[0, 1] = 1;

        for (var i = 1; i < A.Length; i++)
        {
          dp[i, 0] = dp[i, 1] = 1;

          if (A[i] < A[i - 1])
            dp[i, 0] = Math.Max(1, dp[i - 1, 1] + 1);

          if (A[i] > A[i - 1])
            dp[i, 1] = Math.Max(1, dp[i - 1, 0] + 1);
        }

        var ans = int.MinValue;
        for (var i = 0; i < A.Length; i++)
          for (var j = 0; j < 2; j++)
            ans = Math.Max(dp[i, j], ans);

        return ans;
      }
    }
  }
}
