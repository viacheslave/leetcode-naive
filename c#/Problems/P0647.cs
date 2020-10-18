using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;

namespace LeetCode.Naive.Problems
{
  /// <summary>
  ///    Problem: https://leetcode.com/problems/palindromic-substrings/
  ///    Submission: https://leetcode.com/submissions/detail/237796818/
  /// </summary>
  internal class P0647
  {
    public class Solution
    {
      public int CountSubstrings(string s)
      {
        if (string.IsNullOrEmpty(s))
          return 0;

        if (s.Length == 1)
          return 1;

        var sub = 0;

        for (var i = 0; i < s.Length; i++)
        {
          sub++;

          var left = i;
          var right = i + 1;

          while (left >= 0 && right < s.Length && s[left] == s[right])
          {
            sub++;

            left--;
            right++;
          }

          left = i;
          right = i + 2;

          while (left >= 0 && right < s.Length && s[left] == s[right])
          {
            sub++;

            left--;
            right++;
          }
        }

        return sub;
      }
    }
  }
}
