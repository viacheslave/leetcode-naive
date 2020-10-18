using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode.Naive.Problems
{
  /// <summary>
  ///    Problem: https://leetcode.com/problems/minimum-path-sum/
  ///    Submission: https://leetcode.com/submissions/detail/238066988/
  /// </summary>
  internal class P0064
  {
    public class Solution
    {
      public int MinPathSum(int[][] grid)
      {
        var dp = new int[grid.Length][];

        for (var i = grid.Length - 1; i >= 0; i--)
        {
          dp[i] = new int[grid[0].Length];

          for (var j = grid[0].Length - 1; j >= 0; j--)
          {
            if (i == grid.Length - 1 && j == grid[0].Length - 1)
            {
              dp[i][j] = grid[i][j];
              continue;
            }

            var down = int.MaxValue;
            var left = int.MaxValue;

            if (i + 1 < grid.Length)
              down = dp[i + 1][j];

            if (j + 1 < grid[0].Length)
              left = dp[i][j + 1];

            dp[i][j] = grid[i][j] + Math.Min(down, left);
          }
        }

        return dp[0][0];
      }
    }
  }
}
