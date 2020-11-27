using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode.Naive.Problems
{
  /// <summary>
  ///    Problem: https://leetcode.com/problems/minimum-ascii-delete-sum-for-two-strings/
  ///    Submission: https://leetcode.com/submissions/detail/424771493/
  /// </summary>
  internal class P0712
  {
    public class Solution
    {
      public int MinimumDeleteSum(string s1, string s2)
      {
        var ans = 0;
        var dp = new int[s1.Length + 1, s2.Length + 1];

        for (var c1 = 0; c1 <= s1.Length; c1++)
        {
          for (var c2 = 0; c2 <= s2.Length; c2++)
          {
            if (c1 == 0 && c2 == 0)
              continue;

            if (c1 == 0)
            {
              dp[c1, c2] = dp[c1, c2 - 1] + ASCII(s2[c2 - 1]);
              continue;
            }

            if (c2 == 0)
            {
              dp[c1, c2] = dp[c1 - 1, c2] + ASCII(s1[c1 - 1]);
              continue;
            }

            var c = s1[c1 - 1] == s2[c2 - 1] ? 0 : (ASCII(s1[c1 - 1]) + ASCII(s2[c2 - 1]));

            dp[c1, c2] =
              Math.Min(dp[c1 - 1, c2 - 1] + c,
                Math.Min(
                  dp[c1 - 1, c2] + ASCII(s1[c1 - 1]),
                  dp[c1, c2 - 1] + ASCII(s2[c2 - 1])));
          }
        }

        return dp[s1.Length, s2.Length];
      }

      private int ASCII(char v)
      {
        return (int)v;
      }
    }
  }
}
