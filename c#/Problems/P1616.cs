using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode.Naive.Problems
{
  /// <summary>
  ///   Problem: https://leetcode.com/problems/split-two-strings-to-make-palindrome/
  ///   Submission: https://leetcode.com/submissions/detail/407359272/
  /// </summary>
  internal class P1616
  {
    public class Solution
    {
      public bool CheckPalindromeFormation(string a, string b)
      {
        return IsPalindrome(a, b) || IsPalindrome(b, a);
      }

      private bool IsPalindrome(string a, string b)
      {
        var index = -1;
        var br = b.Reverse().ToArray();

        while (index < a.Length)
        {
          if (index == a.Length)
            break;

          if (a[index + 1] == br[index + 1])
          {
            index++;
            continue;
          }

          break;
        }

        if (index == -1)
          return IsPalindrome(b);

        var candidate1 = a.Substring(0, index + 1) + b.Substring(index + 1);
        var candidate2 = a.Substring(0, a.Length - index - 1) + b.Substring(a.Length - index - 1);

        return IsPalindrome(candidate1) || IsPalindrome(candidate2);
      }

      private bool IsPalindrome(string candidate)
      {
        for (var i = 0; i < candidate.Length / 2; i++)
          if (candidate[i] != candidate[candidate.Length - 1 - i])
            return false;

        return true;
      }
    }
  }

}
