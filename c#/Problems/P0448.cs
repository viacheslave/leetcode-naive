using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;

namespace LeetCode.Naive.Problems
{
  /// <summary>
  ///    Problem: https://leetcode.com/problems/find-all-numbers-disappeared-in-an-array/
  ///    Submission: https://leetcode.com/submissions/detail/231257802/
  /// </summary>
  internal class P0448
  {
    public class Solution
    {
      public IList<int> FindDisappearedNumbers(int[] nums)
      {
        var res = new List<int>();

        for (var i = 0; i < nums.Length; i++)
        {
          if (nums[i] == i + 1 || nums[i] == 0)
            continue;

          var nextindex = nums[i] - 1;
          while (nums[nextindex] != 0)
          {
            var tmp = nextindex;
            nextindex = nums[nextindex] - 1;
            nums[tmp] = 0;
          }
        }

        for (var i = 0; i < nums.Length; i++)
        {
          if (nums[i] != 0 && nums[i] != i + 1)
            res.Add(i + 1);
        }

        return res;
      }
    }
  }
}
