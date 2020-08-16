package com.naive.leetcode;

/*
 * Problem: https://leetcode.com/problems/best-time-to-buy-and-sell-stock-iii/
 * Submission: https://leetcode.com/submissions/detail/381649264/
 */
public class P0123 {
    class Solution {
        public int maxProfit(int[] prices) {
            if (prices.length == 0)
                return 0;

            int[][] dp = new int[3][prices.length + 1];

            for (int transIndex = 0; transIndex < 2; transIndex++)
            {
                dp[transIndex][0] = 0;
            }

            for (int day = 0; day < prices.length; day++)
            {
                dp[0][day] = 0;
            }

            for (var transIndex = 1; transIndex <= 2; transIndex++)
            {
                for (int day = 1; day < prices.length; day++)
                {
                    var maxProfit = 0;

                    for (int prevDay = 0; prevDay < day; prevDay++)
                    {
                        maxProfit = Math.max(maxProfit, prices[day] - prices[prevDay] + dp[transIndex - 1][prevDay]);
                    }

                    dp[transIndex][day] = Math.max(maxProfit, dp[transIndex][day - 1]);
                }
            }

            return dp[2][prices.length - 1];
        }
    }
}