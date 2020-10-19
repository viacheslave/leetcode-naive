using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode.Naive.Problems
{
  /// <summary>
  ///    Problem: https://leetcode.com/problems/longest-arithmetic-subsequence/
  ///    Submission: https://leetcode.com/submissions/detail/410623711/
  /// </summary>
  internal class P1027
  {
    public class Solution
    {
      public int LongestArithSeqLength(int[] A)
      {
        var n = A.Length;
        var mxk = 500;

        var dp = new int[n, mxk * 2 + 1];

        for (var i = 0; i < n; i++)
        {
          for (var k = 0; k < i; k++)
          {
            var diff = (A[i] - A[k]) + mxk;
            dp[i, diff] = dp[k, diff] + 1;
          }
        }

        var ans = 0;

        for (var i = 0; i < n; i++)
          for (var k = 0; k < mxk * 2 + 1; k++)
            ans = Math.Max(ans, dp[i, k]);

        return ans + 1;
      }
    }
  }
}
