using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode.Naive.Problems
{
  /// <summary>
  ///    Problem: https://leetcode.com/problems/possible-bipartition/
  ///    Submission: https://leetcode.com/submissions/detail/378522743/
  /// </summary>
  internal class P0886
  {
    public class Solution
    {
      public bool PossibleBipartition(int N, int[][] dislikes)
      {
        var map = new Dictionary<int, List<int>>();
        var groups = new Dictionary<int, int>();

        // map
        for (int i = 0; i < dislikes.Length; i++)
        {
          if (!map.ContainsKey(dislikes[i][0]))
            map.Add(dislikes[i][0], new List<int>());

          if (!map.ContainsKey(dislikes[i][1]))
            map.Add(dislikes[i][1], new List<int>());

          map[dislikes[i][0]].Add(dislikes[i][1]);
          map[dislikes[i][1]].Add(dislikes[i][0]);
        }

        if (map.Count == 0)
          return true;

        groups[map.Keys.First()] = 0;

        var result = true;

        foreach (var key in map.Keys)
          result &= Traverse(key, map[key], map, groups);

        return result;
      }

      private bool Traverse(int start, List<int> points, Dictionary<int, List<int>> map, Dictionary<int, int> groups)
      {
        if (!groups.ContainsKey(start))
          groups[start] = 0;

        var currentGroup = groups[start];
        var putGroup = 1 - groups[start];

        var result = true;

        foreach (var point in points)
        {
          if (groups.ContainsKey(point))
          {
            if (groups[point] == putGroup)
              continue;
            else
              return false;
          }

          groups[point] = putGroup;
          result &= Traverse(point, map[point], map, groups);
        }

        return result;
      }
    }
  }
}
