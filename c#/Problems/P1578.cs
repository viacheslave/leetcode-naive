using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;

namespace LeetCode.Naive.Problems
{
  /// <summary>
  ///    Problem: https://leetcode.com/problems/minimum-deletion-cost-to-avoid-repeating-letters/
  ///    Submission: https://leetcode.com/submissions/detail/393848743/
  /// </summary>
  internal class P1578
  {
    public class Solution
    {
      public int MinCost(string s, int[] cost)
      {
        var start = -1;

        var pairs = new List<(int, int)>();

        for (var i = 0; i < s.Length - 1; i++)
        {
          if (s[i] == s[i + 1])
          {
            if (start == -1)
              start = i;
          }
          else
          {
            if (start == -1)
              continue;
            else
            {
              pairs.Add((start, i));
              start = -1;
            }
          }
        }

        if (start != -1)
          pairs.Add((start, s.Length - 1));

        var ans = 0;

        foreach (var pair in pairs)
        {
          var items = Enumerable.Range(pair.Item1, pair.Item2 - pair.Item1 + 1)
              .Select(c => cost[c])
              .ToList();

          ans += items.Sum() - items.Max();
        }

        return ans;
      }
    }
  }
}
