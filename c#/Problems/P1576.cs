using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;

namespace LeetCode.Naive.Problems
{
  /// <summary>
  ///    Problem: https://leetcode.com/problems/replace-all-s-to-avoid-consecutive-repeating-characters/
  ///    Submission: https://leetcode.com/submissions/detail/393838039/
  /// </summary>
  internal class P1576
  {
    public class Solution
    {
      public string ModifyString(string s)
      {
        var sb = new StringBuilder(s);

        for (var i = 0; i < sb.Length; i++)
        {
          if (sb[i] != '?')
            continue;

          var constraints = new List<char>();
          if (i - 1 >= 0)
            constraints.Add(sb[i - 1]);

          if (i + 1 < sb.Length && sb[i + 1] != '?')
            constraints.Add(sb[i + 1]);

          for (var ch = 97; ; ch++)
          {
            if (!constraints.Any(c => (int)c == ch))
            {
              sb[i] = (char)ch;
              break;
            }
          }
        }

        return sb.ToString();
      }
    }
  }
}
