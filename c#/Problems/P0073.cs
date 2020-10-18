using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode.Naive.Problems
{
  /// <summary>
  ///    Problem: https://leetcode.com/problems/set-matrix-zeroes/
  ///    Submission: https://leetcode.com/submissions/detail/232036395/
  /// </summary>
  internal class P0073
  {
    public class Solution
    {
      public void SetZeroes(int[][] matrix)
      {

        var rows = new HashSet<int>();
        var cols = new HashSet<int>();

        for (var i = 0; i < matrix.Length; i++)
        {
          for (var j = 0; j < matrix[i].Length; j++)
          {
            if (matrix[i][j] == 0)
            {
              rows.Add(i);
              cols.Add(j);
            }
          }
        }

        foreach (var row in rows)
          for (var col = 0; col < matrix[0].Length; col++)
            matrix[row][col] = 0;


        foreach (var col in cols)
          for (var row = 0; row < matrix.Length; row++)
            matrix[row][col] = 0;
      }
    }
  }
}
