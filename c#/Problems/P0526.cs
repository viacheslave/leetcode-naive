using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;

namespace LeetCode.Naive.Problems
{
  /// <summary>
  ///    Problem: https://leetcode.com/problems/beautiful-arrangement/
  ///    Submission: https://leetcode.com/submissions/detail/400903915/
  /// </summary>
  internal class P0526
  {
    public class Solution
    {
      private int _ans = 0;

      public int CountArrangement(int N)
      {
        var set = new SortedSet<int>(Enumerable.Range(1, N));

        var list = new List<int>(N);

        Count(set, list, 0);

        return _ans;
      }

      private void Count(SortedSet<int> set, List<int> list, int index)
      {
        if (set.Count == 0)
        {
          _ans++;
          return;
        }

        var pos = index + 1;

        foreach (var el in set.ToArray())
        {
          if (el % pos == 0 || pos % el == 0)
          {
            list.Add(el);
            set.Remove(el);

            Count(set, list, index + 1);

            set.Add(el);
            list.RemoveAt(list.Count - 1);
          }
        }
      }
    }
  }
}
