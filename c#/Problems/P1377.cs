using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode.Naive.Problems
{
  /// <summary>
  ///    Problem: https://leetcode.com/problems/frog-position-after-t-seconds/
  ///    Submission: https://leetcode.com/submissions/detail/401446410/
  /// </summary>
  internal class P1377
  {
    public class Solution
    {
      public double FrogPosition(int n, int[][] edges, int t, int target)
      {
        if (n == 1)
          return 1;

        var map = new Dictionary<int, List<int>>();

        foreach (var edge in edges)
        {
          if (!map.ContainsKey(edge[0]))
            map[edge[0]] = new List<int>();

          if (!map.ContainsKey(edge[1]))
            map[edge[1]] = new List<int>();

          map[edge[0]].Add(edge[1]);
          map[edge[1]].Add(edge[0]);
        }

        var visited = new HashSet<int>();
        var queue = new Queue<(int val, int time, double prob)>();

        queue.Enqueue((1, 0, 1));

        while (queue.Count > 0)
        {
          var el = queue.Dequeue();

          if (el.time == t)
          {
            if (el.val == target)
              return el.prob;
            else
              continue;
          }

          var targets = map[el.val].Where(x => !visited.Contains(x)).ToList();

          if (targets.Count == 0)
          {
            queue.Enqueue((el.val, el.time + 1, el.prob));
            continue;
          }

          var prob = el.prob / targets.Count;

          foreach (var child in targets)
            queue.Enqueue((child, el.time + 1, prob));

          visited.Add(el.val);
        }

        return 0;
      }
    }
  }
}
