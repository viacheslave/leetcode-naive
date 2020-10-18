using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode.Naive.Problems
{
  /// <summary>
  ///    Problem: https://leetcode.com/problems/distance-between-bus-stops/
  ///    Submission: https://leetcode.com/submissions/detail/258961676/
  /// </summary>
  internal class P1184
  {
    public class Solution
    {
      public int DistanceBetweenBusStops(int[] distance, int start, int destination)
      {
        if (start == destination)
          return 0;

        var min = start > destination ? destination : start;
        var max = start < destination ? destination : start;

        var sum = distance.Sum();

        var d = 0;
        for (int i = min; i < max; i++)
        {
          d += distance[i];
        }

        return Math.Min(d, sum - d);
      }
    }
  }
}
