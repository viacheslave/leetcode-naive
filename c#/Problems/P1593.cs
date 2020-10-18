using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode.Naive.Problems
{
  /// <summary>
  ///    Problem: https://leetcode.com/problems/split-a-string-into-the-max-number-of-unique-substrings/
  ///    Submission: https://leetcode.com/submissions/detail/400072671/
  /// </summary>
  internal class P1593
  {
    public class Solution
    {
      private int _ans = int.MinValue;

      public int MaxUniqueSplit(string s)
      {
        var set = new HashSet<string>();

        Try(s, set, 0, s.Length - 1);

        return _ans;
      }

      private void Try(string s, HashSet<string> set, int start, int end)
      {
        if (start > end)
        {
          _ans = Math.Max(_ans, set.Count);
          return;
        }

        for (var i = start; i <= end; i++)
        {
          var part = s.Substring(start, i - start + 1);
          if (set.Contains(part))
            continue;

          set.Add(part);

          Try(s, set, i + 1, end);

          set.Remove(part);
        }
      }
    }
  }
}
