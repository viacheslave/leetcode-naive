using System;
using System.Linq;

namespace LeetCode.Naive.Problems
{
  /// <summary>
  ///    Problem: https://leetcode.com/problems/palindrome-partitioning-iv
  ///    Submission: https://leetcode.com/submissions/detail/450134274/
  /// </summary>
  internal class P1745
  {
    public class Solution
    {
      public bool CheckPartitioning(string s)
      {
        var rs = new string(s.Reverse().ToArray());

        var prPal = new bool[s.Length];
        var suPal = new bool[s.Length];

        // store is palindrome for prefixes and suffixes
        for (var i = 0; i < s.Length - 2; i++)
          prPal[i] = IsPalindrome(s, rs, 0, i);

        for (var i = 2; i < s.Length; i++)
          suPal[i] = IsPalindrome(s, rs, i, s.Length - 1);

        // check in-between
        for (var right = 0; right < s.Length - 2; right++)
          for (var left = right + 2; left < s.Length; left++)
            if (prPal[right] && suPal[left])
              if (IsPalindrome(s, rs, right + 1, left - 1))
                return true;

        return false;
      }

      static bool IsPalindrome(string s, string rs, int start, int end)
      {
        if (start == end)
          return true;

        var len = (end - start + 1) / 2;

        // 3,5
        return (end - start) % 2 == 0
          ? s.Substring(start + len + 1, len) == rs.Substring(s.Length - start - len, len)
          : s.Substring(start + len, len) == rs.Substring(s.Length - start - len, len);
      }
    }
  }
}
