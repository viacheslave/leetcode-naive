using System;
using System.Collections.Generic;
using System.Linq;

namespace LeetCode.Naive.Problems
{
  /// <summary>
  ///    Problem: https://leetcode.com/problems/remove-one-element-to-make-the-array-strictly-increasing/
  ///    Submission: https://leetcode.com/submissions/detail/525488416/
  /// </summary>
  internal class P1909
  {
    public class Solution
    {
      public bool CanBeIncreasing(int[] nums)
      {
        var pairs = new List<(int, int)>();

        for (var i = 0; i < nums.Length - 1; ++i)
          if (nums[i] >= nums[i + 1])
            pairs.Add((i, i + 1));

        if (pairs.Count == 0)
          return true;

        if (pairs.Count > 1)
          return false;

        var pair = pairs[0];


        // try remove first
        if (pair.Item1 == 0)
          return true;
        if (nums[pair.Item1 - 1] < nums[pair.Item2])
          return true;

        // try remove second
        if (pair.Item2 == nums.Length - 1)
          return true;
        if (nums[pair.Item1] < nums[pair.Item2 + 1])
          return true;

        return false;
      }
    }
  }
}
