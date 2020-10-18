using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;

namespace LeetCode.Naive.Problems
{
  /// <summary>
  ///    Problem: https://leetcode.com/problems/binary-search/
  ///    Submission: https://leetcode.com/submissions/detail/229979885/
  /// </summary>
  internal class P0704
  {
    public class Solution
    {
      public int Search(int[] nums, int target)
      {
        if (nums.Length == 0)
          return -1;

        var index = Search(nums, 0, nums.Length - 1, target);
        if (index == -1)
          return -1;

        return index;
      }

      int Search(int[] nums, int start, int end, int target)
      {
        if (end - start <= 1)
        {
          if (nums[start] == target)
            return start;
          else if (nums[end] == target)
            return end;
          else
            return -1;
        }

        var ileft = Search(nums, start, (start + end) / 2, target);
        var iright = Search(nums, (start + end) / 2, end, target);

        if (ileft != -1) return ileft;
        if (iright != -1) return iright;

        return -1;
      }
    }
  }
}
