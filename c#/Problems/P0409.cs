using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;

namespace LeetCode.Naive.Problems
{
  /// <summary>
  ///    Problem: https://leetcode.com/problems/longest-palindrome/
  ///    Submission: https://leetcode.com/submissions/detail/232258966/
  /// </summary>
  internal class P0409
  {
    public class Solution
    {
      public int LongestPalindrome(string s)
      {
        var di = new Dictionary<char, int>();

        foreach (var ch in s)
        {
          if (!di.ContainsKey(ch))
            di[ch] = 0;
          di[ch]++;
        }

        var count = di.Select(_ => _.Value / 2).Sum() * 2;
        var central = di.Any(_ => _.Value % 2 == 1);

        if (central)
          count++;

        return count;
      }
    }
  }
}
