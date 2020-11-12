using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;

namespace LeetCode.Naive.Problems
{
  /// <summary>
  ///    Problem: https://leetcode.com/problems/number-of-subsequences-that-satisfy-the-given-sum-condition/
  ///    Submission: https://leetcode.com/submissions/detail/419291722/
  /// </summary>
  internal class P1498
  {
    public class Solution
    {
      private readonly int _mod = (int)1e9 + 7;

      public int NumSubseq(int[] nums, int target)
      {
        int left = 0;
        Array.Sort(nums);

        var ans = 0;

        while (left != nums.Length)
        {
          var l = left;
          var r = nums.Length - 1;
          int right;

          while (true)
          {
            if (r - l <= 1)
            {
              if (nums[left] + nums[r] <= target)
                right = r;
              else
                right = l;

              break;
            }

            var mid = (l + r) / 2;
            if (nums[left] + nums[mid] <= target)
              l = mid;
            else
              r = mid;
          }

          if (nums[left] + nums[right] > target)
          {
            left++;
            continue;
          }

          var value = (int)BigInteger.ModPow(2, right - left, _mod);

          ans += value;
          ans %= _mod;
          left++;
        }

        return ans % _mod;
      }
    }
  }
}
