using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode.Naive.Problems
{
  /// <summary>
  ///    Problem: https://leetcode.com/problems/triangle/
  ///    Submission: https://leetcode.com/submissions/detail/241703610/
  /// </summary>
  internal class P0120
  {
    public class Solution
    {
      public int MinimumTotal(IList<IList<int>> triangle)
      {
        var dp = new int[triangle.Count][];

        dp[triangle.Count - 1] = new int[triangle.Count];
        for (int i = 0; i < triangle.Count; i++)
          dp[triangle.Count - 1][i] = triangle[triangle.Count - 1][i];

        for (int row = triangle.Count - 2; row >= 0; row--)
        {
          dp[row] = new int[row + 1];

          for (int col = 0; col <= row; col++)
          {
            dp[row][col] = Math.Min(
                triangle[row][col] + dp[row + 1][col],
                triangle[row][col] + dp[row + 1][col + 1]);
          }
        }

        return dp[0][0];
      }
    }
  }
}
