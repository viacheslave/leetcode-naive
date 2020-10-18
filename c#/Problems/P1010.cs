using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;

namespace LeetCode.Naive.Problems
{
  /// <summary>
  ///    Problem: https://leetcode.com/problems/pairs-of-songs-with-total-durations-divisible-by-60/
  ///    Submission: https://leetcode.com/submissions/detail/231262568/
  /// </summary>
  internal class P1010
  {
    public class Solution
    {
      public int NumPairsDivisibleBy60(int[] time)
      {
        var d = new Dictionary<int, int>();

        for (var i = 0; i < time.Length; i++)
        {
          if (!d.ContainsKey(time[i] % 60))
            d[time[i] % 60] = 0;
          d[time[i] % 60]++;
        }


        var count = 0;
        if (d.ContainsKey(0))
          count += (d[0] * (d[0] - 1)) / 2;
        if (d.ContainsKey(30))
          count += ((d[30]) * ((d[30]) - 1)) / 2;

        for (var i = 1; i <= 29; i++)
        {
          var f1 = 0;
          var f2 = 0;
          if (d.ContainsKey(i))
            f1 = d[i];
          if (d.ContainsKey(60 - i))
            f2 = d[60 - i];

          count += f1 * f2;
        }

        return count;
      }
    }
  }
}
