using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode.Naive.Problems
{
  /// <summary>
  ///    Problem: https://leetcode.com/problems/search-a-2d-matrix-ii/
  ///    Submission: https://leetcode.com/submissions/detail/313401687/
  /// </summary>
  internal class P0240
  {
    public class Solution
    {
      public bool SearchMatrix(int[,] matrix, int target)
      {
        var rows = matrix.GetLength(0);
        var cols = matrix.GetLength(1);

        if (rows == 0 || cols == 0)
          return false;

        if (target < matrix[0, 0] || matrix[rows - 1, cols - 1] < target)
          return false;

        var curcol = 0;
        var currow = 0;

        for (var i = 0; i < rows; i++)
        {
          if (target >= matrix[i, 0])
          {
            currow = i;
            continue;
          }
          break;
        }

        while (currow >= 0 && curcol >= 0 && currow < rows && curcol < cols)
        {
          while (matrix[currow, curcol] > target && currow >= 0)
          {
            currow--;
            if (currow < 0)
              return false;
          }

          if (matrix[currow, curcol] == target)
            return true;

          curcol++;
        }

        return false;
      }
    }
  }
}
