using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode.Naive.Problems
{
  /// <summary>
  ///    Problem: https://leetcode.com/problems/minimum-operations-to-reduce-x-to-zero/
  ///    Submission: https://leetcode.com/submissions/detail/420477945/
  /// </summary>
  internal class P1658
  {
    public class Solution
    {
      public int MinOperations(int[] nums, int x)
      {
        //[3,2,20,1,1,3]

        var targetSum = nums.Sum() - x;

        if (targetSum < 0)
          return -1;

        if (targetSum == 0)
          return nums.Length;

        var prefix = new int[nums.Length + 1];
        for (var i = 0; i < nums.Length; i++)
          prefix[i + 1] = prefix[i] + nums[i];

        var ans = int.MinValue;

        for (var i = 0; i < nums.Length; i++)
        {
          if (GetSum(prefix, i, i) > targetSum)
            continue;

          // binary search
          var left = i;
          var right = nums.Length - 1;

          while (true)
          {
            var sumLeft = GetSum(prefix, left, i);
            var sumRight = GetSum(prefix, right, i);

            if (right - left <= 1)
            {
              if (sumRight == targetSum)
                ans = Math.Max(ans, right - i + 1);

              if (sumLeft == targetSum)
                ans = Math.Max(ans, left - i + 1);

              break;
            }

            var mid = (left + right) / 2;
            var sumMid = GetSum(prefix, mid, i);

            if (sumMid > targetSum)
              right = mid;
            else
              left = mid;
          }
        }

        if (ans == int.MinValue)
          return -1;

        return nums.Length - ans;
      }

      private int GetSum(int[] prefix, int right, int left)
      {
        return prefix[right + 1] - prefix[left];
      }
    }
  }
}
