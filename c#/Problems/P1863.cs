using System;
using System.Collections.Generic;
using System.Linq;

namespace LeetCode.Naive.Problems
{
  /// <summary>
  ///    Problem: https://leetcode.com/problems/sum-of-all-subset-xor-totals/
  ///    Submission: https://leetcode.com/submissions/detail/493954322/
  /// </summary>
  internal class P1863
  {
    public class Solution
    {
      public int SubsetXORSum(int[] nums)
      {
        var mask = (1 << (nums.Length)) - 1;
        var set = new HashSet<int>();

        var ans = Rec(nums, mask, set);
        var all = nums.Aggregate((res, cur) => res ^ cur);

        return ans + all;
      }

      private int Rec(int[] nums, int mask, HashSet<int> set)
      {
        var ans = 0;

        for (var i = 0; i < nums.Length; i++)
        {
          if ((mask & (1 << i)) == 0)
            continue;

          var tr = mask - (1 << i);
          if (set.Contains(tr))
            continue;

          mask -= (1 << i);

          var xor = -1;
          for (var j = 0; j < nums.Length; j++)
            if ((mask & (1 << j)) == (1 << j))
              xor = xor == -1 ? nums[j] : xor ^ nums[j];

          if (xor != -1)
          {
            set.Add(mask);

            ans += xor;
            ans += Rec(nums, mask, set);
          }

          mask += (1 << i);
        }

        return ans;
      }
    }
  }
}
