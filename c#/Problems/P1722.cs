using System.Collections.Generic;
using System.Linq;

namespace LeetCode.Naive.Problems
{
  /// <summary>
  ///    Problem: https://leetcode.com/problems/minimize-hamming-distance-after-swap-operations/
  ///    Submission: https://leetcode.com/submissions/detail/441151675/
  /// </summary>
  internal class P1722
  {
    public class Solution
    {
      public int MinimumHammingDistance(int[] source, int[] target, int[][] allowedSwaps)
      {
        var sets = Enumerable.Range(0, source.Length)
          .Select((p, i) => (index: i, value: p, rank: 0))
          .ToList();

        // union-find across allowed swaps
        foreach (var swap in allowedSwaps)
        {
          var component1 = Find(sets, swap[0]);
          var component2 = Find(sets, swap[1]);

          if (component1 == component2)
            continue;

          Union(sets, swap[0], swap[1]);
        }

        // adjust parents
        for (var i = 0; i < source.Length; i++)
          Find(sets, i);

        // reduce to components
        // expose indices
        var components = sets
          .GroupBy(x => x.value)
          .ToDictionary(x => x.Key, x => x.Select(_ => _.index).ToList());

        var ans = 0;

        foreach (var component in components)
        {
          var indicies = component.Value;
          var src = new List<int>();
          var tgt = new List<int>();

          foreach (var ind in indicies)
          {
            src.Add(source[ind]);
            tgt.Add(target[ind]);
          }

          // same as .Intersect
          // but preserves duplicates
          var common = Supersect(src, tgt).ToList();
          ans += src.Count - common.Count;
        }

        return ans;
      }

      private List<int> Supersect(List<int> list1, List<int> list2)
      {
        var lookup2 = list2.ToLookup(i => i);

        var result =
        (
          from group1 in list1.GroupBy(i => i)
          let group2 = lookup2[group1.Key]
          from i in (group1.Count() < group2.Count() ? group1 : group2)
          select i
        ).ToList();

        return result;
      }

      private int Find(List<(int index, int value, int rank)> sets, int p1)
      {
        if (sets[p1].value != p1)
        {
          var value = Find(sets, sets[p1].value);
          sets[p1] = (sets[p1].index, value, sets[p1].rank);
        }

        return sets[p1].value;
      }

      private void Union(List<(int index, int value, int rank)> sets, int p1, int p2)
      {
        var value1 = Find(sets, p1);
        var value2 = Find(sets, p2);

        if (sets[value1].rank < sets[value2].rank)
        {
          sets[value1] = (sets[value1].index, value2, sets[value1].rank);
        }
        else if (sets[value1].rank > sets[value2].rank)
        {
          sets[value2] = (sets[value2].index, value1, sets[value2].rank);
        }
        else
        {
          sets[value1] = (sets[value1].index, value2, sets[value1].rank);
          sets[value2] = (sets[value2].index, sets[value2].value, sets[value2].rank + 1);
        }
      }
    }
  }
}
