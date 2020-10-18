using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode.Naive.Problems
{
  /// <summary>
  ///    Problem: https://leetcode.com/problems/largest-1-bordered-square/
  ///    Submission: https://leetcode.com/submissions/detail/281316623/
  /// </summary>
  internal class P1139
  {
    public class Solution
    {
      public int Largest1BorderedSquare(int[][] grid)
      {
        var numOnes = new Dictionary<(int, int), (int left, int top, int right, int bottom)>();

        for (int i = 0; i < grid.Length; i++)
          for (int j = 0; j < grid[i].Length; j++)
            FindNumOnes(numOnes, grid, (i, j));

        var maxLength = int.MinValue;

        for (int i = 0; i < grid.Length; i++)
        {
          for (int j = 0; j < grid[i].Length; j++)
          {
            if (grid[i][j] == 0)
              continue;

            maxLength = Math.Max(maxLength, 1);

            var length = 0;

            for (int x = i + 1, y = j + 1; ; x++, y++)
            {
              length++;

              if (x >= grid.Length || y >= grid[0].Length)
                break;

              if (grid[x][y] == 0)
                continue;

              var startData = numOnes[(i, j)];
              var endData = numOnes[(x, y)];

              if (
                  startData.bottom >= length &&
                  startData.right >= length &&
                  endData.left >= length &&
                  endData.top >= length
                  )
              {
                maxLength = Math.Max(maxLength, length + 1);
              }
            }

            length = 0;

            for (int x = i - 1, y = j + 1; ; x--, y++)
            {
              length++;

              if (x < 0 || y >= grid[0].Length)
                break;

              if (grid[x][y] == 0)
                continue;

              var startData = numOnes[(i, j)];
              var endData = numOnes[(x, y)];

              if (
                  startData.top >= length &&
                  startData.right >= length &&
                  endData.left >= length &&
                  endData.bottom >= length
                  )
              {
                maxLength = Math.Max(maxLength, length + 1);
              }
            }
          }
        }

        return maxLength * maxLength;
      }

      private void FindNumOnes(
          Dictionary<(int, int), (int, int, int, int)> numOnes,
          int[][] grid,
          (int i, int j) point)
      {
        if (grid[point.i][point.j] == 0)
          return;

        int left = 0, top = 0, right = 0, bottom = 0;

        for (int col = point.j - 1; col >= 0; col--)
        {
          if (grid[point.i][col] == 0)
            break;

          left++;
        }

        for (int col = point.j + 1; col < grid[0].Length; col++)
        {
          if (grid[point.i][col] == 0)
            break;

          right++;
        }

        for (int row = point.i - 1; row >= 0; row--)
        {
          if (grid[row][point.j] == 0)
            break;

          top++;
        }

        for (int row = point.i + 1; row < grid.Length; row++)
        {
          if (grid[row][point.j] == 0)
            break;

          bottom++;
        }

        numOnes[point] = (left, top, right, bottom);
      }
    }
  }
}
