using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode.Naive.Problems
{
  /// <summary>
  ///    Problem: https://leetcode.com/problems/minimum-falling-path-sum-ii/
  ///    Submission: https://leetcode.com/submissions/detail/423295053/
  /// </summary>
  internal class P1289
  {
    public class Solution
    {
      public int MinFallingPathSum(int[][] arr)
      {
        var dp = new int[arr.Length, arr[0].Length];

        for (var j = 0; j < arr[0].Length; j++)
          dp[0, j] = arr[0][j];

        for (var i = 1; i < arr.Length; i++)
        {
          for (var j = 0; j < arr[0].Length; j++)
          {
            var min = int.MaxValue;

            for (var k = 0; k < arr[0].Length; k++)
            {
              if (j == k)
                continue;

              min = Math.Min(min, dp[i - 1, k] + arr[i][j]);
            }

            dp[i, j] = min;
          }
        }

        var ans = int.MaxValue;

        for (var j = 0; j < arr[0].Length; j++)
          ans = Math.Min(ans, dp[arr.Length - 1, j]);

        return ans;
      }
    }
  }
}
