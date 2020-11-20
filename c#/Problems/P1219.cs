using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode.Naive.Problems
{
  /// <summary>
  ///    Problem: https://leetcode.com/problems/path-with-maximum-gold/
  ///    Submission: https://leetcode.com/submissions/detail/422268464/
  /// </summary>
  internal class P1219
  {
    public class Solution
    {
      int _max = 0;

      public int GetMaximumGold(int[][] grid)
      {
        var rows = grid.Length;
        var cols = grid[0].Length;

        var visited = new int[rows, cols];

        for (var i = 0; i < rows; ++i)
        {
          for (var j = 0; j < cols; ++j)
          {
            if (grid[i][j] != 0)
            {
              visited[i, j] = 1;

              DFS(grid, (i, j), rows, cols, visited, grid[i][j]);

              visited[i, j] = 0;
            }
          }
        }

        return _max;
      }

      private void DFS(int[][] grid, (int i, int j) p, int rows, int cols, int[,] visited, int sum)
      {
        _max = Math.Max(_max, sum);

        var paths = new List<(int i, int j)>
        {
          (p.i - 1, p.j),
          (p.i + 1, p.j),
          (p.i, p.j - 1),
          (p.i, p.j + 1),
        };

        foreach (var path in paths)
        {
          if (path.i >= 0 && path.j >= 0 && path.i < rows && path.j < cols)
          {
            if (visited[path.i, path.j] == 1 || grid[path.i][path.j] == 0)
              continue;

            visited[path.i, path.j] = 1;

            DFS(grid, path, rows, cols, visited, sum + grid[path.i][path.j]);

            visited[path.i, path.j] = 0;
          }
        }
      }
    }
  }
}
