using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;

namespace LeetCode.Naive.Problems
{
  /// <summary>
  ///    Problem: https://leetcode.com/problems/island-perimeter/
  ///    Submission: https://leetcode.com/submissions/detail/226911084/
  /// </summary>
  internal class P0463
  {
    public class Solution
    {
      public int IslandPerimeter(int[][] grid)
      {
        var ones = 0;
        var borders = 0;

        for (int i = 0; i < grid.Length; i++)
        {
          for (int j = 0; j < grid[i].Length; j++)
          {
            if (grid[i][j] == 0)
              continue;

            ones++;

            if (i - 1 >= 0 && grid[i - 1][j] == 1)
              borders++;
            if (i + 1 < grid.Length && grid[i + 1][j] == 1)
              borders++;
            if (j - 1 >= 0 && grid[i][j - 1] == 1)
              borders++;
            if (j + 1 < grid[i].Length && grid[i][j + 1] == 1)
              borders++;

          }
        }
        //return borders;

        return ones * 4 - borders;
      }
    }
  }
}
