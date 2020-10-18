using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode.Naive.Problems
{
  /// <summary>
  ///    Problem: https://leetcode.com/problems/best-time-to-buy-and-sell-stock-with-cooldown/
  ///    Submission: https://leetcode.com/submissions/detail/410186999/
  /// </summary>
  internal class P0309
  {
    public class Solution
    {
      public int MaxProfit(int[] prices)
      {
        int n = prices.Length;

        if (n == 0)
          return 0;

        var mxk = (int)1e3;

        int[,,] dp = new int[n, mxk + 1, 2];

        for (int i = 0; i < n; i++)
        {
          for (int j = 0; j <= mxk; j++)
          {
            dp[i, j, 0] = (int)-1e5;
            dp[i, j, 1] = (int)-1e5;
          }
        }

        dp[0, 0, 0] = 0;
        dp[0, 1, 1] = -prices[0];

        for (int i = 1; i < n; i++)
        {
          for (int j = 0; j <= mxk; j++)
          {
            // do not buy or sell prev
            dp[i, j, 0] = Math.Max(dp[i - 1, j, 0], dp[i - 1, j, 1] + prices[i]);

            if (j > 0)
            {
              // cooldown
              var prev = i - 2 < 0
                ? -prices[i]
                : dp[i - 2, j - 1, 0] - prices[i];

              // do not sell or buy
              dp[i, j, 1] = Math.Max(dp[i - 1, j, 1], prev);
            }
          }
        }

        int res = 0;
        for (int j = 0; j <= mxk; j++)
          res = Math.Max(res, dp[n - 1, j, 0]);

        return res;
      }
    }
  }
}
