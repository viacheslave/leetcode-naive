using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;

namespace LeetCode.Naive.Problems
{
  /// <summary>
  ///    Problem: https://leetcode.com/problems/longest-absolute-file-path/
  ///    Submission: https://leetcode.com/submissions/detail/243894032/
  /// </summary>
  internal class P0388
  {
    public class Solution
    {
      public int LengthLongestPath(string input)
      {
        var max = 0;
        var parts = input.Split('\n');

        var list = new List<string>();

        foreach (var part in parts)
        {
          var tabs = 0;
          var current = new StringBuilder(part);

          while (current.ToString().StartsWith('\t'))
          {
            current = current.Remove(0, 1);
            tabs++;
          }

          if (tabs < list.Count)
          {
            list = list.Take(tabs).ToList();
          }

          list.Add(current.ToString());
          if (current.ToString().Contains("."))
            max = Math.Max(max, string.Join('/', list).Length);
        }

        return max;
      }
    }
  }
}
