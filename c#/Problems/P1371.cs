using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode.Naive.Problems
{
  /// <summary>
  ///    Problem: https://leetcode.com/problems/find-the-longest-substring-containing-vowels-in-even-counts/
  ///    Submission: https://leetcode.com/submissions/detail/311593940/
  /// </summary>
  internal class P1371
  {
    public class Solution
    {
      public int FindTheLongestSubstring(string s)
      {
        var lp = new int[s.Length + 1];
        var rp = new int[s.Length + 1];

        //aeiou
        for (var i = 0; i <= s.Length; i++)
        {
          if (i == 0)
          {
            lp[i] = 0;
            rp[i] = 0;
            continue;
          }

          var ch = s[i - 1];
          var chmask = GetCh(ch);
          lp[i] = lp[i - 1] ^ chmask;

          ch = s[s.Length - i];
          chmask = GetCh(ch);
          rp[i] = rp[i - 1] ^ chmask;
        }

        var all = 0;
        for (int i = 0; i < s.Length; i++)
          all ^= GetCh(s[i]);

        var max = 0;
        for (var start = 0; start <= s.Length; start++)
        {
          for (var end = 0; end <= s.Length - start; end++)
          {
            if (s.Length - end - start < max)
              break;

            var ans = all ^ lp[start] ^ rp[end];
            if (ans == 0)
            {
              max = Math.Max(max, s.Length - end - start);
              break;
            }
          }
        }

        return max;
      }

      public int GetCh(char ch)
      {
        switch (ch)
        {
          case 'a': return 16;
          case 'e': return 8;
          case 'i': return 4;
          case 'o': return 2;
          case 'u': return 1;
          default: return 0;
        }
      }
    }
  }
}
