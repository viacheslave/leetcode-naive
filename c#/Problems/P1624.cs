using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode.Naive.Problems
{
  /// <summary>
  ///   Problem: https://leetcode.com/problems/largest-substring-between-two-equal-characters/
  ///   Submission: https://leetcode.com/submissions/detail/410266192/
  /// </summary>
  internal class P1624
  {
    public class Solution
    {
      public int MaxLengthBetweenEqualCharacters(string s)
      {
        var multiple = s.GroupBy(ch => ch)
          .Where(c => c.Count() > 1)
          .ToDictionary(c => c.Key, c => c.Count());

        var maxDistance = int.MinValue;

        foreach (var entry in multiple)
        {
          var first = s.IndexOf(entry.Key);
          var last = s.LastIndexOf(entry.Key);

          var distance = last - first - 1;
          maxDistance = Math.Max(maxDistance, distance);
        }

        return maxDistance == int.MinValue ? -1 : maxDistance;
      }
    }
  }
}
