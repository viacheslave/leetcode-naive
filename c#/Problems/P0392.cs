using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;

namespace LeetCode.Naive.Problems
{
  /// <summary>
  ///    Problem: https://leetcode.com/problems/is-subsequence/
  ///    Submission: https://leetcode.com/submissions/detail/230001458/
  /// </summary>
  internal class P0392
  {
    public class Solution
    {
      public bool IsSubsequence(string s, string t)
      {
        if (s.Length == 0)
          return true;

        var fi = 0;

        for (var i = 0; i < t.Length; i++)
        {
          if (s[fi] == t[i])
          {
            fi++;
            if (fi == s.Length)
              return true;
          }
        }

        return false;
      }
    }
  }
}
