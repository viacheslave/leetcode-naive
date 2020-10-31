using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode.Naive.Problems
{
  /// <summary>
  ///    Problem: https://leetcode.com/problems/maximum-non-negative-product-in-a-matrix/
  ///    Submission: https://leetcode.com/submissions/detail/415234410/
  /// </summary>
  internal class P1594
  {
    public class Solution
    {
      public int MaxProductPath(int[][] grid)
      {
        var dp = new Dictionary<(int row, int col), (long min, long max)>();
        dp.Add((0, 0), (grid[0][0], grid[0][0]));

        DP(dp, grid, (row: grid.Length - 1, col: grid[0].Length - 1));

        var value = dp[(row: grid.Length - 1, col: grid[0].Length - 1)];

        if (value.min < 0 && value.max < 0)
          return -1;

        var mod = (int)1e9 + 7;
        return (int)(Math.Max(value.min, value.max) % mod);
      }

      private (long min, long max) DP(Dictionary<(int row, int col), (long min, long max)> dp, int[][] grid, (int row, int col) p)
      {
        if (dp.ContainsKey(p))
          return dp[p];

        var min = long.MinValue;
        var max = long.MaxValue;

        if (p.row == 0)
        {
          var point_c = DP(dp, grid, (p.row, p.col - 1));

          var values = new[] {
            point_c.min * grid[p.row][p.col],
            point_c.max * grid[p.row][p.col]
          };

          min = values.Min();
          max = values.Max();
        }
        else if (p.col == 0)
        {
          var point_r = DP(dp, grid, (p.row - 1, p.col));

          var values = new[] {
            point_r.min * grid[p.row][p.col],
            point_r.max * grid[p.row][p.col]
          };

          min = values.Min();
          max = values.Max();
        }
        else
        {
          var point_c = DP(dp, grid, (p.row, p.col - 1));
          var point_r = DP(dp, grid, (p.row - 1, p.col));

          var values = new[] {
            point_c.min * grid[p.row][p.col],
            point_c.max * grid[p.row][p.col],
            point_r.min * grid[p.row][p.col],
            point_r.max * grid[p.row][p.col]
          };

          min = values.Min();
          max = values.Max();
        }

        dp[p] = (min, max);
        return dp[p];
      }
    }
  }
}
