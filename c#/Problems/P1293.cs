using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode.Naive.Problems
{
  /// <summary>
  ///    Problem: https://leetcode.com/problems/shortest-path-in-a-grid-with-obstacles-elimination/
  ///    Submission: https://leetcode.com/submissions/detail/427143234/
  /// </summary>
  internal class P1293
  {
    public class Solution
    {
      public int ShortestPath(int[][] grid, int k)
      {
        var visited = new HashSet<(int x, int y, int left)>();
        var queue = new Queue<(int x, int y, int left, int distance)>();
        queue.Enqueue((0, 0, k, 0));

        while (queue.Count > 0)
        {
          var item = queue.Dequeue();
          if (item.x == grid.Length - 1 && item.y == grid[0].Length - 1)
            return item.distance;

          if (visited.Contains((item.x, item.y, item.left)))
            continue;

          visited.Add((item.x, item.y, item.left));

          var paths = new List<(int x, int y)>();
          paths.Add((item.x - 1, item.y));
          paths.Add((item.x + 1, item.y));
          paths.Add((item.x, item.y - 1));
          paths.Add((item.x, item.y + 1));

          foreach (var path in paths)
          {
            if (path.x < 0 || path.y < 0 || path.x >= grid.Length || path.y >= grid[0].Length)
              continue;

            if (grid[path.x][path.y] == 0)
              queue.Enqueue((path.x, path.y, item.left, item.distance + 1));
            else if (item.left > 0)
              queue.Enqueue((path.x, path.y, item.left - 1, item.distance + 1));
          }
        }

        return -1;
      }
    }
  }
}
