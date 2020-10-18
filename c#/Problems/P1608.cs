using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode.Naive.Problems
{
  /// <summary>
  ///    Problem: https://leetcode.com/problems/special-array-with-x-elements-greater-than-or-equal-x/
  ///    Submission: https://leetcode.com/submissions/detail/404329848/
  /// </summary>
  internal class P1608
  {
    public class Solution
    {
      public int SpecialArray(int[] nums)
      {
        Array.Sort(nums);

        // 1,3,5
        for (int i = nums.Length - 1; i >= 0; i--)
        {
          var count = nums.Length - i;

          if (nums[i] < count)
            continue;

          var lower = (i - 1 >= 0)
              ? nums[i - 1] + 1
              : 0;

          var upper = nums[i];

          if (lower <= upper)
          {
            for (var j = lower; j <= upper; j++)
            {
              if (count >= j)
                return count;
            }
          }
        }

        return -1;
      }
    }
  }
}
