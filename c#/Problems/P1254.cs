using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode.Naive.Problems
{
  /// <summary>
  ///    Problem: https://leetcode.com/problems/number-of-closed-islands/
  ///    Submission: https://leetcode.com/submissions/detail/280865866/
  /// </summary>
  internal class P1254
  {
    public class Solution
    {
      public int ClosedIsland(int[][] grid)
      {
        var components = new List<HashSet<(int, int)>>();

        for (int i = 0; i < grid.Length; i++)
        {
          for (int j = 0; j < grid[i].Length; j++)
          {
            if (grid[i][j] == 1)
              continue;

            var componentIndex = components.FirstOrDefault(c => c.Contains((i, j)));
            if (componentIndex != null)
              continue;

            components.Add(BuildComponent(grid, i, j));
          }
        }

        return components
            .Count(comp => comp.All(point => !IsCorner(grid, point)));
      }

      private bool IsCorner(int[][] grid, (int i, int j) point)
      {
        return
            point.i == 0 ||
            point.i == grid.Length - 1 ||
            point.j == 0 ||
            point.j == grid[0].Length - 1;
      }

      private HashSet<(int, int)> BuildComponent(int[][] grid, int i, int j)
      {
        var queue = new Queue<(int, int)>();
        queue.Enqueue((i, j));

        var processed = new HashSet<(int, int)>();

        while (queue.Count > 0)
        {
          var point = queue.Dequeue();
          if (processed.Contains(point))
            continue;

          processed.Add(point);

          var left = (point.Item1, point.Item2 - 1);
          var right = (point.Item1, point.Item2 + 1);
          var top = (point.Item1 - 1, point.Item2);
          var bottom = (point.Item1 + 1, point.Item2);

          if (IsInGrid(grid, left) && IsLand(grid, left)) queue.Enqueue(left);
          if (IsInGrid(grid, right) && IsLand(grid, right)) queue.Enqueue(right);
          if (IsInGrid(grid, top) && IsLand(grid, top)) queue.Enqueue(top);
          if (IsInGrid(grid, bottom) && IsLand(grid, bottom)) queue.Enqueue(bottom);
        }

        return processed;
      }

      private bool IsInGrid(int[][] grid, (int i, int j) point)
      {
        return
            point.i >= 0 &&
            point.i < grid.Length &&
            point.j >= 0 &&
            point.j < grid[0].Length;
      }

      private bool IsLand(int[][] grid, (int i, int j) point)
      {
        return grid[point.i][point.j] == 0;
      }
    }
  }
}
