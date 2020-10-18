using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;

namespace LeetCode.Naive.Problems
{
  /// <summary>
  ///    Problem: https://leetcode.com/problems/find-pivot-index/
  ///    Submission: https://leetcode.com/submissions/detail/229982254/
  /// </summary>
  internal class P0724
  {
    public class Solution
    {
      public int PivotIndex(int[] nums)
      {

        if (nums.Length == 0)
          return -1;

        if (nums.Length == 1)
          return 0;

        var fullsum = 0;
        foreach (var a in nums)
          fullsum += a;

        var leftsum = 0;

        for (var index = 0; index < nums.Length; index++)
        {
          var rightsum = fullsum - leftsum - nums[index];
          if (leftsum == rightsum)
            return index;

          leftsum += nums[index];
        }

        return -1;
      }
    }
  }
}
