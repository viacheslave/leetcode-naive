using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode.Naive.Problems
{
  /// <summary>
  ///    Problem: https://leetcode.com/problems/decrypt-string-from-alphabet-to-integer-mapping/
  ///    Submission: https://leetcode.com/submissions/detail/291351743/
  /// </summary>
  internal class P1309
  {
    public class Solution
    {
      public string FreqAlphabets(string s)
      {
        var sb = new StringBuilder(s);

        for (int i = s.Length - 1; i >= 0; i--)
        {
          if (sb[i] == '#')
          {
            sb[i] = (char)(int.Parse(s.Substring(i - 2, 2)) + 96);
            sb.Remove(i - 2, 2);
            i -= 2;
          }
        }

        for (int i = 0; i < sb.Length; i++)
        {
          if (char.IsDigit(sb[i]))
            sb[i] = (char)(int.Parse(sb[i].ToString()) + 96);
        }

        return sb.ToString();
      }
    }
  }
}
