using System.Collections.Generic;

namespace LeetCode.Naive.Problems
{
  /// <summary>
  ///    Problem: https://leetcode.com/problems/longest-happy-prefix/
  ///    Submission: https://leetcode.com/submissions/detail/412935529/
  /// </summary>
  internal class P1392
  {
    public class Solution
    {
      public string LongestPrefix(string s)
      {
        var ans = "";

        for (var i = 1; i < s.Length; i++)
        {
          if (s[s.Length - 1 - i] != s[^1])
            continue;

          var index = 0;
          var good = true;

          while (i + index < s.Length)
          {
            if (s[index] != s[i + index])
            {
              good = false;
              break;
            }

            index++;
          }

          if (good)
            return s.Substring(0, s.Length - i);
        }

        return ans;
      }
    }
  }
}
