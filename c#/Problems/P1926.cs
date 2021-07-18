using System;
using System.Collections.Generic;
using System.Linq;

namespace LeetCode.Naive.Problems
{
  /// <summary>
  ///    Problem: https://leetcode.com/problems/nearest-exit-from-entrance-in-maze/
  ///    Submission: https://leetcode.com/submissions/detail/524610669/
  /// </summary>
  internal class P1926
  {
    public class Solution
    {
      public int NearestExit(char[][] maze, int[] entrance)
      {
        var rows = maze.Length;
        var cols = maze[0].Length;

        var visited = new HashSet<(int row, int col)>();
        visited.Add((entrance[0], entrance[1]));

        var q = new Queue<(int row, int col, int steps)>();
        q.Enqueue((entrance[0], entrance[1], 0));

        while (q.Count > 0)
        {
          var el = q.Dequeue();
          if (visited.Contains((el.row, el.col)) && el.steps > 0)
            continue;

          if (maze[el.row][el.col] == '.' &&
              (el.steps > 0) &&
              (el.row == 0 || el.col == 0 || el.row == rows - 1 || el.col == cols - 1))
            return el.steps;

          visited.Add((el.row, el.col));

          var next = new[]
          {
            (el.row + 1, el.col),
            (el.row - 1, el.col),
            (el.row, el.col + 1),
            (el.row, el.col - 1),
          };

          foreach (var item in next)
          {
            if (item.Item1 < 0 || item.Item2 < 0 || item.Item1 >= rows || item.Item2 >= cols)
              continue;

            if (maze[item.Item1][item.Item2] == '+')
              continue;

            q.Enqueue((item.Item1, item.Item2, el.steps + 1));
          }
        }

        return -1;
      }
    }
  }
}
