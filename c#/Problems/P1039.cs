using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode.Naive.Problems
{
  /// <summary>
  ///    Problem: https://leetcode.com/problems/minimum-score-triangulation-of-polygon/
  ///    Submission: https://leetcode.com/submissions/detail/410639756/
  /// </summary>
  internal class P1039
  {
    public class Solution
    {
      public int MinScoreTriangulation(int[] A)
      {
        var mxn = A.Length;
        var dp = new int[mxn, mxn];

        var ans = DP(0, mxn - 1, dp, A);
        return ans;
      }

      private int DP(int start, int end, int[,] dp, int[] A)
      {
        if (dp[start, end] != 0)
          return dp[start, end];

        var value = int.MaxValue;

        if (end - start == 2)
        {
          return A[start] * A[start + 1] * A[end];
        }
        else
        {
          for (var mid = start + 1; mid < end; mid++)
          {
            var current = A[start] * A[mid] * A[end];

            if (mid == start + 1)
              current += DP(mid, end, dp, A);
            else if (mid == end - 1)
              current += DP(start, mid, dp, A);
            else
              current += DP(mid, end, dp, A) + DP(start, mid, dp, A);

            value = Math.Min(value, current);
          }
        }

        dp[start, end] = value;
        return value;
      }
    }
  }
}
