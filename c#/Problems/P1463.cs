using System;
using System.Linq;

namespace LeetCode.Naive.Problems
{
  /// <summary>
  ///    Problem: https://leetcode.com/problems/cherry-pickup-ii/
  ///    Submission: https://leetcode.com/submissions/detail/432289616/
  /// </summary>
  internal class P1463
  {
    public class Solution
    {
      public int CherryPickup(int[][] grid)
      {
        var rows = grid.Length;
        var cols = grid[0].Length;

        var dp = new int[rows, cols + 2, cols + 2];

        for (var row = 0; row < rows; row++)
          for (var col1 = 0; col1 < cols + 2; col1++)
            for (var col2 = 0; col2 < cols + 2; col2++)
              dp[row, col1, col2] = -1;

        // initial state of two robots
        dp[0, 1, cols] = grid[0][0] + grid[0][cols - 1];

        // calculate row by row
        for (var row = 1; row < rows; row++)
        {
          for (var col1 = 0; col1 < cols; col1++)
          {
            for (var col2 = 0; col2 < cols; col2++)
            {
              var max = -1;
              for (var p1 = col1 - 1; p1 <= col1 + 1; p1++)
                for (var p2 = col2 - 1; p2 <= col2 + 1; p2++)
                  max = Math.Max(max, dp[row - 1, p1 + 1, p2 + 1]);

              // next state is calculate only if robots can be there
              if (max != -1)
              {
                dp[row, col1 + 1, col2 + 1] = col1 == col2
                  ? max + grid[row][col1]
                  : max + grid[row][col1] + grid[row][col2];
              }
            }
          }
        }

        var ans = 0;

        // check last row
        for (var col1 = 0; col1 < cols; col1++)
          for (var col2 = 0; col2 < cols; col2++)
            ans = Math.Max(ans, dp[rows - 1, col1 + 1, col2 + 1]);

        return ans;
      }
    }
  }
}
