using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;

namespace LeetCode.Naive.Problems
{
  /// <summary>
  ///    Problem: https://leetcode.com/problems/surface-area-of-3d-shapes/
  ///    Submission: https://leetcode.com/submissions/detail/238022059/
  /// </summary>
  internal class P0892
  {
    public class Solution
    {
      public int SurfaceArea(int[][] grid)
      {
        var result = 0;

        for (var i = 0; i < grid.Length; i++)
        {
          for (var j = 0; j < grid[i].Length; j++)
          {
            if (grid[i][j] == 0)
              continue;

            var surf = grid[i][j] * 4 + 2;

            surf -= Dec(grid, grid[i][j], i - 1, j);
            surf -= Dec(grid, grid[i][j], i + 1, j);
            surf -= Dec(grid, grid[i][j], i, j - 1);
            surf -= Dec(grid, grid[i][j], i, j + 1);

            result += surf;
          }
        }

        return result;
      }

      private int Dec(int[][] grid, int h, int i, int j)
      {
        if (i < 0 || j < 0 || i >= grid.Length || j >= grid[0].Length)
          return 0;

        if (grid[i][j] == 0)
          return 0;

        return Math.Min(h, grid[i][j]);
      }
    }
  }
}
