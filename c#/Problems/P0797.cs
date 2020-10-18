using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;

namespace LeetCode.Naive.Problems
{
  /// <summary>
  ///    Problem: https://leetcode.com/problems/all-paths-from-source-to-target/
  ///    Submission: https://leetcode.com/submissions/detail/239449970/
  /// </summary>
  internal class P0797
  {
    public class Solution
    {
      public IList<IList<int>> AllPathsSourceTarget(int[][] graph)
      {
        var currentPath = new List<int>();
        var map = new Dictionary<int, List<int>>();
        var res = new List<IList<int>>();

        for (var i = 0; i < graph.Length; i++)
        {
          if (!map.ContainsKey(i))
            map[i] = new List<int>();

          map[i] = graph[i].ToList();
        }

        currentPath.Add(0);
        Search(res, currentPath, map, 0, graph.Length - 1);

        return res;
      }

      private void Search(List<IList<int>> res, List<int> currentPath, Dictionary<int, List<int>> map, int current, int last)
      {
        if (current == last)
        {
          res.Add(currentPath.ToList());
          return;
        }

        if (map.ContainsKey(current))
        {
          foreach (var next in map[current])
          {
            currentPath.Add(next);
            Search(res, currentPath, map, next, last);
            currentPath.RemoveAt(currentPath.Count - 1);
          }
        }
      }
    }
  }
}
