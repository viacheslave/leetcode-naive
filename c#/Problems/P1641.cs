using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode.Naive.Problems
{
  /// <summary>
  ///    Problem: https://leetcode.com/problems/count-sorted-vowel-strings/
  ///    Submission: https://leetcode.com/submissions/detail/415567252/
  /// </summary>
  internal class P1641
  {
    public class Solution
    {
      public int CountVowelStrings(int n)
      {
        var dp = new int[n + 1, 255];
        var ch = new SortedSet<int>(new int[] { 'a', 'e', 'i', 'o', 'u' });

        foreach (var t in ch)
          dp[1, t] = 1;

        for (var i = 2; i <= n; i++)
          foreach (var c in ch)
            dp[i, c] = ch.GetViewBetween('a', c).Select(x => dp[i - 1, x]).Sum();

        return ch.Select(x => dp[n, x]).Sum();
      }
    }
  }
}
