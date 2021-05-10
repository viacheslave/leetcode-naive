using System;
using System.Collections.Generic;

namespace LeetCode.Naive.Problems
{
  /// <summary>
  ///    Problem: https://leetcode.com/problems/minimum-changes-to-make-alternating-binary-string/
  ///    Submission: https://leetcode.com/submissions/detail/491384202/
  /// </summary>
  internal class P1758
  {
    public class Solution
    {
      public int MinOperations(string s)
      {
        var ones = 0;
        var zeroes = 0;

        for (var i = 0; i < s.Length; i++)
        {
          var expected = i % 2 == 0 ? '1' : '0';
          if (s[i] != expected)
            ones++;
        }

        for (var i = 0; i < s.Length; i++)
        {
          var expected = i % 2 == 0 ? '0' : '1';
          if (s[i] != expected)
            zeroes++;
        }

        return Math.Min(ones, zeroes);
      }
    }
  }
}
