using System;

namespace LeetCode.Naive.Problems
{
  /// <summary>
  ///    Problem: https://leetcode.com/problems/find-nearest-point-that-has-the-same-x-or-y-coordinate/
  ///    Submission: https://leetcode.com/submissions/detail/491302934/
  /// </summary>
  internal class P1779
  {
    public class Solution
    {
      public int NearestValidPoint(int x, int y, int[][] points)
      {
        var ans = -1;
        var distance = int.MaxValue;

        for (var i = 0; i < points.Length; i++)
        {
          if (points[i][0] == x || points[i][1] == y)
          {
            var d = Math.Abs(points[i][0] - x) + Math.Abs(points[i][1] - y);
            if (d < distance)
            {
              ans = i;
              distance = d;
            }
          }
        }

        return ans;
      }
    }
  }
}
