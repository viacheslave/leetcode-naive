using System.Collections.Generic;
using System.Linq;

namespace LeetCode.Naive.Problems
{
  /// <summary>
  ///    Problem: https://leetcode.com/problems/detect-cycles-in-2d-grid/
  ///    Submission: https://leetcode.com/submissions/detail/428586889/
  /// </summary>
  internal class P1559
  {
    public class Solution
    {
      public bool ContainsCycle(char[][] grid)
      {
        var startPositions = new Dictionary<char, HashSet<(int i, int j)>>();

        for (var i = 0; i < grid.Length; i++)
        {
          for (var j = 0; j < grid[0].Length; j++)
          {
            if (!startPositions.ContainsKey(grid[i][j])) startPositions[grid[i][j]] = new HashSet<(int i, int j)>();
            startPositions[grid[i][j]].Add((i, j));
          }
        }

        foreach (var entry in startPositions)
        {
          var pool = entry.Value;

          while (pool.Count > 0)
          {
            var start = pool.First();
            var visited = new HashSet<(int i, int j)>();

            if (HasCycle(entry.Key, start, grid, visited))
              return true;

            pool.ExceptWith(visited);
          }
        }

        return false;
      }

      private bool HasCycle(char ch, (int i, int j) start, char[][] grid, HashSet<(int i, int j)> visited)
      {
        var q = new Queue<(int i, int j, Direction? direction)>();
        q.Enqueue((start.i, start.j, Direction.None));

        while (q.Count > 0)
        {
          var item = q.Dequeue();
          if (visited.Contains((item.i, item.j)))
            return true;

          visited.Add((item.i, item.j));

          var paths = new List<(int i, int j, Direction direction)>();
          paths.Add((item.i, item.j + 1, Direction.Left));
          paths.Add((item.i, item.j - 1, Direction.Right));
          paths.Add((item.i - 1, item.j, Direction.Down));
          paths.Add((item.i + 1, item.j, Direction.Top));

          foreach (var path in paths)
          {
            if (path.i < 0 || path.j < 0 || path.i >= grid.Length || path.j >= grid[0].Length)
              continue;

            if (grid[path.i][path.j] != ch)
              continue;

            if ((Direction)((int)Direction.All - (int)path.direction) == item.direction)
              continue;

            q.Enqueue(path);
          }
        }

        return false;
      }

      internal enum Direction
      {
        None,
        Right = 1,
        Down = 2,
        Top = 3,
        Left = 4,
        All = 5
      }
    }
  }
}
