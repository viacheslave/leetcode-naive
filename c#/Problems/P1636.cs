using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode.Naive.Problems
{
  /// <summary>
  ///    Problem: https://leetcode.com/problems/sort-array-by-increasing-frequency/
  ///    Submission: https://leetcode.com/submissions/detail/415573451/
  /// </summary>
  internal class P1636
  {
    public class Solution
    {
      public int[] FrequencySort(int[] nums)
      {
        return nums
          .GroupBy(x => x)
          .OrderBy(x => x.Count())
          .ThenByDescending(x => x.Key)
          .SelectMany(x => Enumerable.Repeat(x.Key, x.Count()))
          .ToArray();
      }
    }
  }
}
