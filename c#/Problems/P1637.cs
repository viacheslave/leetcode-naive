using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode.Naive.Problems
{
  /// <summary>
  ///    Problem: https://leetcode.com/problems/widest-vertical-area-between-two-points-containing-no-points/
  ///    Submission: https://leetcode.com/submissions/detail/415569789/
  /// </summary>
  internal class P1637
  {
    public class Solution
    {
      public int MaxWidthOfVerticalArea(int[][] points)
      {
        var ps = points.Select(x => x[0]).Distinct().OrderBy(c => c).ToList();

        if (ps.Count == 1)
          return 0;

        var max = int.MinValue;

        for (var i = 1; i < ps.Count; i++)
          max = Math.Max(max, ps[i] - ps[i - 1]);

        return max;
      }
    }
  }
}
