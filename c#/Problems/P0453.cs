using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode.Naive.Problems
{
  /// <summary>
  ///    Problem: https://leetcode.com/problems/minimum-moves-to-equal-array-elements/
  ///    Submission: https://leetcode.com/submissions/detail/422096246/
  /// </summary>
  internal class P0453
  {
    public class Solution
    {
      public int MinMoves(int[] nums)
      {
        if (nums.Length <= 1)
          return 0;

        Array.Sort(nums);

        var ans = 0;

        for (var i = 0; i < nums.Length; i++)
          ans += nums[i] - nums[0];

        return ans;
      }
    }
  }
}
