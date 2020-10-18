using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode.Naive.Problems
{
  /// <summary>
  ///    Problem: https://leetcode.com/problems/valid-number/
  ///    Submission: https://leetcode.com/submissions/detail/244355572/
  /// </summary>
  internal class P0065
  {
    public class Solution
    {
      public bool IsNumber(string s)
      {
        s = s.Trim();

        if (s?.Length == 0)
          return false;

        var parts = s.Split('e');
        if (parts.Length > 2)
          return false;

        if (parts.Length == 2)
          return IsNum(parts[0]) && IsExponent(parts[1]);

        return IsNum(parts[0]);
      }

      private bool IsExponent(string s)
      {
        if (s.Length == 0)
          return false;

        if (s.StartsWith("+") || s.StartsWith("-"))
          s = s.Substring(1);

        if (s.Length == 0)
          return false;

        return s.All(Char.IsDigit);
      }

      private bool IsNum(string s)
      {
        if (s.Length == 0)
          return false;

        if (s.Trim() != s)
          return false;

        return double.TryParse(s, out var _);
      }
    }
  }
}
