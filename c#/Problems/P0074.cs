using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode.Naive.Problems
{
  /// <summary>
  ///    Problem: https://leetcode.com/problems/search-a-2d-matrix/
  ///    Submission: https://leetcode.com/submissions/detail/235004850/
  /// </summary>
  internal class P0074
  {
    public class Solution
    {
      public bool SearchMatrix(int[][] matrix, int target)
      {
        if (matrix.Length == 0)
          return false;

        var row = -1;
        for (var i = 0; i < matrix.Length; i++)
        {
          if (i + 1 == matrix.Length)
          {
            row = i;
            break;
          }

          if (matrix[i][0] <= target && target < matrix[i + 1][0])
          {
            row = i;
            break;
          }
        }

        if (row == -1)
          return false;

        return new HashSet<int>(matrix[row]).Contains(target);
      }
    }
  }
}
