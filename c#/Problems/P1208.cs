using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode.Naive.Problems
{
  /// <summary>
  ///    Problem: https://leetcode.com/problems/get-equal-substrings-within-budget/
  ///    Submission: https://leetcode.com/submissions/detail/422346481/
  /// </summary>
  internal class P1208
  {
    public class Solution
    {
      public int EqualSubstring(string s, string t, int maxCost)
      {
        var ans = 0;

        var left = -1;
        var right = -1;
        var length = s.Length;

        var cost = s.Select((c, i) => Math.Abs(s[i] - t[i])).ToArray();
        var current = 0;

        // sliding window approach

        while (left <= right && right < length)
        {
          left++;
          if (left == length)
            break;

          if (right < left)
          {
            right = left;
            current = cost[left];
          }
          else
          {
            current -= cost[left - 1];
          }

          if (current > maxCost)
          {
            continue;
          }

          ans = Math.Max(ans, right - left + 1);

          while (right + 1 < length && current + cost[right + 1] <= maxCost)
          {
            right++;
            current += cost[right];
            ans = Math.Max(ans, right - left + 1);
          }
        }

        return ans;
      }
    }
  }
}
