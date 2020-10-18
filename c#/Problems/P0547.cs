using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;

namespace LeetCode.Naive.Problems
{
  /// <summary>
  ///    Problem: https://leetcode.com/problems/friend-circles/
  ///    Submission: https://leetcode.com/submissions/detail/241712169/
  /// </summary>
  internal class P0547
  {
    public class Solution
    {
      public int FindCircleNum(int[][] M)
      {
        var map = new Dictionary<int, HashSet<int>>();

        for (int i = 0; i < M.Length; i++)
          map[i] = new HashSet<int>();

        for (int i = 0; i < M.Length; i++)
          for (int j = 0; j < M.Length; j++)
            if (M[i][j] == 1)
              map[i].Add(j);

        var count = 0;

        while (map.Count > 0)
        {
          var visited = new HashSet<int>();

          var id = map.First().Key;
          Traverse(id, map, visited);

          count++;

          foreach (var item in visited)
            map.Remove(item);
        }

        return count;
      }

      private void Traverse(int id, Dictionary<int, HashSet<int>> map, HashSet<int> visited)
      {
        visited.Add(id);

        foreach (var item in map[id])
          if (!visited.Contains(item))
            Traverse(item, map, visited);
      }
    }
  }
}
