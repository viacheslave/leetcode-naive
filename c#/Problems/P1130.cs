using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode.Naive.Problems
{
  /// <summary>
  ///    Problem: https://leetcode.com/problems/minimum-cost-tree-from-leaf-values/
  ///    Submission: https://leetcode.com/submissions/detail/416020329/
  /// </summary>
  internal class P1130
  {
    public class Solution
    {
      public int MctFromLeafValues(int[] arr)
      {
        var dp = new int[arr.Length, arr.Length];

        for (var i = 0; i < arr.Length; i++)
          for (var j = i; j < arr.Length; j++)
            dp[i, j] = -1;

        DP(arr, 0, arr.Length - 1, dp);

        var ans = dp[0, arr.Length - 1];
        return ans;
      }

      private int DP(int[] arr, int i, int j, int[,] dp)
      {
        if (i == j)
          return 0;

        if (dp[i, j] != -1)
          return dp[i, j];

        var value = int.MaxValue;

        for (var k = i; k < j; k++)
        {
          var c = DP(arr, i, k, dp) + DP(arr, k + 1, j, dp);

          var mxleft = 0;
          for (var l = i; l <= k; l++)
            mxleft = Math.Max(mxleft, arr[l]);

          var mxRight = 0;
          for (var l = k + 1; l <= j; l++)
            mxRight = Math.Max(mxRight, arr[l]);

          c += mxleft * mxRight;

          value = Math.Min(value, c);
        }

        dp[i, j] = value;
        return value;
      }
    }
  }
}
