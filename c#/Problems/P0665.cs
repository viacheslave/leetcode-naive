using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;

namespace LeetCode.Naive.Problems
{
  /// <summary>
  ///    Problem: https://leetcode.com/problems/non-decreasing-array/
  ///    Submission: https://leetcode.com/submissions/detail/230684675/
  /// </summary>
  internal class P0665
  {
    public class Solution
    {
      public bool CheckPossibility(int[] nums)
      {
        if (nums.Length < 2)
          return true;

        bool mod = false;

        for (var i = 1; i < nums.Length; i++)
        {
          if (nums[i] < nums[i - 1])
          {
            if (mod)
              return false;

            if (nums[i - 1] > nums[i])
            {
              if (i < 2 || nums[i - 2] < nums[i])
              {
                nums[i - 1] = nums[i];
                mod = true;
                continue;
              }

              if (i == nums.Length - 1 || nums[i - 1] <= nums[i + 1])
              {
                nums[i] = nums[i - 1];
                mod = true;
                continue;
              }

              return false;
            }
          }
        }


        return true;
      }
    }
  }
}
