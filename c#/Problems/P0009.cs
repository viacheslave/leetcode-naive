using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode.Naive.Problems
{
  /// <summary>
  ///    Problem: https://leetcode.com/problems/palindrome-number/
  ///    Submission: https://leetcode.com/submissions/detail/226367347/
  /// </summary>
  internal class P0009
  {
    public class Solution
    {
      public bool IsPalindrome(int x)
      {
        var str = x.ToString();

        for (var i = 0; i < str.Length / 2; i++)
        {
          if (str[i] != str[str.Length - 1 - i])
            return false;
        }

        return true;
      }
    }
  }
}
