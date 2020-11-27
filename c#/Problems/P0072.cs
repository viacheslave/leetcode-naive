using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode.Naive.Problems
{
  /// <summary>
  ///    Problem: https://leetcode.com/problems/edit-distance/
  ///    Submission: https://leetcode.com/submissions/detail/424760716/
  /// </summary>
  internal class P0072
  {
    public class Solution
    {
      public int MinDistance(string word1, string word2)
      {
        var ans = 0;
        var dp = new int[word1.Length + 1, word2.Length + 1];

        for (var s1 = 0; s1 <= word1.Length; s1++)
        {
          for (var s2 = 0; s2 <= word2.Length; s2++)
          {
            if (s1 == 0 && s2 == 0)
              continue;

            if (s1 == 0)
            {
              dp[s1, s2] = s2;
              continue;
            }

            if (s2 == 0)
            {
              dp[s1, s2] = s1;
              continue;
            }

            var c = word1[s1 - 1] == word2[s2 - 1] ? 0 : 1;

            dp[s1, s2] =
              Math.Min(dp[s1 - 1, s2 - 1] + c,
                Math.Min(dp[s1 - 1, s2] + 1, dp[s1, s2 - 1] + 1));
          }
        }

        return dp[word1.Length, word2.Length];
      }
    }
  }
}
