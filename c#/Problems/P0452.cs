using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode.Naive.Problems
{
  /// <summary>
  ///    Problem: https://leetcode.com/problems/minimum-number-of-arrows-to-burst-balloons/
  ///    Submission: https://leetcode.com/submissions/detail/406930851/
  /// </summary>
  internal class P0452
  {
    public class Solution
    {
      public int FindMinArrowShots(int[][] points)
      {
        if (points.Length == 0)
          return 0;

        var ps = points.OrderBy(x => x[1])
            .Select(x => (start: x[0], end: x[1]))
            .ToList();

        var ans = 1;

        var pointer = ps[0].end;

        for (var i = 0; i < ps.Count; i++)
        {
          var point = ps[i];
          if (point.start <= pointer)
            continue;

          ans++;
          pointer = point.end;
        }

        return ans;
      }
    }
  }
}
