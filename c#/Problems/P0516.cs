using System;
using System.Linq;

namespace LeetCode.Naive.Problems
{
  /// <summary>
  ///    Problem: https://leetcode.com/problems/longest-palindromic-subsequence/
  ///    Submission: https://leetcode.com/submissions/detail/435981123/
  /// </summary>
  internal class P0516
  {
    public class Solution
    {
      public int LongestPalindromeSubseq(string s)
      {
        if (s.Length == 1)
          return 1;

        var dp = new int[s.Length, s.Length];

        // answer for a single ch is 1
        for (var i = 0; i < s.Length - 1; i++)
          dp[i, i] = 1;

        for (var l = 1; l < s.Length; l++)
        {
          for (var i = 0; i < s.Length - l; i++)
          {
            var from = i;
            var to = from + l;

            // for length of two: 
            // if ch are equal: 2
            // otherwise: 1
            if (to - from == 1)
              dp[from, to] = s[from] == s[to] ? 2 : 1;

            // for length greater than 2:
            // if begin = end - take inside [from + 1, to + 1] + 2
            // otherwise take max of [from + 1, to], [from, to + 1]
            else
              dp[from, to] = s[from] == s[to]
                ? dp[from + 1, to - 1] + 2
                : Math.Max(dp[from + 1, to], dp[from, to - 1]);
          }
        }

        return dp[0, s.Length - 1];
      }
    }
  }
}
