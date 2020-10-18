using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode.Naive.Problems
{
  /// <summary>
  ///    Problem: https://leetcode.com/problems/maximum-score-after-splitting-a-string/
  ///    Submission: https://leetcode.com/submissions/detail/332736612/
  /// </summary>
  internal class P1422
  {
    public class Solution
    {
      public int MaxScore(string s)
      {
        if (s.Length <= 1)
          return 0;

        var zeros = 0;
        var ones = s.Count(ch => ch == '1');

        var ans = 0;

        for (var index = 0; index < s.Length - 1; index++)
        {
          if (s[index] == '0')
            zeros++;

          if (s[index] == '1')
            ones--;

          ans = Math.Max(ans, zeros + ones);
        }

        return ans;
      }
    }
  }
}
