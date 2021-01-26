using System;
using System.Linq;

namespace LeetCode.Naive.Problems
{
  /// <summary>
  ///    Problem: https://leetcode.com/problems/largest-submatrix-with-rearrangements/
  ///    Submission: https://leetcode.com/submissions/detail/444081708/
  /// </summary>
  internal class P1727
  {
    public class Solution
    {
      public int LargestSubmatrix(int[][] matrix)
      {
        var rows = matrix.Length;
        var cols = matrix[0].Length;

        var cumulatives = new int[rows][];

        for (var row = 0; row < rows; row++)
          cumulatives[row] = new int[cols];

        // calculate number of last consecutive ones in a column up to current [row,col]
        for (var col = 0; col < cols; col++)
        {
          for (var row = 0; row < rows; row++)
          {
            if (matrix[row][col] == 0)
              continue;

            if (row == 0)
              cumulatives[row][col] = 1;
            else
              cumulatives[row][col] = cumulatives[row - 1][col] + 1;
          }
        }

        var ans = 0;

        // sort row and get max area
        for (var row = 0; row < rows; row++)
        {
          var sorted = cumulatives[row].OrderByDescending(d => d).ToList();

          for (var col = 0; col < cols; col++)
            ans = Math.Max(ans, sorted[col] * (col + 1));
        }

        return ans;
      }
    }
  }
}
