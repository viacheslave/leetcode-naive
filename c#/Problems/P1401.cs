using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode.Naive.Problems
{
  /// <summary>
  ///    Problem: https://leetcode.com/problems/circle-and-rectangle-overlapping/
  ///    Submission: https://leetcode.com/submissions/detail/410707006/
  /// </summary>
  internal class P1401
  {
    public class Solution
    {
      public bool CheckOverlap(int radius, int x_center, int y_center, int x1, int y1, int x2, int y2)
      {
        // circle center is inside
        if (x_center >= x1 && x_center <= x2 && y_center >= y1 && y_center <= y2)
          return true;

        // vertically aligned
        if (x_center >= x1 && x_center <= x2)
        {
          var f1 = Math.Abs(y_center - y1) - radius;
          var f2 = Math.Abs(y_center - y2) - radius;

          if (f1 <= 0 || f2 <= 0)
            return true;
        }

        // horizontally aligned
        if (y_center >= y1 && y_center <= y2)
        {
          var f1 = Math.Abs(x_center - x1) - radius;
          var f2 = Math.Abs(x_center - x2) - radius;

          if (f1 <= 0 || f2 <= 0)
            return true;
        }

        var d1 = GetDistance((x_center, y_center), (x1, y1));
        var d2 = GetDistance((x_center, y_center), (x2, y2));
        var d3 = GetDistance((x_center, y_center), (x2, y1));
        var d4 = GetDistance((x_center, y_center), (x1, y2));

        if (d1 <= radius || d2 <= radius || d3 <= radius || d4 <= radius)
          return true;

        return false;
      }

      private double GetDistance((int x, int y) p1, (int x, int y) p2)
      {
        return Math.Sqrt(Math.Pow(p2.x - p1.x, 2) + Math.Pow(p2.y - p1.y, 2));
      }
    }
  }
}
