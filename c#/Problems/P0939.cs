using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;

namespace LeetCode.Naive.Problems
{
  /// <summary>
  ///    Problem: https://leetcode.com/problems/minimum-area-rectangle/
  ///    Submission: https://leetcode.com/submissions/detail/239987937/
  /// </summary>
  internal class P0939
  {
    public class Solution
    {
      public int MinAreaRect(int[][] points)
      {
        var set = new HashSet<(int, int)>(points.Select(p => (p[0], p[1])));
        var minArea = int.MaxValue;

        for (int i = 0; i < points.Length; i++)
        {
          var basis = (points[i][0], points[i][1]);

          for (int j = i + 1; j < points.Length; j++)
          {
            var other = (points[j][0], points[j][1]);
            if (basis.Item1 == other.Item1 || basis.Item2 == other.Item2)
              continue;

            if (set.Contains((basis.Item1, other.Item2)) && set.Contains((other.Item1, basis.Item2)))
              minArea = Math.Min(minArea, Math.Abs(other.Item2 - basis.Item2) * Math.Abs(other.Item1 - basis.Item1));
          }
        }

        return minArea == int.MaxValue ? 0 : minArea;
      }
    }
  }
}
