using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;

namespace LeetCode.Naive.Problems
{
  /// <summary>
  ///    Problem: https://leetcode.com/problems/largest-triangle-area/
  ///    Submission: https://leetcode.com/submissions/detail/231065556/
  /// </summary>
  internal class P0812
  {
    public class Solution
    {
      public double LargestTriangleArea(int[][] points)
      {
        var max = 0d;

        for (var i = 0; i < points.Length - 2; i++)
        {
          for (var j = i + 1; j < points.Length - 1; j++)
          {
            for (var k = j + 1; k < points.Length; k++)
            {
              var area = GetArea(points[i], points[j], points[k]);
              if (area > max)
                max = area;
            }
          }
        }

        return max;
      }

      double GetArea(int[] a, int[] b, int[] c)
      {
        var area = 1.0 * (a[0] * (b[1] - c[1]) + b[0] * (c[1] - a[1]) + c[0] * (a[1] - b[1])) / 2;
        return Math.Abs(area);
      }
    }
  }
}
