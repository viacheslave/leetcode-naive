using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode.Naive.Problems
{
  /// <summary>
  ///    Problem: https://leetcode.com/problems/longest-well-performing-interval/
  ///    Submission: https://leetcode.com/submissions/detail/247567272/
  /// </summary>
  internal class P1124
  {
    public class Solution
    {
      public int LongestWPI(int[] hours)
      {
        var a = hours.Select(_ => _ > 8 ? 1 : -1).ToArray();

        var prefixSum = new int[a.Length];
        for (int i = 0; i < a.Length; i++)
        {
          if (i == 0)
          {
            prefixSum[0] = a[0];
          }
          else
          {
            prefixSum[i] = prefixSum[i - 1] + a[i];
          }
        }

        var max = int.MinValue;

        for (int i = 0; i < prefixSum.Length; i++)
        {
          if (prefixSum[i] > 0)
          {
            max = Math.Max(max, i + 1);
            continue;
          }

          var lower = 0;
          while (lower < i)
          {
            if (prefixSum[i] - prefixSum[lower] <= 0)
              lower++;
            else break;
          }

          max = Math.Max(max, i - lower);
        }

        return max;
      }
    }
  }
}
