using System;
using System.Collections.Generic;

namespace LeetCode.Naive.Problems
{
  /// <summary>
  ///    Problem: https://leetcode.com/problems/longest-nice-substring/
  ///    Submission: https://leetcode.com/submissions/detail/491391411/
  /// </summary>
  internal class P1763
  {
    public class Solution
    {
      public string LongestNiceSubstring(string s)
      {
        var ans = "";
        var length = 0;

        for (int i = 0; i < s.Length; i++)
        {
          var set = new HashSet<int>();

          for (int j = i; j < s.Length; j++)
          {
            set.Add(s[j]);

            // check set
            var valid = true;

            foreach (var ch in set)
            {
              if (ch >= 65 && ch <= 96)
              {
                if (!set.Contains(ch + 32))
                {
                  valid = false;
                  break;
                }
              }

              if (ch >= 97 && ch <= 122)
              {
                if (!set.Contains(ch - 32))
                {
                  valid = false;
                  break;
                }
              }
            }

            if (valid)
            {
              if (j - i + 1 > length)
              {
                ans = s.Substring(i, j - i + 1);
                length = j - i + 1;
              }
            }
          }
        }

        return ans;
      }
    }
  }
}
