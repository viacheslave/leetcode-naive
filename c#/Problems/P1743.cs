using System.Collections.Generic;
using System.Linq;

namespace LeetCode.Naive.Problems
{
  /// <summary>
  ///    Problem: https://leetcode.com/problems/restore-the-array-from-adjacent-pairs/
  ///    Submission: https://leetcode.com/submissions/detail/450124247/
  /// </summary>
  internal class P1743
  {
    public class Solution
    {
      public int[] RestoreArray(int[][] adjacentPairs)
      {
        var map = new Dictionary<int, List<int>>();

        foreach (var item in adjacentPairs)
        {
          if (!map.ContainsKey(item[0])) map[item[0]] = new List<int>();
          if (!map.ContainsKey(item[1])) map[item[1]] = new List<int>();

          map[item[0]].Add(item[1]);
          map[item[1]].Add(item[0]);
        }

        var ans = new List<int>();
        var el = map.First(x => x.Value.Count == 1).Key;

        while (true)
        {
          ans.Add(el);

          var next = map[el].First();
          map[next].Remove(el);

          if (map[next].Count == 0)
          {
            ans.Add(next);
            break;
          }

          el = next;
        }

        return ans.ToArray();
      }
    }
  }
}
