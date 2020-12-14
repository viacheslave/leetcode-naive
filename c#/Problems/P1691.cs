using System;
using System.Collections.Generic;
using System.Linq;

namespace LeetCode.Naive.Problems
{
  /// <summary>
  ///    Problem: https://leetcode.com/problems/maximum-height-by-stacking-cuboids/
  ///    Submission: https://leetcode.com/submissions/detail/430227589/
  /// </summary>
  internal class P1691
  {
    public class Solution
    {
      public int MaxHeight(int[][] cuboids)
      {
        var arr = cuboids.Select(x => x.OrderBy(_ => _).ToList())
          .OrderByDescending(x => x[2])
          .ThenByDescending(x => x[1])
          .ThenByDescending(x => x[0])
          .ToList();

        var heights = arr.Select(x => x[2]).ToArray();
        var dims = arr.Select(x => (x[0], x[1])).ToArray();

        var dp = new Dictionary<(int, int), int>();
        dp[dims[0]] = heights[0];

        for (var i = 1; i < dims.Length; i++)
        {
          var next = new Dictionary<(int, int), int>();

          var height = heights[i];
          var heightRev = heights[i];

          var dim = dims[i];
          var dimRev = (dims[i].Item2, dims[i].Item1);

          next[dim] = next.ContainsKey(dim)
            ? Math.Max(next[dim], heights[i])
            : heights[i];

          next[dimRev] = next.ContainsKey(dimRev)
            ? Math.Max(next[dimRev], heights[i])
            : heights[i];

          foreach (var entry in dp)
          {
            if (dim.Item1 <= entry.Key.Item1 && dim.Item2 <= entry.Key.Item2)
            {
              next[dim] = next.ContainsKey(dim)
                ? Math.Max(next[dim], entry.Value + heights[i])
                : entry.Value + heights[i];
            }

            if (dimRev.Item1 <= entry.Key.Item1 && dimRev.Item2 <= entry.Key.Item2)
            {
              next[dimRev] = next.ContainsKey(dimRev)
                ? Math.Max(next[dimRev], entry.Value + heights[i])
                : entry.Value + heights[i];
            }

            next[entry.Key] = next.ContainsKey(entry.Key)
              ? Math.Max(next[entry.Key], entry.Value)
              : entry.Value;
          }

          dp = next;
        }

        var ans = dp.Max(c => c.Value);
        return ans;
      }
    }
  }
}
