using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode.Naive.Problems
{
  /// <summary>
  ///    Problem: https://leetcode.com/problems/valid-palindrome/
  ///    Submission: https://leetcode.com/submissions/detail/228409546/
  /// </summary>
  internal class P0125
  {
    public class Solution
    {
      public bool IsPalindrome(string s)
      {
        int i = 0;
        int j = s.Length - 1;

        if (string.IsNullOrEmpty(s))
          return true;

        if (s.Length == 1)
          return true;

        while (j > i)
        {
          var leftCh = Char.Parse(s[i].ToString().ToLower());
          if (!Char.IsLetterOrDigit(leftCh))
          {
            i++;
            continue;
          }

          var rightCh = Char.Parse(s[j].ToString().ToLower());
          if (!Char.IsLetterOrDigit(rightCh))
          {
            j--;
            continue;
          }

          if (leftCh != rightCh)
            return false;

          i++;
          j--;
        }

        return true;
      }
    }
  }
}
