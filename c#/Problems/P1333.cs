using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode.Naive.Problems
{
  /// <summary>
  ///    Problem: https://leetcode.com/problems/filter-restaurants-by-vegan-friendly-price-and-distance/
  ///    Submission: https://leetcode.com/submissions/detail/297617606/
  /// </summary>
  internal class P1333
  {
    public class Solution
    {
      public IList<int> FilterRestaurants(int[][] restaurants, int veganFriendly, int maxPrice, int maxDistance)
      {
        return restaurants
            .Where(r => veganFriendly == 1 ? r[2] == 1 : true)
            .Where(r => r[3] <= maxPrice)
            .Where(r => r[4] <= maxDistance)
            .OrderByDescending(r => r[1])
            .ThenByDescending(r => r[0])
            .Select(r => r[0])
            .ToList();
      }
    }
  }
}
