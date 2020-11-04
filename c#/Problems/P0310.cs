using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode.Naive.Problems
{
  /// <summary>
  ///    Problem: https://leetcode.com/problems/minimum-height-trees/
  ///    Submission: https://leetcode.com/submissions/detail/416726218/
  /// </summary>
  internal class P0310
  {
    public class Solution
    {
      public IList<int> FindMinHeightTrees(int n, int[][] edges)
      {
        if (edges.Length == 0)
          return new List<int>() { 0 };

        var conn = new Dictionary<int, HashSet<int>>();

        foreach (var edge in edges)
        {
          if (!conn.ContainsKey(edge[0])) conn[edge[0]] = new HashSet<int>();
          if (!conn.ContainsKey(edge[1])) conn[edge[1]] = new HashSet<int>();

          conn[edge[0]].Add(edge[1]);
          conn[edge[1]].Add(edge[0]);
        }

        var queue = new Queue<int>();

        while (true)
        {
          if (conn.Count <= 2)
            return conn.Keys.ToList();

          foreach (var f in conn)
            if (f.Value.Count == 1)
              queue.Enqueue(f.Key);

          while (queue.Count > 0)
          {
            var node = queue.Dequeue();

            var connections = conn[node];
            foreach (var child in connections)
              conn[child].Remove(node);

            conn.Remove(node);
          }
        }

        return null;
      }
    }
  }
}
