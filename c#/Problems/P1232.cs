using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode.Naive.Problems
{
  /// <summary>
  ///    Problem: https://leetcode.com/problems/check-if-it-is-a-straight-line/
  ///    Submission: https://leetcode.com/submissions/detail/278494008/
  /// </summary>
  internal class P1232
  {
    public class Solution
    {
      public bool CheckStraightLine(int[][] coordinates)
      {
        var points = coordinates.Select(p => (x: p[0], y: p[1])).ToList();

        if (points.Select(p => p.x).Distinct().Count() == 1)
          return true;

        if (points.Select(p => p.y).Distinct().Count() == 1)
          return true;

        var coff = new List<decimal>();

        for (int i = 1; i < points.Count; i++)
        {
          if (points[i].x - points[i - 1].x == 0)
            return false;

          coff.Add((points[i].y - points[i - 1].y) * 1m / (points[i].x - points[i - 1].x));
        }

        return coff.Distinct().Count() == 1;
      }
    }
  }
}
