using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode.Naive.Problems
{
  /// <summary>
  ///    Problem: https://leetcode.com/problems/sort-integers-by-the-power-value/
  ///    Submission: https://leetcode.com/submissions/detail/314585421/
  /// </summary>
  internal class P1387
  {
    public class Solution
    {
      public int GetKth(int lo, int hi, int k)
      {
        var map = new Dictionary<int, int>();

        for (int i = lo; i <= hi; i++)
          GetRank(i, map);

        var list = map.OrderBy(x => x.Value).ThenBy(x => x.Key)
          .Select(x => x.Key)
          .Where(x => x >= lo && x <= hi)
          .ToArray();

        return list[k - 1];
      }

      private int GetRank(int n, Dictionary<int, int> map)
      {
        if (n == 1)
        {
          map[n] = 0;
          return 0;
        }

        if (map.ContainsKey(n))
          return map[n];

        map[n] = (n % 2 == 1)
          ? GetRank(n * 3 + 1, map) + 1
          : GetRank(n / 2, map) + 1;

        return map[n];
      }
    }
  }
}
