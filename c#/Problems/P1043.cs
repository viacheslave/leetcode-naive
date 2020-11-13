using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode.Naive.Problems
{
  /// <summary>
  ///    Problem: https://leetcode.com/problems/partition-array-for-maximum-sum/
  ///    Submission: https://leetcode.com/submissions/detail/419988648/
  /// </summary>
  internal class P1043
  {
    public class Solution
    {
      public int MaxSumAfterPartitioning(int[] A, int K)
      {
        var dp = new int[A.Length + 1];

        for (var i = 1; i <= A.Length; i++)
        {
          var value = int.MinValue;

          for (var j = 1; j <= K; j++)
          {
            if (i - j < 0)
              continue;

            var max = int.MinValue;
            for (var k = 1; k <= j; k++)
              if (i - k >= 0)
                max = Math.Max(max, A[i - k]);

            value = Math.Max(value, dp[i - j] + max * j);
          }

          dp[i] = value;
        }

        return dp[A.Length];
      }
    }
  }
}
