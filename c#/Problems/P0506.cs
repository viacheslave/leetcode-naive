using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;

namespace LeetCode.Naive.Problems
{
  /// <summary>
  ///    Problem: https://leetcode.com/problems/relative-ranks/
  ///    Submission: https://leetcode.com/submissions/detail/233603126/
  /// </summary>
  internal class P0506
  {
    public class Solution
    {
      public string[] FindRelativeRanks(int[] nums)
      {
        return nums
            .ToDictionary(_ => _, _ => Array.IndexOf(nums, _))
            .OrderByDescending(_ => _.Key)
            .Select((_, i) => new KeyValuePair<string, int>(GetValue(i), _.Value))
            .OrderBy(_ => _.Value)
            .Select(_ => _.Key)
            .ToArray();
      }

      private string GetValue(int index)
      {
        if (index == 0)
          return "Gold Medal";

        if (index == 1)
          return "Silver Medal";

        if (index == 2)
          return "Bronze Medal";

        return (index + 1).ToString();
      }
    }
  }
}
