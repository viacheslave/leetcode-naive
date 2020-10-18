using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode.Naive.Problems
{
  /// <summary>
  ///    Problem: https://leetcode.com/problems/best-time-to-buy-and-sell-stock/
  ///    Submission: https://leetcode.com/submissions/detail/233878832/
  /// </summary>
  internal class P0121
  {
    public class Solution
    {
      public int MaxProfit(int[] prices)
      {
        var minDay = 0;
        var maxDay = 0;
        var minCandidate = -1;

        for (var i = 1; i < prices.Length; i++)
        {
          if (maxDay == 0 && prices[i] < prices[minDay])
          {
            minDay = i;
            continue;
          }

          // normal
          if (maxDay > minDay)
          {
            if (minCandidate != -1)
            {
              if (prices[i] - prices[minCandidate] > prices[maxDay] - prices[minDay])
              {
                minDay = minCandidate;
                maxDay = i;
                minCandidate = -1;
                continue;
              }

              if (prices[i] < prices[minCandidate])
              {
                minCandidate = i;
                continue;
              }
            }

            if (prices[i] > prices[maxDay])
            {
              maxDay = i;
            }
            else if (prices[i] < prices[minDay] && minCandidate == -1)
            {
              minCandidate = i;
            }
          }
          else
          {
            if (prices[i] > prices[minDay])
            {
              maxDay = i;
            }
          }
        }

        return (maxDay > minDay) ? (prices[maxDay] - prices[minDay]) : 0;
      }
    }
  }
}
