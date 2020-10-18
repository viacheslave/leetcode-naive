using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode.Naive.Problems
{
  /// <summary>
  ///    Problem: https://leetcode.com/problems/remove-duplicate-letters/
  ///    Submission: https://leetcode.com/problems/remove-duplicate-letters/submissions/
  /// </summary>
  internal class P0316
  {
    public class Solution
    {
      public string RemoveDuplicateLetters(string s)
      {
        var chMap = s.GroupBy(c => c)
            .ToDictionary(c => c.Key, c => c.Count());

        var processed = s.Distinct()
            .ToDictionary(c => c, _ => false);

        var sb = new StringBuilder();

        for (var i = 0; i < s.Length; i++)
        {
          var ch = s[i];

          chMap[ch]--;

          if (processed[ch])
            continue;

          while (sb.Length > 0)
          {
            var last = sb[^1];

            if (last > ch && chMap[last] > 0)
            {
              processed[last] = false;
              sb.Remove(sb.Length - 1, 1);

              continue;
            }

            break;
          }

          processed[ch] = true;
          sb.Append(ch);
        }

        return sb.ToString();
      }
    }
  }
}
