using System;
using System.Collections.Generic;
using System.Linq;

namespace LeetCode.Naive.Problems
{
  /// <summary>
  ///    Problem: https://leetcode.com/problems/maximum-population-year/
  ///    Submission: https://leetcode.com/submissions/detail/491278237/
  /// </summary>
  internal class P1854
  {
    public class Solution
    {
      public int MaximumPopulation(int[][] logs)
      {
        var census = logs.SelectMany(x => new[] { (x[0], 1), (x[1], -1) })
          .GroupBy(x => x.Item1)
          .Select(x => (year: x.Key, diff: x.Select(c => c.Item2).Sum()))
          .ToDictionary(x => x.year, x => x.diff);

        var map = new Dictionary<int, int>();
        var population = 0;

        for (var y = 1950; y <= 2050; ++y)
        {
          if (census.ContainsKey(y))
          {
            population += census[y];
            map[y] = population;
          }
        }

        var maxPop = map.Max(c => c.Value);
        return map.First(x => x.Value == maxPop).Key;
      }
    }
  }
}
