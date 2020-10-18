using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode.Naive.Problems
{
  /// <summary>
	///		Problem: https://leetcode.com/problems/best-time-to-buy-and-sell-stock-iv/
	///		Submission: https://leetcode.com/submissions/detail/410170643/
	/// </summary>
	internal class P0188
  {
    public int MaxProfit(int k, int[] prices)
    {
      if (prices.Length == 0)
        return 0;

      if (2 * k > prices.Length)
      {
        int res = 0;
        for (int i = 1; i < prices.Length; i++)
          res += Math.Max(0, prices[i] - prices[i - 1]);

        return res;
      }

      int[,] dp = new int[k + 1, prices.Length + 1];

      for (int transIndex = 0; transIndex < k; transIndex++)
        dp[transIndex, 0] = 0;

      for (int day = 0; day < prices.Length; day++)
        dp[0, day] = 0;

      for (var transIndex = 1; transIndex <= k; transIndex++)
      {
        for (int day = 1; day < prices.Length; day++)
        {
          var maxProfit = 0;

          for (int prevDay = 0; prevDay < day; prevDay++)
            maxProfit = Math.Max(maxProfit, prices[day] - prices[prevDay] + dp[transIndex - 1, prevDay]);

          dp[transIndex, day] = Math.Max(maxProfit, dp[transIndex, day - 1]);
        }
      }

      return dp[k, prices.Length - 1];
    }
  }
}
