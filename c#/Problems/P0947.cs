using System.Collections.Generic;
using System.Linq;

namespace LeetCode.Naive.Problems
{
  /// <summary>
  ///    Problem: https://leetcode.com/problems/most-stones-removed-with-same-row-or-column/
  ///    Submission: https://leetcode.com/submissions/detail/437543867/
  /// </summary>
  internal class P0947
  {
    public class Solution
    {
      public int RemoveStones(int[][] stones)
      {
        var starr = stones.Select((s, i) => (point: (x: s[0], y: s[1]), index: i))
          .ToArray();

        // group stones by X
        var byX = starr.GroupBy(s => s.point.x)
          .ToDictionary(x => x.Key, x => x.Select(_ => _.index).ToArray());

        // group stones by Y
        var byY = starr.GroupBy(s => s.point.y)
          .ToDictionary(x => x.Key, x => x.Select(_ => _.index).ToArray());

        var adjX = new Dictionary<int, int[]>();
        var adjY = new Dictionary<int, int[]>();

        // make adjacent by X
        foreach (var item in byX)
          foreach (var i in item.Value)
            adjX[i] = item.Value;

        // make adjacent by Y
        foreach (var item in byY)
          foreach (var i in item.Value)
            adjY[i] = item.Value;

        var adj = new Dictionary<int, List<int>>();

        // combine adjaent
        for (var i = 0; i < stones.Length; i++)
        {
          adj[i] = new List<int>();
          adj[i].AddRange(adjX[i]);
          adj[i].AddRange(adjY[i]);
        }

        var sets = Enumerable.Range(0, stones.Length)
          .Select(p => (value: p, rank: 0))
          .ToList();

        // union-find pairs
        foreach (var kvp in adj)
        {
          foreach (var i in kvp.Value)
          {
            var component1 = Find(sets, kvp.Key);
            var component2 = Find(sets, i);

            if (component1 == component2)
              continue;

            Union(sets, kvp.Key, i);
          }
        }

        // adjust parents
        for (var i = 0; i < stones.Length; i++)
          Find(sets, i);

        // sum grouped by count - 1
        // last stone in the group we do not take
        var ans = sets.GroupBy(x => x.value)
          .Select(x => x.Count())
          .Where(x => x > 1)
          .Select(x => x - 1)
          .Sum();

        return ans;
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
