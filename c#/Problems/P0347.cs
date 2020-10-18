using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;

namespace LeetCode.Naive.Problems
{
  /// <summary>
  ///    Problem: https://leetcode.com/problems/top-k-frequent-elements/
  ///    Submission: https://leetcode.com/submissions/detail/231068961/
  /// </summary>
  internal class P0347
  {
    public class Solution
    {
      public IList<int> TopKFrequent(int[] nums, int k)
      {
        var d = new Dictionary<int, int>();

        for (var i = 0; i < nums.Length; i++)
        {
          if (!d.ContainsKey(nums[i]))
            d[nums[i]] = 0;

          d[nums[i]]++;
        }

        return d.OrderByDescending(item => item.Value)
            .Take(k)
            .Select(item => item.Key)
            .ToList();
      }
    }
  }
}
