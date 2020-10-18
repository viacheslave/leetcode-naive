using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;

namespace LeetCode.Naive.Problems
{
  /// <summary>
  ///    Problem: https://leetcode.com/problems/number-of-substrings-with-only-1s/
  ///    Submission: https://leetcode.com/submissions/detail/384737879/
  /// </summary>
  internal class P1513
  {
    public class Solution
    {
      public int NumSub(string s)
      {
        if (s.Length == 1)
          return s[0] == '1' ? 1 : 0;

        var segments = new List<int>();
        var start = -1;

        for (int i = 0; i < s.Length - 1; i++)
        {
          if (i == 0 && s[i] == '1')
          {
            start = i;
          }

          if (s[i] == '0' && s[i + 1] == '1')
          {
            start = i + 1;
          }

          if (s[i] == '1' && s[i + 1] == '0')
          {
            segments.Add(i - start + 1);
            start = -1;
          }

          if (i == s.Length - 2 && s[i + 1] == '1')
          {
            segments.Add(i + 1 - start + 1);
          }
        }

        if (segments.Count == 0)
          return 0;

        var ans = 0;
        var mod = 1_000_000_007;

        foreach (var segment in segments)
        {
          var mult = BigInteger.Multiply(new BigInteger(segment), new BigInteger(segment + 1));
          var div = BigInteger.Divide(mult, 2);
          var devmod = BigInteger.Remainder(div, mod);

          ans += (int)devmod;
        }

        return ans;
      }
    }
  }
}
