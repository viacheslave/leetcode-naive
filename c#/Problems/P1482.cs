using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode.Naive.Problems
{
  /// <summary>
  ///    Problem: https://leetcode.com/problems/minimum-number-of-days-to-make-m-bouquets/
  ///    Submission: https://leetcode.com/submissions/detail/419901407/
  /// </summary>
  internal class P1482
  {
    public class Solution
    {
      public int MinDays(int[] bloomDay, int m, int k)
      {
        var minDay = 0;
        var maxDay = bloomDay.Max();

        while (true)
        {
          if (maxDay - minDay == 1)
          {
            var canMin = CanMake(bloomDay, m, k, minDay);
            if (canMin)
              return minDay;

            var canMax = CanMake(bloomDay, m, k, maxDay);
            if (canMax)
              return maxDay;

            return -1;
          }

          var mid = (maxDay + minDay) / 2;

          var canMake = CanMake(bloomDay, m, k, mid);
          if (!canMake)
            minDay = mid;
          else
            maxDay = mid;
        }
      }

      private static bool CanMake(int[] bloomDay, int m, int k, int day)
      {
        var sb = new StringBuilder(bloomDay.Length);

        for (var i = 0; i < bloomDay.Length; i++)
          sb.Append(bloomDay[i] <= day ? '1' : ' ');

        var chunks = sb.ToString()
          .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

        var count = 0;
        for (var i = 0; i < chunks.Length; i++)
        {
          var length = chunks[i].Length;
          count += length / k;
        }

        return count >= m;
      }
    }
  }
}
