using System;
using System.Collections.Generic;
using System.Linq;

namespace LeetCode.Naive.Problems
{
  /// <summary>
  ///    Problem: https://leetcode.com/problems/smallest-string-with-swaps/
  ///    Submission: https://leetcode.com/submissions/detail/437169960/
  /// </summary>
  internal class P1202
  {
    public class Solution
    {
      public string SmallestStringWithSwaps(string s, IList<IList<int>> pairs)
      {
        var sets = Enumerable.Range(0, s.Length)
          .Select(p => (value: p, rank: 0))
          .ToList();

        // union-find pairs
        foreach (var pair in pairs)
        {
          var component1 = Find(sets, pair[0]);
          var component2 = Find(sets, pair[1]);

          if (component1 == component2)
            continue;

          Union(sets, pair[0], pair[1]);
        }

        // adjust parents
        foreach (var pair in pairs)
        {
          Find(sets, pair[0]);
          Find(sets, pair[1]);
        }

        // group components - indices arrays
        var components = sets.Select((a, i) => (a, i))
          .GroupBy(a => a.a.value)
          .ToDictionary(a => a.Key, a => a.Select(x => x.i).ToArray());

        var arr = new char[s.Length];

        foreach (var component in components)
        {
          var indices = component.Value;
          var chs = new char[indices.Length];

          for (var i = 0; i < indices.Length; i++)
            chs[i] = s[indices[i]];

          // sort arrays
          Array.Sort(chs);

          // assign in order
          for (var i = 0; i < indices.Length; i++)
            arr[indices[i]] = chs[i];
        }

        return new string(arr);
      }

      private int Find(List<(int value, int rank)> sets, int p1)
      {
        if (sets[p1].value != p1)
        {
          var value = Find(sets, sets[p1].value);
          sets[p1] = (value, sets[p1].rank);
        }

        return sets[p1].value;
      }

      private void Union(List<(int value, int rank)> sets, int p1, int p2)
      {
        var value1 = Find(sets, p1);
        var value2 = Find(sets, p2);

        if (sets[value1].rank < sets[value2].rank)
        {
          sets[value1] = (value2, sets[value1].rank);
        }
        else if (sets[value1].rank > sets[value2].rank)
        {
          sets[value2] = (value1, sets[value2].rank);
        }
        else
        {
          sets[value1] = (value2, sets[value1].rank);
          sets[value2] = (sets[value2].value, sets[value2].rank + 1);
        }
      }
    }
  }
}
