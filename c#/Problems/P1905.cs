using System;
using System.Collections.Generic;
using System.Linq;

namespace LeetCode.Naive.Problems
{
  /// <summary>
  ///    Problem: https://leetcode.com/problems/count-sub-islands/
  ///    Submission: https://leetcode.com/submissions/detail/512653990/
  /// </summary>
  internal class P1905
  {
    public class Solution
    {
      public int CountSubIslands(int[][] grid1, int[][] grid2)
      {
        var visited = new HashSet<(int x, int y)>();
        var islands = new List<List<(int x, int y)>>();

        for (var row = 0; row < grid2.Length; row++)
        {
          for (var col = 0; col < grid2[0].Length; col++)
          {
            if (visited.Contains((row, col)))
              continue;

            if (grid2[row][col] == 1)
            {
              var island = BuildIsland(grid2, row, col, visited);
              islands.Add(island);
            }
          }
        }

        var ans = 0;

        foreach (var island in islands)
          if (island.All(p => grid1[p.x][p.y] == 1))
            ans++;

        return ans;
      }

      private List<(int x, int y)> BuildIsland(int[][] grid2, int row, int col, HashSet<(int x, int y)> visited)
      {
        var island = new List<(int x, int y)>();

        var q = new Queue<(int x, int y)>();
        q.Enqueue((row, col));

        while (q.Count > 0)
        {
          var el = q.Dequeue();
          if (visited.Contains(el))
            continue;

          visited.Add(el);
          island.Add(el);

          var next = new List<(int x, int y)>();
          next.Add((el.x - 1, el.y));
          next.Add((el.x + 1, el.y));
          next.Add((el.x, el.y - 1));
          next.Add((el.x, el.y + 1));

          foreach (var n in next)
          {
            if (n.x < 0 || n.x >= grid2.Length || n.y < 0 || n.y >= grid2[0].Length)
              continue;

            if (grid2[n.x][n.y] == 0)
              continue;

            q.Enqueue((n.x, n.y));
          }
        }

        return island;
      }
    }
  }
}
