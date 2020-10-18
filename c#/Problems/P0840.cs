using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;

namespace LeetCode.Naive.Problems
{
  /// <summary>
  ///    Problem: https://leetcode.com/problems/magic-squares-in-grid/
  ///    Submission: https://leetcode.com/submissions/detail/230694020/
  /// </summary>
  internal class P0840
  {
    public class Solution
    {
      public int NumMagicSquaresInside(int[][] grid)
      {
        var rows = grid.Length;
        var cols = grid[0].Length;

        if (rows < 3 || cols < 3)
          return 0;

        var count = 0;

        for (var r = 0; r < rows - 2; r++)
        {
          for (var c = 0; c < cols - 2; c++)
          {
            if (IsMagic(grid, r, r + 2, c, c + 2))
              count++;
          }
        }

        return count;
      }

      bool IsMagic(int[][] grid, int startRow, int endRow, int startCol, int endCol)
      {
        var hs = new HashSet<int>();

        for (var i = 0; i <= 2; i++)
        {
          for (var j = 0; j <= 2; j++)
          {
            if (grid[startRow + i][startCol + j] < 1 || grid[startRow + i][startCol + j] > 9)
              return false;

            if (hs.Contains(grid[startRow + i][startCol + j]))
              return false;

            hs.Add(grid[startRow + i][startCol + j]);
          }
        }

        int r1 = 0;
        int r2 = 0;
        int r3 = 0;
        int c1 = 0;
        int c2 = 0;
        int c3 = 0;
        int d1 = 0;
        int d2 = 0;

        for (var i = startCol; i <= endCol; i++)
        {
          r1 += grid[startRow][i];
          r2 += grid[startRow + 1][i];
          r3 += grid[startRow + 2][i];
        }

        for (var i = startRow; i <= endRow; i++)
        {
          c1 += grid[i][startCol];
          c2 += grid[i][startCol + 1];
          c3 += grid[i][startCol + 2];
        }

        for (var i = 0; i <= 2; i++)
        {
          d1 += grid[startRow + i][startCol + i];
          d2 += grid[startRow + 2 - i][startCol + i];
        }

        return r1 == r2
            && r2 == r3
            && r3 == c1
            && c1 == c2
            && c2 == c3
            && c3 == d1
            && d1 == d2;
      }
    }
  }
}
