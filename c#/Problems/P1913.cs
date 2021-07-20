using System;
using System.Collections.Generic;
using System.Linq;

namespace LeetCode.Naive.Problems
{
  /// <summary>
  ///    Problem: https://leetcode.com/problems/maximum-product-difference-between-two-pairs/
  ///    Submission: https://leetcode.com/submissions/detail/525484149/
  /// </summary>
  internal class P1913
  {
    public class Solution
    {
      public int MaxProductDifference(int[] nums)
      {
        Array.Sort(nums);
        return -1 * (nums[0] * nums[1] - nums[nums.Length - 1] * nums[nums.Length - 2]);
      }
    }
  }
}
