using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode.Naive.Problems
{
  /// <summary>
  ///    Problem: https://leetcode.com/problems/path-with-minimum-effort/
  ///    Submission: https://leetcode.com/submissions/detail/420916389/
  /// </summary>
  internal class P1631
  {
    public class Solution
    {
      public int MinimumEffortPath(int[][] heights)
      {
        var min = 0;
        var max = int.MinValue;

        for (var col = 0; col < heights[0].Length; col++)
        {
          for (var row = 0; row < heights.Length; row++)
          {
            min = Math.Min(min, heights[row][col]);
            max = Math.Max(max, heights[row][col]);
          }
        }

        var from = min;
        var to = max;

        // binary search
        while (true)
        {
          if (to - from == 1)
          {
            if (Possible(from, heights))
              return from;
            return to;
          }

          var mid = (from + to) / 2;
          if (Possible(mid, heights))
            to = mid;
          else
            from = mid;
        }
      }

      private bool Possible(int threshold, int[][] heights)
      {
        var start = (0, 0);
        var end = (heights.Length - 1, heights[0].Length - 1);

        var visited = new HashSet<(int x, int y)>();
        var queue = new Queue<(int x, int y)>();

        queue.Enqueue(start);

        while (queue.Count > 0)
        {
          var item = queue.Dequeue();
          if (item == end)
            return true;

          if (visited.Contains(item))
            continue;

          visited.Add(item);

          var h_paths = new List<(int x, int y)>
          {
            (item.x, item.y - 1),
            (item.x, item.y + 1),
            (item.x - 1, item.y),
            (item.x + 1, item.y),
          };

          foreach (var path in h_paths)
            if (path.x >= 0 && path.x < heights.Length && path.y >= 0 && path.y < heights[0].Length)
              if (Math.Abs(heights[item.x][item.y] - heights[path.x][path.y]) <= threshold)
                queue.Enqueue(path);
        }

        return false;
      }
    }
  }
}
