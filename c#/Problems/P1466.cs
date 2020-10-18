using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode.Naive.Problems
{
  /// <summary>
  ///    Problem: https://leetcode.com/problems/reorder-routes-to-make-all-paths-lead-to-the-city-zero/
  ///    Submission: https://leetcode.com/submissions/detail/378424062/
  /// </summary>
  internal class P1466
  {
    public class Solution
    {
      public int MinReorder(int n, int[][] connections)
      {
        var existing = new Dictionary<int, List<int>>();
        var fake = new Dictionary<int, List<int>>();

        for (var i = 0; i < connections.Length; i++)
        {
          var start = connections[i][0];
          var end = connections[i][1];

          if (!existing.ContainsKey(start))
            existing[start] = new List<int>();

          if (!fake.ContainsKey(end))
            fake[end] = new List<int>();

          existing[start].Add(end);
          fake[end].Add(start);
        }

        var queue = new Queue<int>();
        queue.Enqueue(0);

        var ans = 0;
        var visited = new HashSet<int>();

        while (queue.Count > 0)
        {
          var item = queue.Dequeue();
          visited.Add(item);

          if (existing.ContainsKey(item))
          {
            foreach (var i in existing[item])
            {
              if (visited.Contains(i))
                continue;

              queue.Enqueue(i);
              ans++;
            }
          }

          if (fake.ContainsKey(item))
          {
            foreach (var i in fake[item])
            {
              if (visited.Contains(i))
                continue;

              queue.Enqueue(i);
            }
          }
        }

        return ans;
      }
    }
  }
}
