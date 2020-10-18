using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode.Naive.Problems
{
  /// <summary>
  ///    Problem: https://leetcode.com/problems/restore-the-array/
  ///    Submission: https://leetcode.com/submissions/detail/327177447/
  /// </summary>
  internal class P1416
  {
    public class Solution
    {
      public int NumberOfArrays(string s, int k)
      {
        var dp = new int[s.Length];

        for (var index = 0; index < s.Length; index++)
        {
          for (var digits = 1; digits <= k.ToString().Length; digits++)
          {
            var start = index - digits + 1;
            if (start < 0)
            {
              break;
            }

            var substr = s.Substring(start, digits);
            if (substr.StartsWith('0'))
              continue;

            if (!int.TryParse(substr, out var n) || n > k)
              break;

            if (start == 0)
              dp[index] += 1;
            else
              dp[index] += dp[start - 1];

            dp[index] = dp[index] % 1_000_000_007;
          }
        }

        return dp[s.Length - 1];
      }
    }
  }
}
