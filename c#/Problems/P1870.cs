using System;
using System.Collections.Generic;
using System.Linq;

namespace LeetCode.Naive.Problems
{
  /// <summary>
  ///    Problem: https://leetcode.com/problems/minimum-speed-to-arrive-on-time/
  ///    Submission: https://leetcode.com/submissions/detail/497199179/
  /// </summary>
  internal class P1870
  {
    public class Solution
    {
      public int MinSpeedOnTime(int[] dist, double hour)
      {
        const int cutoff = (int)10e7;
        return BinarySearch(dist, hour, 1, cutoff);
      }

      private int BinarySearch(int[] dist, double hour, int left, int right)
      {
        while (true)
        {
          if (right - left <= 1)
          {
            var l = Calc(dist, left);
            var r = Calc(dist, right);

            if (l >= hour && r >= hour)
              return -1;

            return l <= hour ? left : right;
          }

          var mid = (left + right) / 2;

          var hr = Calc(dist, mid);
          if (hr >= hour)
            left = mid;
          else
            right = mid;
        }
      }

      private double Calc(int[] dist, int speed)
      {
        var ans = 0d;

        for (var i = 0; i < dist.Length; i++)
        {
          if (i == dist.Length - 1)
          {
            ans += 1.0 * dist[i] / speed;
            continue;
          }

          var rem = dist[i] % speed;
          if (rem == 0)
            ans += dist[i] / speed;
          else
            ans += (dist[i] / speed) + 1;
        }

        return ans;
      }
    }
  }
}
