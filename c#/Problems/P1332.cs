using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode.Naive.Problems
{
  /// <summary>
  ///    Problem: https://leetcode.com/problems/remove-palindromic-subsequences/
  ///    Submission: https://leetcode.com/submissions/detail/297532395/
  /// </summary>
  internal class P1332
  {
    public class Solution
    {
      public int RemovePalindromeSub(string s)
      {
        if (string.IsNullOrEmpty(s))
          return 0;

        if (s.Length == 1) return 1;
        if (IsPalindromic(s)) return 1;
        return 2;
      }

      private bool IsPalindromic(string s)
      {
        for (var i = 0; i < s.Length / 2; i++)
          if (s[i] != s[s.Length - 1 - i])
            return false;
        return true;
      }
    }
  }

}
