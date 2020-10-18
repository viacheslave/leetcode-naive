using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;

namespace LeetCode.Naive.Problems
{
  /// <summary>
  ///    Problem: https://leetcode.com/problems/unique-paths-iii/
  ///    Submission: https://leetcode.com/submissions/detail/312397139/
  /// </summary>
  internal class P0980
  {
    public class Solution
    {
      public int UniquePathsIII(int[][] grid)
      {
        var start = (0, 0);
        var end = (0, 0);
        var obs = new HashSet<(int, int)>();


        for (var i = 0; i < grid.Length; i++)
        {
          for (var j = 0; j < grid[0].Length; j++)
          {
            if (grid[i][j] == 1) start = (i, j);
            if (grid[i][j] == 2) end = (i, j);
            if (grid[i][j] == -1) obs.Add((i, j));
          }
        }

        var visited = new HashSet<(int, int)>() { start };

        return GetNumber(start, end, obs, visited, grid, grid.Length, grid[0].Length);
      }

      private int GetNumber((int, int) start, (int, int) end, HashSet<(int, int)> obs, HashSet<(int, int)> visited, int[][] grid, int rows, int cols)
      {
        if (start == end)
        {
          if (visited.Count + obs.Count == rows * cols)
            return 1;
          return 0;
        }

        var ans = 0;

        var dirs = new List<(int x, int y)>()
        {
            (start.Item1 + 0, start.Item2 + 1),
            (start.Item1 + 0, start.Item2 - 1),
            (start.Item1 + 1, start.Item2 + 0),
            (start.Item1 - 1, start.Item2 + 0),
          };

        foreach (var (x, y) in dirs)
        {
          if (x < 0 || y < 0 || x == rows || y == cols)
            continue;

          if (visited.Contains((x, y)) || obs.Contains((x, y)))
            continue;

          visited.Add((x, y));
          ans += GetNumber((x, y), end, obs, visited, grid, rows, cols);
          visited.Remove((x, y));
        }

        return ans;
      }
    }
  }
}
