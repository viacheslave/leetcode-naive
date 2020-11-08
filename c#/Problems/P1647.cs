using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode.Naive.Problems
{
  /// <summary>
  ///    Problem: https://leetcode.com/problems/minimum-deletions-to-make-character-frequencies-unique
  ///    Submission: https://leetcode.com/submissions/detail/418085202/
  /// </summary>
  internal class P1647
  {
    public class Solution
    {
      public int MinDeletions(string s)
      {
        var freq = s
          .GroupBy(x => x)
          .Select(x => (x.Key, x.Count()))
          .GroupBy(x => x.Item2)
          .Select(x => (count: x.Key, chars: x.Select(v => v.Key).ToList()))
          .OrderByDescending(x => x.count)
          .ToList();

        var freqSet = freq.Select(x => x.count).ToHashSet();

        var ans = 0;

        foreach (var entry in freq)
        {
          if (entry.chars.Count == 1)
            continue;

          for (var i = 0; i < entry.chars.Count - 1; i++)
          {
            var count = entry.count - 1;
            ans++;

            while (freqSet.Contains(count))
            {
              if (count == 0)
                break;

              ans++;
              count--;
            }

            freqSet.Add(count);
          }
        }

        return ans;
      }
    }
  }
}
