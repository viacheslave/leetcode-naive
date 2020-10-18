using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;

namespace LeetCode.Naive.Problems
{
  /// <summary>
  ///    Problem: https://leetcode.com/problems/valid-palindrome-ii/
  ///    Submission: https://leetcode.com/submissions/detail/228423526/
  /// </summary>
  internal class P0680
  {
    public class Solution
    {
      public bool ValidPalindrome(string s)
      {

        if (string.IsNullOrEmpty(s))
          return true;

        if (s.Length == 1)
          return true;

        return Check(s, true) || Check(s, false);
      }

      private bool Check(string s, bool left)
      {
        int i = 0;
        int j = s.Length - 1;

        bool removed = false;

        while (j > i)
        {
          var leftCh = s[i];
          var rightCh = s[j];

          if (leftCh != rightCh)
          {
            if (removed)
              return false;
            else
            {
              if (leftCh == s[j - 1] && left)
              {
                j--;
                removed = true;
              }
              else if (rightCh == s[i + 1] && !left)
              {
                i++;
                removed = true;
              }
              else
                return false;
            }
          }

          i++;
          j--;
        }

        return true;
      }
    }
  }
}
