using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;

namespace LeetCode.Naive.Problems
{
  /// <summary>
  ///    Problem: https://leetcode.com/problems/distribute-candies/
  ///    Submission: https://leetcode.com/submissions/detail/238607358/
  /// </summary>
  internal class P0575
  {
    public class Solution
    {
      public int DistributeCandies(int[] candies)
      {
        var map = candies.GroupBy(_ => _).ToDictionary(_ => _.Key, _ => _.Count())
            .OrderBy(_ => _.Value)
            .ToDictionary(_ => _.Key, _ => _.Value);

        var items = new HashSet<int>();

        var index = 0;
        while (true)
        {
          var keysToRemove = new List<int>();

          foreach (var item in map)
          {
            index++;
            if (index > candies.Length / 2)
              return items.Count;

            var key = item.Key;
            items.Add(key);

            if (item.Value == 1)
              keysToRemove.Add(key);
          }

          foreach (var r in keysToRemove)
            map.Remove(r);
        }
      }
    }
  }
}
