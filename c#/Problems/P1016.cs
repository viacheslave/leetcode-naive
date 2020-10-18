using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode.Naive.Problems
{
  /// <summary>
  ///    Problem: https://leetcode.com/problems/binary-string-with-substrings-representing-1-to-n/
  ///    Submission: https://leetcode.com/submissions/detail/258899999/
  /// </summary>
  internal class P1016
  {
    public class Solution
    {
      public bool QueryString(string S, int N)
      {
        var items = new List<string>();
        var log = (int)Math.Log(N, 2) + 1;

        for (int i = log; i >= 1; i--)
        {
          var variants = GetVars(S, i);
          items.AddRange(variants);
        }

        var itemsSet = items.Select(x => x.TrimStart(new char[] { '0' })).Distinct().ToHashSet();

        for (int i = 1; i <= N; i++)
        {
          var value = Convert.ToString(i, 2);
          if (!itemsSet.Contains(value))
            return false;
        }

        return true;
      }

      private IEnumerable<string> GetVars(string s, int n)
      {
        var items = new List<string>();
        for (int i = 0; i < s.Length - n + 1; i++)
        {
          items.Add(s.Substring(i, n));
        }

        return items;
      }
    }
  }
}
