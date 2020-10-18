using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode.Naive.Problems
{
  /// <summary>
  ///    Problem: https://leetcode.com/problems/flower-planting-with-no-adjacent/
  ///    Submission: https://leetcode.com/submissions/detail/327815976/
  /// </summary>
  internal class P1042
  {
    public class Solution
    {
      public int[] GardenNoAdj(int N, int[][] paths)
      {
        var map = new Dictionary<int, List<int>>();
        var hs = Enumerable.Range(1, 4).ToHashSet();

        foreach (var path in paths)
        {
          if (!map.ContainsKey(path[0]))
            map[path[0]] = new List<int>();
          if (!map.ContainsKey(path[1]))
            map[path[1]] = new List<int>();

          map[path[0]].Add(path[1]);
          map[path[1]].Add(path[0]);
        }

        var visited = Enumerable.Range(1, N).ToDictionary(x => x, x => 0);

        foreach (var node in visited.Keys.ToList())
        {
          if (visited[node] > 0)
            continue;

          if (!map.ContainsKey(node))
            visited[node] = 1;

          // process connections
          var q = new Queue<int>();
          q.Enqueue(node);

          while (q.Count > 0)
          {
            var item = q.Dequeue();
            if (visited[item] > 0)
              continue;

            var connections = map[item];
            var pick = hs.Except(connections.Where(c => visited[c] > 0).Select(c => visited[c])).First();

            visited[item] = pick;

            foreach (var connection in connections.Where(c => visited[c] == 0))
            {
              q.Enqueue(connection);
            }
          }
        }

        return visited.OrderBy(x => x.Key).Select(x => x.Value).ToArray();
      }
    }
  }
}
