using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode.Naive.Problems
{
  /// <summary>
  ///    Problem: https://leetcode.com/problems/coloring-a-border/
  ///    Submission: https://leetcode.com/submissions/detail/245953406/
  /// </summary>
  internal class P1034
  {
    public class Solution
    {
      public int[][] ColorBorder(int[][] grid, int r0, int c0, int color)
      {
        var pricolor = grid[r0][c0];

        var borderList = new HashSet<(int, int)>();
        var visited = new HashSet<(int, int)>();

        var queue = new Queue<(int, int)>();
        queue.Enqueue((r0, c0));

        while (queue.Count > 0)
        {
          var item = queue.Dequeue();
          if (visited.Contains(item))
            continue;

          visited.Add(item);

          if (grid[item.Item1][item.Item2] == pricolor)
          {
            if (IsBorder(grid, item, pricolor))
              borderList.Add(item);

            var left = (item.Item1, item.Item2 - 1);
            var right = (item.Item1, item.Item2 + 1);
            var top = (item.Item1 - 1, item.Item2);
            var bottom = (item.Item1 + 1, item.Item2);

            if (IsValid(grid, left)) queue.Enqueue(left);
            if (IsValid(grid, right)) queue.Enqueue(right);
            if (IsValid(grid, top)) queue.Enqueue(top);
            if (IsValid(grid, bottom)) queue.Enqueue(bottom);
          }
        }

        foreach (var item in borderList)
        {
          grid[item.Item1][item.Item2] = color;
        }

        return grid;
      }

      private bool IsBorder(int[][] grid, (int, int) item, int pricolor)
      {
        var left = (item.Item1, item.Item2 - 1);
        var right = (item.Item1, item.Item2 + 1);
        var top = (item.Item1 - 1, item.Item2);
        var bottom = (item.Item1 + 1, item.Item2);

        return (!IsValid(grid, left) || grid[left.Item1][left.Item2] != pricolor)
            || (!IsValid(grid, right) || grid[right.Item1][right.Item2] != pricolor)
            || (!IsValid(grid, top) || grid[top.Item1][top.Item2] != pricolor)
            || (!IsValid(grid, bottom) || grid[bottom.Item1][bottom.Item2] != pricolor);
      }

      private bool IsValid(int[][] grid, (int, int) item)
      {
        return item.Item1 >= 0
            && item.Item2 >= 0
            && item.Item1 < grid.Length
            && item.Item2 < grid[0].Length;
      }
    }
  }
}
