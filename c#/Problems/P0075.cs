using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode.Naive.Problems
{
  /// <summary>
  ///    Problem: https://leetcode.com/problems/sort-colors/
  ///    Submission: https://leetcode.com/submissions/detail/230695655/
  /// </summary>
  internal class P0075
  {
    public class Solution
    {
      public void SortColors(int[] nums)
      {
        var ds = new Dictionary<int, int>()
        {
          [0] = 0,
          [1] = 0,
          [2] = 0
        };

        foreach (var c in nums)
        {
          ds[c]++;
        }

        int index = 0;
        int color = 0;

        while (index < nums.Length)
        {
          if (color == 0 && ds[color] == 0)
            color = 1;

          if (color == 1 && ds[color] == 0)
            color = 2;

          nums[index] = color;
          ds[color]--;

          index++;
        }
      }
    }
  }
}
