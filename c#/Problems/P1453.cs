using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode.Naive.Problems
{
  /// <summary>
  ///    Problem: https://leetcode.com/problems/maximum-number-of-darts-inside-of-a-circular-dartboard/
  ///    Submission: https://leetcode.com/submissions/detail/419217620/
  /// </summary>
  internal class P1453
  {
    public class Solution
    {
      public int NumPoints(int[][] points, int r)
      {
        var ans = 0;

        for (var i = 0; i < points.Length; i++)
          for (var j = i + 1; j < points.Length; j++)
            ans = Math.Max(ans, ProcessPair(points[i], points[j], r, points));

        return ans;
      }

      private int ProcessPair(int[] pp1, int[] pp2, double r, int[][] points)
      {
        var p1 = (x: pp1[0], y: pp1[1]);
        var p2 = (x: pp2[0], y: pp2[1]);

        var q = Math.Sqrt(Math.Pow(p2.x - p1.x, 2) + Math.Pow(p2.y - p1.y, 2));
        if (q > r * 2)
          return 1;

        var m = (x: (p1.x + p2.x) / 2d, y: (p1.y + p2.y) / 2d);

        var r1x = m.x + Math.Sqrt(r * r - (q / 2) * (q / 2)) * (p1.y - p2.y) / q;
        var r1y = m.y + Math.Sqrt(r * r - (q / 2) * (q / 2)) * (p2.x - p1.x) / q;

        var r2x = m.x - Math.Sqrt(r * r - (q / 2) * (q / 2)) * (p1.y - p2.y) / q;
        var r2y = m.y - Math.Sqrt(r * r - (q / 2) * (q / 2)) * (p2.x - p1.x) / q;

        var r1 = (x: r1x, y: r1y);
        var r2 = (x: r2x, y: r2y);

        return Math.Max(
          GetPoints(points, r1, r),
          GetPoints(points, r2, r));
      }

      private static int GetPoints(int[][] points, (double x, double y) center, double maxDistance)
      {
        var count = 0;

        foreach (var point in points)
        {
          var p = (x: point[0], y: point[1]);

          var dist = Math.Sqrt(Math.Pow(p.x - center.x, 2) + Math.Pow(p.y - center.y, 2));

          if (maxDistance - dist >= 0)
            count++;
        }

        return count;
      }
    }
  }
}
