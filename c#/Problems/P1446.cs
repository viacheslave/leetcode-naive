using System;

namespace LeetCode.Naive.Problems
{
  /// <summary>
  ///    Problem: https://leetcode.com/problems/consecutive-characters/
  ///    Submission: https://leetcode.com/submissions/detail/387153096/
  /// </summary>
  internal class P1446
  {
    public class Solution
    {
      public int MaxPower(string s)
      {
        if (s.Length == 0)
          return 0;

        if (s.Length == 1)
          return 1;

        var current = 1;
        var ans = current;

        for (var i = 1; i < s.Length; i++)
        {
          if (s[i] == s[i - 1])
          {
            current++;
          }
          else
          {
            ans = Math.Max(ans, current);
            current = 1;
          }
        }

        ans = Math.Max(ans, current);
        return ans;
      }
    }
  }
}
