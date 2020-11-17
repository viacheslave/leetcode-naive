using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode.Naive.Problems
{
  /// <summary>
  ///    Problem: https://leetcode.com/problems/student-attendance-record-ii/
  ///    Submission: https://leetcode.com/submissions/detail/421299245/
  /// </summary>
  internal class P0552
  {
    public class Solution
    {
      public int CheckRecord(int n)
      {
        var dp = new int[n][,];

        dp[0] = new int[3, 4];
        dp[0][0, 1] = 1;
        dp[0][1, 0] = 1;
        dp[0][2, 0] = 1;

        var mod = (int)1e9 + 7;

        // 'A' = 0
        // 'L' = 1
        // 'P' = 2

        // 00 (0) - clean
        // 01 (1) - absent
        // 10 (2) - two late in a row
        // 11 (3) - absent + two lates in a row

        for (var i = 1; i < n; i++)
        {
          var container = new int[3, 4];

          for (var k = 0; k <= 2; k++)
          {
            for (var l = 0; l <= 3; l++)
            {
              if (dp[i - 1][k, l] == 0)
                continue;

              for (var ch = 0; ch <= 2; ch++)
              {
                if (ch == 2) // P
                {
                  container[ch, l & 1] += dp[i - 1][k, l];
                  container[ch, l & 1] %= mod;
                  continue;
                }

                if (ch == 1) // L
                {
                  if (l / 2 == 1)
                    continue;

                  if (k == 1) // L
                  {
                    container[ch, l | 2] += dp[i - 1][k, l];
                    container[ch, l | 2] %= mod;
                  }
                  else
                  {
                    container[ch, l] += dp[i - 1][k, l];
                    container[ch, l] %= mod;
                  }
                }

                if (ch == 0) // A
                {
                  if (l % 2 == 1) // already absent
                    continue;

                  container[ch, (l & 1) | 1] += dp[i - 1][k, l];
                  container[ch, (l & 1) | 1] %= mod;
                }
              }
            }
          }

          dp[i] = container;
        }

        var ans = 0;

        foreach (int entry in dp[n - 1])
        {
          ans += entry;
          ans %= mod;
        }

        return ans;
      }
    }
  }
}
