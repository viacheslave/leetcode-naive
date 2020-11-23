using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode.Naive.Problems
{
  /// <summary>
  ///    Problem: https://leetcode.com/problems/number-of-ways-to-stay-in-the-same-place-after-some-steps/
  ///    Submission: https://leetcode.com/submissions/detail/423320509/
  /// </summary>
  internal class P1269
  {
    public class Solution
    {
      public int NumWays(int steps, int arrLen)
      {
        var pos = Math.Min(steps, arrLen);
        var dp = new int[steps + 1, pos];
        dp[0, 0] = 1;

        for (var i = 1; i < steps + 1; i++)
        {
          for (var j = 0; j < pos; j++)
          {
            dp[i, j] = AddMod(dp[i, j], dp[i - 1, j]);

            if (j - 1 >= 0)
              dp[i, j] = AddMod(dp[i, j], dp[i - 1, j - 1]);

            if (j + 1 < pos)
              dp[i, j] = AddMod(dp[i, j], dp[i - 1, j + 1]);
          }
        }

        return dp[steps, 0];

        static int AddMod(int value1, int value2)
        {
          value1 += value2;
          value1 %= (int)(1e9 + 7);
          return value1;
        }
      }
    }
  }
}
