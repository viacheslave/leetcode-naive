using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode.Naive.Problems
{
  /// <summary>
  ///    Problem: https://leetcode.com/problems/final-prices-with-a-special-discount-in-a-shop/
  ///    Submission: https://leetcode.com/submissions/detail/387694419/
  /// </summary>
  internal class P1475
  {
    public class Solution
    {
      public int[] FinalPrices(int[] prices)
      {
        var ans = new int[prices.Length];

        for (var i = 0; i < prices.Length; i++)
        {
          ans[i] = prices[i];

          for (var j = i + 1; j < prices.Length; j++)
          {
            if (prices[j] <= prices[i])
            {
              ans[i] = prices[i] - prices[j];
              break;
            }
          }
        }


        return ans;
      }
    }
  }
}
