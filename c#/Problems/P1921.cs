using System;
using System.Collections.Generic;
using System.Linq;

namespace LeetCode.Naive.Problems
{
  /// <summary>
  ///    Problem: https://leetcode.com/problems/eliminate-maximum-number-of-monsters/
  ///    Submission: https://leetcode.com/submissions/detail/519328071/
  /// </summary>
  internal class P1921
  {
    public class Solution
    {
      public int EliminateMaximum(int[] dist, int[] speed)
      {
        var arrivals =
          Enumerable.Range(0, dist.Length)
            .Select(i => 1f * dist[i] / speed[i])
            .OrderBy(_ => _)
            .ToArray();

        var ans = 0;

        for (var i = 0; i < dist.Length; i++)
          if (arrivals[i] > i)
            ans++;
          else break;

        return ans == 0 ? 1 : ans;
      }
    }
  }
}
