using System;
using System.Collections.Generic;

namespace LeetCode.Naive.Problems
{
  /// <summary>
  ///    Problem: https://leetcode.com/problems/count-number-of-homogenous-substrings/
  ///    Submission: https://leetcode.com/submissions/detail/492241635/
  /// </summary>
  internal class P1759
  {
    public class Solution
    {
      public int CountHomogenous(string s)
      {
        if (s.Length == 1)
          return 1;

        // get intervals
        var parts = new List<long>();
        var c = 0;

        for (var i = 1; i < s.Length; i++)
        {
          if (s[i] != s[i - 1])
          {
            parts.Add(i - c);
            c = i;
          }
        }

        parts.Add(s.Length - c);

        var ans = 0L;

        foreach (var part in parts)
        {
          ans += part * (part + 1) / 2;
        }

        return (int)(ans % 1_000_000_007);
      }
    }
  }
}
