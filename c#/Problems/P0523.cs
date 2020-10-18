using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;

namespace LeetCode.Naive.Problems
{
  /// <summary>
  ///    Problem: https://leetcode.com/problems/continuous-subarray-sum/
  ///    Submission: https://leetcode.com/submissions/detail/238337742/
  /// </summary>
  internal class P0523
  {
    public class Solution
    {
      public bool CheckSubarraySum(int[] nums, int k)
      {
        if (nums.Length == 0)
          return false;

        for (var i = 0; i < nums.Length - 1; i++)
        {
          if (Get(nums, i, k))
            return true;
        }

        return false;
      }

      private bool Get(int[] nums, int i, int k)
      {
        var sum = nums[i];

        for (var index = i + 1; index < nums.Length; index++)
        {
          sum += nums[index];
          if ((k == 0 && sum == k) || (k != 0 && sum % k == 0))
            return true;
        }

        return false;
      }
    }
  }
}
